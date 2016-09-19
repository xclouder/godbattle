var net = require('net');
var fs = require('fs');
var protobuf = require('protocol-buffers')
var messages = protobuf(fs.readFileSync('../Protocol/Rpc.proto'))

var HOST = '127.0.0.1';
var PORT = 50001;

var ENTITY_ID = 1;
var entities = {}

net.createServer(function (sock) {

    console.log("CONNECTED:" + sock.remoteAddress + ":" + sock.remotePort);

    //new client connect, create one player for it, and send back env entities.
    var player = createEntity(sock, "Player");
    entities[player.entityId] = player;

    for (var eid in entities)
    {
        console.log("eid:"+eid);
        notifyClientCreateEntity(player, entities[eid]);
    }

    //set player -- need optmize. SetPlayer should call from client
    player.callClientRoot("SetPlayer", player.entityId);

    sock.on('data', function(data)
    {
        if (data.length < 7)
            return;

        receivePacket(data, function(head, body){

            console.log('msg cmd:' + head.cmd);
            console.log('msg session:' + head.session);
            
            if (head.cmd == 2)
            {
                handleRpc(body, sock);
            }
        });
        
    });

    sock.on('close', function(data){
        console.log("CLOSED: " + sock.remoteAddress + ", PORT:" + sock.remotePort);
    });

}).listen(PORT, function(){
    console.log("server started");
});

function printBuffer(buffer)
{
    console.log("BUFFER:");
    console.log(buffer);
}

function sendPacket(sock, msg)
{
    var headCode = messages.MsgHead.encode(msg.head);
    var bodyJson = JSON.stringify(msg.body);
    console.log("body:"+bodyJson);
    var body = {data:bodyJson};
    var bodyCode = messages.MsgBody.encode(body);
    var headLen = headCode.length;

    var bodyLen = 0;
    if (bodyCode != null)
    {
        bodyLen = bodyCode.length;
    }

    var len = headLen + 4 + bodyLen;
    var data = new Buffer(len + 4);

    data.writeInt32BE(len, 0);
    data.writeInt32BE(headLen, 4);

    headCode.copy(data, 8, 0, headLen);

    if (bodyCode != null)
    {
        bodyCode.copy(data, 8 + headLen, 0, bodyLen);

        console.log("body:");
        console.log(bodyCode);
    }

    console.log("server send data:");
    console.log(data);
    sock.write(data);
}

function receivePacket(data, unpacked)
{
    console.log("server receive data:");
    console.log(data);

    var packageLen = data.readInt32BE(0);
    var headLen = data.readInt32BE(4);

    var headContent = new Buffer(headLen);
    data.copy(headContent, 0, 8, 8 + headLen);
    
    var head = messages.MsgHead.decode(headContent);

    var bodyLen = packageLen - 4 - headLen;
    var body = null;

    if(bodyLen > 0)
    {
        var bodyCode = new Buffer(bodyLen);
        data.copy(bodyCode, 0, 8 + headLen, data.length);
        body = messages.MsgBody.decode(bodyCode);
        var bodyJson = body.data;
        body = JSON.parse(bodyJson);
    }
    
    unpacked(head, body);
}

function handleRpc(body, sock)
{
    console.log("entityId:"+body.entityId);
    var entity = entities[body.entityId];
    entity.sock = sock;

    console.log("method:"+ body.method);
    console.log("params:" + body.args);

    var method = entity[body.method];
    method.apply(entity, body.args);
    
}

function createEntity(sock, className)
{
    var eid = ENTITY_ID++;
    
    var entity = {
        entityId : eid,
        className: className,
        sock : sock,

        callClient : function(method)
        {
            var paramsLen = arguments.length - 1;
            var params = null;
            if (paramsLen > 0)
            {
                params = new Array(paramsLen);
                for (var i = 0; i < paramsLen; i++)
                {
                    params[i] = arguments[i + 1];
                }
            }
            else
            {
                params = [];
            }

            this._callClient(this.entityId, method, params);
        },

        callClientRoot: function(method)
        {
            var paramsLen = arguments.length - 1;
            var params = null;
            if (paramsLen > 0)
            {
                params = new Array(paramsLen);
                for (var i = 0; i < paramsLen; i++)
                {
                    params[i] = arguments[i + 1];
                }
            }
            else
            {
                params = [];
            }

            this._callClient(0, method, params);
        },

        _callClient:function(eid, method, params)
        {
            var msg = {}
            msg.head = {
                cmd : 1,
                type : 2
            }

            msg.body = {
                entityId:eid,
                method:method,
                args:params
            };

            sendPacket(this.sock, msg);
        }
    }

    return entity;
}

function notifyClientCreateEntity(client, entity)
{
    client.callClientRoot("CreateEntity", entity.entityId, entity.className);
}