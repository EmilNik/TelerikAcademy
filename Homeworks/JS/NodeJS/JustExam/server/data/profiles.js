var User = require('mongoose').model('User'),
    Playlist = require('mongoose').model('Playlist');

module.exports = {
    getUserAndPlaylistsByUsername: function (username, callback) {
        var data = {};
        User
            .find({
                username: username
            })
            .exec(function (err, user) {
                data.user = user;
                if (err) {
                    callback(err, data);
                }
            })

        Playlist
            .find({
                creator: username
            })
            .exec(function (err, playlists) {
                playlists.sort(function (a, b) {
                    return b.date - a.date;
                });
                data.playlists = playlists;
                callback(err, data);
            })
    }
}