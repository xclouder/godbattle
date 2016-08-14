var net = require('net');

var HOST = '127.0.0.1';
var PORT = 50001;

net.createServer(function (sock) {

    console.log("CONNECTED:" + sock.remoteAddress + ":" + sock.remotePort);

    sock.on('data', function(data)
    {
        console.log('DATA' + sock.remoteAddress + ":" + data);

        sock.write("You said:" + data);
    });

    sock.on('close', function(data){
        console.log("CLOSED: " + sock.remoteAddress + ", PORT:" + sock.remotePort);
    });
}).listen(PORT, function(){
    console.log("server started");
});

