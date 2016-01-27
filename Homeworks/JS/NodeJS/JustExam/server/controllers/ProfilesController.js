var profiles = require('../data/profiles'),
    constants = require('../common/constants');

var CONTROLLER_NAME = 'profiles';

module.exports = {
    getProfile: function (req, res, next) {
        var username = req.params.username;
        profiles.getUserAndPlaylistsByUsername(username, function (err, data) {
            var isAuth;
            if (data.user[0]._id == req.user._id) {
                isAuth = true;
            }

            res.render(CONTROLLER_NAME + '/profile', { user: data.user[0], playlists: data.playlists, isAuth: isAuth })
        })
    },
    getUpdateProfile: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/update')
    }
}