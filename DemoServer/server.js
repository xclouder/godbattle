var net = require('net');
var fs = require('fs');

var Victor = require('./victor');

var protobuf = require('protocol-buffers')
var messages = protobuf(fs.readFileSync('../Protocol/Rpc.proto'));

var Class = require('./jsclass/src/core').Class;

var HOST = '127.0.0.1';
var PORT = 50001;

var ENTITY_ID = 1;
var entities = {}

var receiveBuffers = {}

var PacketReceiver = new Class(
{
    initialize: function() {
        this.onReceivePacket = null;
        this.buffer = new Buffer(1024);
        this.isHeadOk = false;
        this.packageLen = 0;
        this.offset = 0;
    },

    needBytesLen: function ()
    {
        if (!this.isHeadOk)
            return 4 - this.offset;

        return this.packageLen + 4 - this.offset;
    },
    reset: function()
    {
        this.isHeadOk = false;
        this.buffer = new Buffer(1024);
        this.packageLen = 0;
        this.offset = 0;
    },
    giveData:function(data){

        console.log("----------------------- begin ---------------------");
        this.readData(data, 0, data.length);
        console.log("------------------------ end ----------------------");
    },
    readData:function(data, from, len)
    {
        console.log("data length:" + data.length);
        console.log("read data from:" + from);
        console.log("read data len:" + len);
        console.log("buffer.offset:" + this.offset);
        console.log("buffer.length:" + this.buffer.length);

        var needBytes = this.needBytesLen();

        console.log("needBytes:" + needBytes);

        console.log("=======================");

        if (len < needBytes)
        {
            console.log("!!!WARNING: occur this situation");

            data.copy(this.buffer, this.offset, from, from + len);

            this.offset += len;

            //wait for more data
        }
        else
        {

            data.copy(this.buffer, this.offset, from, from + needBytes);

            this.offset += needBytes;

            // check if packet received.
            if (!this.isHeadOk)
            {
                this.isHeadOk = true;
                this.packageLen = this.buffer.readInt32BE(0);
                console.log("head ok, len:" + this.packageLen);
            }
            else
            {
                //body is ok
                if (this.onReceivePacket)
                {
                    var _len = this.packageLen + 4;
                    var _data = new Buffer(_len);

                    this.buffer.copy(_data, 0, 0, _len);
                    this.onReceivePacket(_data);
                }

                this.reset();
            }

            if (len > needBytes)
            {
                this.readData(data, from + needBytes, len - needBytes);
            }
            else
            {
                //wait for more data
            }
        }
    }
});

net.createServer(function (sock) {
    
    console.log("CONNECTED:" + sock.remoteAddress + ":" + sock.remotePort);

    sock.on('data', function(data)
    {
        if (data.length < 7)
            return;

        var receiver = receiveBuffers[sock];
        //这里要实现分包
        if (receiver == null)
        {
            receiver = new PacketReceiver();
            receiver.onReceivePacket = function (packet)
            {
                console.log('[packet handler]receive packet,len:' + packet.length);
                receivePacket(packet, function(head, body){
                    console.log('packet unpacked');
                    console.log('msg cmd:' + head.cmd);
                    console.log('msg session:' + head.session);
                    
                    if (head.cmd == 2)
                    {
                        handleRpc(body, sock);
                    }

                });
            }

            receiveBuffers[sock] = receiver;
        }

        receiver.giveData(data);
        
    });

    sock.on('close', function(data){
        console.log("CLOSED: " + sock.remoteAddress + ", PORT:" + sock.remotePort);
    });

}).listen(PORT, function(){
    
    gameLoop();

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

    console.log(data);
    sock.write(data);
}

function receivePacket(data, unpacked)
{
    console.log("server receive data:" + data.length);
    console.log(data);

    var packageLen = data.readInt32BE(0);
    var headLen = data.readInt32BE(4);

    console.log("receive pack len:" + packageLen);
    console.log("receive head len:" + headLen);

    var headContent = new Buffer(headLen);
    data.copy(headContent, 0, 8, 8 + headLen);
    
    var head = messages.MsgHead.decode(headContent);

    console.log("head unpack finished");
    
    var bodyLen = packageLen - 4 - headLen;
    console.log("body len:" + bodyLen);

    var body = null;

    if(bodyLen > 0)
    {
        console.log("has body");

        var bodyCode = new Buffer(bodyLen);
        data.copy(bodyCode, 0, 8 + headLen, data.length);
        
        console.log("body buffer len:" + bodyCode.length);

        console.log("receive body:");
        console.log(bodyCode);



        body = messages.MsgBody.decode(bodyCode);

        console.log("body unpack finished");

        var bodyJson = body.data;

        console.log("body json:" + bodyJson);

        body = JSON.parse(bodyJson);
    }
    
    console.log("unpacked..");
    unpacked(head, body);
}

var root = {
    login: function(sock)
    {
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
    }

}

function handleRpc(body, sock)
{
    console.log("entityId:"+body.entityId);

    if (body.entityId > 0)
    {   
        var entity = entities[body.entityId];
        entity.sock = sock;

        console.log("method:"+ body.method);
        console.log("params:" + body.args);

        var method = entity[body.method];
        method.apply(entity, body.args);
    }
    else
    {
        var method = root[body.method];
        body.args.unshift(sock);
        var argList = body.args;
        method.apply(root, argList);
    }
    
}

function createEntity(sock, className)
{
    var eid = ENTITY_ID++;
    
    var entity = {
        entityId : eid,
        className: className,
        sock : sock,
        position : Victor(0, 0),
        dir : Victor(0, 1),
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
        },

        //call from client
        fire:function()
        {
            console.log("fire")
        },

        //call from client
        update:function(posX,posY,dirX,dirY)
        {
            console.log("entity update:(" + posX + "," + posY + ")");
            this.position = Victor(posX, posY);
            this.dir = Victor(dirX, dirY);
        }
    }

    return entity;
}

function notifyClientCreateEntity(client, entity)
{
    client.callClientRoot("CreateEntity", entity.entityId, entity.className);
}

function gameLoop()
{
    setInterval(tick, 33.3);
    console.log("server started");
}

function tick()
{
    // console.log("tick");

    // console.log("server tick.");
    for (var eid in entities)
    {


        var entity = entities[eid];

        //sync move
        for (eid2 in entities){
            // console.log("check eid2 move");

            if (eid == eid2)
                continue;

            console.log("call client SetMove");
            var otherEntity = entities[eid2];
            var thePos = otherEntity.position;
            var theDir = otherEntity.dir;
            entity.callClient("SetMove", thePos.x, thePos.y, theDir.x, theDir.y);
        }
    }
}
