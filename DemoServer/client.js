var net = require('net');
var fs = require('fs');
var protobuf = require('protocol-buffers')
var messages = protobuf(fs.readFileSync('../Protocol/MsgHead.proto'))
var gameMessages = protobuf(fs.readFileSync('../Protocol/GameMsg.proto'))

var HOST = '127.0.0.1';
var PORT = 50001;

var client = new net.Socket();
client.connect(PORT, HOST , function() {

    console.log('CONNECTED TO: ' + HOST + ':' + PORT);
    // 建立连接后立即向服务器发送数据，服务器将收到这些数据 
    
    sendCreateEntityMsg(client);

});

// 为客户端添加“data”事件处理函数
// data是服务器发回的数据
client.on('data', function(data) {

    if (data.length < 7)
        return;

    receivePacket(data, function(head, bodyCode){

        console.log("head cmd:" + head.cmd);
        console.log("seq:" + head.sequence);

        if(bodyCode != null)
        {
            console.log("body:");
            console.log(bodyCode);

            var createdInfo = gameMessages.EntityCreatedMsg.decode(bodyCode);

            var eid = createdInfo.entityId;
            console.log("entityId:" + eid);

            sendMoveMsg(client, eid, 1, 2);
        }

    });

});

// 为客户端添加“close”事件处理函数
client.on('close', function() {
    console.log('Connection closed');
});

function printBuffer(buffer)
{
    console.log("BUFFER:");
    console.log(buffer);
}

function sendCreateEntityMsg(sock)
{
    var headCode = messages.MsgHead.encode({
      cmd : 5,
      sequence : 1
    });

    sendPacket(sock, headCode, null);
}

function sendMoveMsg(sock, eid, x, y)
{
    var headCode = messages.MsgHead.encode({cmd:1});
    var bodyCode = gameMessages.MoveMsg.encode({
        entityId:eid,
        x:x,
        y:y
    });

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
    }

    console.log("client send data:");
    console.log(data);

    sock.write(data);
}

function receivePacket(data, unpacked)
{
    console.log("client receive data:");
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
