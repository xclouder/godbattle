var net = require('net');
var fs = require('fs');
var protobuf = require('protocol-buffers')
var messages = protobuf(fs.readFileSync('../Protocol/MsgHead.proto'))
var gameMessages = protobuf(fs.readFileSync('../Protocol/GameMsg.proto'))

var HOST = '127.0.0.1';
var PORT = 50001;

var ENTITY_ID = 1;
var entities = {}

net.createServer(function (sock) {

    console.log("CONNECTED:" + sock.remoteAddress + ":" + sock.remotePort);

    sock.on('data', function(data)
    {
        if (data.length < 7)
            return;

        receivePacket(data, function(head, bodyCode){

            console.log('msg cmd:' + head.cmd);
            console.log('msg seq:' + head.sequence);

            if (head.cmd == 5)
            {
                var entity = {};
                entity.entityId = ENTITY_ID++;
                entity.sock = sock;

                //write back packet EntityCreatedMsg
                sendEntityCreatedMsg(sock, entity.entityId, head.sequence);

                //notify entity EnterWorldMsg
                for (var eid in entities)
                {
                    var e = entities[eid];
                    sendEnterWorldMsg(e.sock, entity);
                }

                entities[entity.entityId] = entity;
                            
            }

            if (head.cmd == 7)
            {
                //log out
                var theEntity = null;
                for (var eid in entities)
                {
                    if (entities[eid].sock == sock)
                    {
                        theEntity = e;
                    }
                }

                for (var eid in entities)
                {
                    var e = entities[eid];
                    if (e != theEntity)
                    {
                        //TODO:notify the entity exited
                        
                    }
                }

                //entities.del(e)
                delete entities[e.entityId];
            }

            if (head.cmd ==1)
            {
                //moveMsg
                var moveMsg = gameMessages.MoveMsg.decode(bodyCode);
                var theEntity = entities[moveMsg.entityId];

                for (var eid in entities)
                {
                    var e = entities[eid];
                    if (e != theEntity)
                    {
                        //notify the move
                        sendUpdatePosMsg({
                            entityId: theEntity.entityId,
                            x: moveMsg.x,
                            y: moveMsg.y
                        });
                    }
                }
            }

        });
        /*
        var packageLen = data.readInt32BE(0);
        var headLen = data.readInt32BE(4);

        var headContent = new Buffer(headLen);
        data.copy(headContent, 0, 8, 8 + headLen);
        
        var head = messages.MsgHead.decode(headContent);
        console.log('msg cmd:' + head.cmd);
        console.log('msg seq:' + head.sequence);

        //READ BODY
        if(packageLen > headLen + 4)
        {
            //HAS BODY
            
        }

        if (head.cmd == 5)
        {
            var entity = {};
            entity.entityId = ENTITY_ID++;
            entity.sock = sock;

            entities[entity.entityId] = entity;

            //write back packet EntityCreatedMsg
            sendEntityCreatedMsg(sock, entityId.entityId, head.sequence);

            //notify entity EnterWorldMsg
                        
        }

        sock.write("You said:" + head.cmd);
        */
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

function sendEntityCreatedMsg(sock, entityId, seq)
{

    var bodyCode = gameMessages.EntityCreatedMsg.encode({
        entityId : entityId,
        name : "无极限"
    });

    var headCode = messages.MsgHead.encode({
        cmd : 6,
        sequence : seq
    });

    sendPacket(sock, headCode, bodyCode);
}

function sendEnterWorldMsg(sock, entity)
{
    var headCode = messages.MsgHead.encode({
        cmd : 3
    });
    
    var bodyCode = gameMessages.EnterWorldMsg.encode({
        entityId : entity.entityId
    });

    sendPacket(sock, headCode, bodyCode);
}

function sendUpdatePosMsg(sock, info)
{
    var headCode = messages.MsgHead.encode({cmd : 2});
    var bodyCode = gameMessages.UpdatePosMsg.encode(info);

    sendPacket(sock, headCode, bodyCode);
}

function sendPacket(sock, headCode, bodyCode)
{
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
    var bodyCode = null;

    if(bodyLen > 0)
    {
        bodyCode = new Buffer(bodyLen);
        data.copy(bodyCode, 0, 8 + headLen, data.length);
    }
    
    unpacked(head, bodyCode);
}

