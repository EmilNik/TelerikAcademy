"use strict";

var formidable = require('formidable'),
  http = require('http'),
  fs = require('fs'),
  filePath = '';

function S4() {
  return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}

var Guid = function () {
  return (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
};

function getExtensions(fileName) {
  return fileName.substring(fileName.lastIndexOf('.'));
}

http.createServer(function (req, res) {
  if (req.url === '/upload' && req.method.toLowerCase() === 'post') {
    var form = new formidable.IncomingForm();
    form.uploadDir = 'files';
    form.keepExtensions = true;

    var guid = Guid();

    form.on('fileBegin', function (name, file) {
      file.path = form.uploadDir + '/' + guid + getExtensions(file.name);
      filePath = file.path;
    });

    form.parse(req, function (err, fields, files) {
      res.writeHead(200, { 'content-type': 'text/html' });
      if (!files.upload.name) {
        res.end('<h3>You didnt upload any file</h3><br><form action="/" enctype="multipart/form-data" method="get">' +
          '<input type="submit" value="Back" multiple="multiple"><br>' +
          '</form>');
        return;
      }

      res.end('<div><a href="/download">Download ' + files.upload.name + ' </a></div>');
    });

    return;
  } else if (req.url === '/download') {
    fs.readFile(filePath, 'utf8',
      function (error, fileText) {
        if (error) {
          console.log('File cannot be read: ' + error);
          return;
        }
        var fileName = filePath.substring(filePath.lastIndexOf('/') + 1);
        fs.writeFile('downloads/' + fileName, fileText, function (err) {
          if (err) {
            console.log('File cannot be write: ' + err);
          } else {
            alert('File downloaded');
          }
        });
      });
  }

  res.writeHead(200, { 'content-type': 'text/html' });
  res.end(
    '<br><br>' +
    '<form action="/upload" enctype="multipart/form-data" method="post">' +
    '<input type="file" name="upload" multiple="multiple"><br>' +
    '<input type="submit" value="Upload">' +
    '</form>'
    );
}).listen(8080);

console.log('Server running on port 8080');