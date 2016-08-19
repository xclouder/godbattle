var net = require('net');

var HOST = '127.0.0.1';
var PORT = 50001;

net.createServer(function (sock) {

    console.log("CONNECTED:" + sock.remoteAddress + ":" + sock.remotePort);

    sock.on('data', function(data)
    {
        console.log('DATA' + sock.remoteAddress + ":" + data);
        console.log('data len:' + data.length);
        console.log('is buffer? ' + Buffer.isBuffer(data));

        if (data.length < 12)
            return;

        var packageLen = data.readInt32BE(0);
        var id = data.readInt32BE(4);

        var content = data.toString("utf8", 8);

        console.log('packageLen:' + packageLen);
        console.log('id:' + id + "| content:" + content);

        sock.write("You said:" + data);
    });

    sock.on('close', function(data){
        console.log("CLOSED: " + sock.remoteAddress + ", PORT:" + sock.remotePort);
    });
}).listen(PORT, function(){
    console.log("server started");
});

