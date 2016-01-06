var formidable = require('formidable'),
    http = require('http'),
    fs = require('fs');

function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}

function getExtensions(fileName) {
    var index = fileName.lastIndexOf('.');

    var ext = fileName.substring(index, fileName.length);
    return ext;
}

http.createServer(function (req, res) {
    var filePath = '';

    if (req.url == '/upload' && req.method.toLowerCase() == 'post') {
        var form = new formidable.IncomingForm();
        form.uploadDir = 'C:/Users/Emil/Documents/Visual Studio 2015/Projects/JS/NodeJS/UploadFilesServer/files';
        form.keepExtensions = true;

        var guid = (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();

        form.on('fileBegin', function (name, file) {
            file.path = form.uploadDir + '/' + guid + getExtensions(file.name);
            filePath = file.path;
        });

        form.parse(req, function (err, fields, files) {
            res.writeHead(200, { 'content-type': 'text/html' });
            res.end('<form action="/" enctype="multipart/form-data" method="get">' +
                '<input type="submit" value="Download ' + files.upload.name + '" multiple="multiple"><br>' +
                '</form>');
        });

        return;
    } else if (req.url == '/?' && req.method.toLowerCase() == 'get') {
        
    }

    res.writeHead(200, { 'content-type': 'text/html' });
    res.end(
        '<form action="/upload" enctype="multipart/form-data" method="post">' +
        '<input type="text" name="title"><br>' +
        '<input type="file" name="upload" multiple="multiple"><br>' +
        '<input type="submit" value="Upload">' +
        '</form>'
        );
}).listen(8080);

console.log('Server running on port 8080');