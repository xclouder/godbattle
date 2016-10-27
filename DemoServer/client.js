var net = require('net');
var fs = require('fs');
var protobuf = require('protocol-buffers')
var messages = protobuf(fs.readFileSync('../Protocol/Rpc.proto'))


var HOST = '127.0.0.1';
var PORT = 50001;

var client = new net.Socket();
client.connect(PORT, HOST , function() {

    console.log('CONNECTED TO: ' + HOST + ':' + PORT);
    // 建立连接后立即向服务器发送数据，服务器将收到这些数据 
    
    // sleep(1.0);

    
    callServer(client, 1, "update", [0]);
});

// 为客户端添加“data”事件处理函数
// data是服务器发回的数据
client.on('data', function(data) {

    if (data.length < 7)
        return;

    receivePacket(data, function(head, bodyCode){

        console.log("head cmd:" + head.cmd);
        console.log("seq:" + head.sequence);

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

function callServer(sock, eid, method, params)
{
    var msg = {}
    msg.head = {
        cmd : 2,
        type : 2
    }

    msg.body = {
        entityId:eid,
        method:method,
        args:params
    };

    sendPacket(sock, msg);
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

    console.log("server send data:" + data.length);
    console.log(data);
    sock.write(data);
}

function receivePacket(data, unpacked)
{
    console.log("server receive data:");
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

        body = messages.MsgBody.decode(bodyCode);

        console.log("body unpack finished");

        var bodyJson = body.data;

        console.log("body json:" + bodyJson);

        body = JSON.parse(bodyJson);
    }
    
    console.log("unpacked..");
    unpacked(head, body);
}