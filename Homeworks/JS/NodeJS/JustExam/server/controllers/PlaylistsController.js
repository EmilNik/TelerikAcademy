var playlists = require('../data/playlists'),
    users = require('../data/users'),
    constants = require('../common/constants');

var CONTROLLER_NAME = 'playlists';

module.exports = {
    getCreate: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/create', {
            categories: constants.categories
        });
    },
    postCreate: function (req, res, next) {
        var playlist = req.body;
        var user = req.user;

        playlists.create(
            playlist,
            { username: user.username },
            function (err, playlist) {
                if (err) {
                    var data = {
                        categories: constants.categories,
                        errorMessage: err
                    };
                    res.render(CONTROLLER_NAME + '/create', data);
                } else {
                    res.redirect('/playlists/details/' + playlist._id)
                }
            })
    },
    getPublic: function (req, res, next) {
        var page = req.query.page;
        var pageSize = req.query.pageSize;
        var category = req.query.category;

        playlists.public(page, pageSize, category, function (err, data) {
            res.render(CONTROLLER_NAME + '/public', { categories: constants.categories, data: data });
            return;
        });
    },
    getById: function (req, res, next) {
        var id = req.params.id;
        var user = req.user;
        var isAuth;

        playlists.findById(id, function (err, playlist) {
            if (user.username == playlist[0].creator) {
                isAuth = true;
            } else {
                playlists.addView(id, function (err, playlist) {
                    if (err) {
                        res.render(CONTROLLER_NAME + '/details', { playlist: playlist[0], errorMessage: err, isAuth: isAuth })
                        return;
                    }
                    return;
                });
            }

            res.render(CONTROLLER_NAME + '/details', { playlist: playlist[0], errorMessage: err, isAuth: isAuth })
        })
    },
    postById: function (req, res, next) {
        var id = req.params.id;
        var user = req.user;
        var isAuth;

        var videoURL = req.body.videoURL;
        var rate = req.body.rate;
        var comment = req.body.comment;
        if (videoURL) {
            playlists.postVideoURL(id, videoURL, function (err, playlist) {
                if (user.username == playlist.creator) {
                    isAuth = true;
                } else {
                    playlists.addView(id, function (err, playlist) {
                        if (err) {
                            res.render(CONTROLLER_NAME + '/details', { playlist: playlist, errorMessage: err, isAuth: isAuth })
                            return;
                        }
                    });
                }

                res.render(CONTROLLER_NAME + '/details', { playlist: playlist, errorMessage: err, isAuth: isAuth })
            });
        } else if (rate) {
            playlists.rate(id, rate, function (err, playlist) {
                if (user.username == playlist.creator) {
                    isAuth = true;
                } else {
                    playlists.addView(id, function (err, playlist) {
                        if (err) {
                            res.render(CONTROLLER_NAME + '/details', { playlist: playlist, errorMessage: err, isAuth: isAuth })
                            return;
                        }
                    });
                }
                users.rate(playlist.creator, rate, function (err, user) {
                    if (err) {
                        console.log(err)
                    }
                })

                res.render(CONTROLLER_NAME + '/details', { playlist: playlist, errorMessage: err, isAuth: isAuth })
            })
        } else if (comment) {
            playlists.comment(id, comment, user.username, function (err, playlist) {
                if (user.username == playlist.creator) {
                    isAuth = true;
                } else {
                    playlists.addView(id, function (err, playlist) {
                        if (err) {
                            res.render(CONTROLLER_NAME + '/details', { playlist: playlist, errorMessage: err, isAuth: isAuth })
                            return;
                        }
                    });
                }

                res.render(CONTROLLER_NAME + '/details', { playlist: playlist, errorMessage: err, isAuth: isAuth })
            })
        };
    },
    getHomePage: function (req, res, next) {
        playlists.getHomePage(function (err, playlists) {
            res.render(CONTROLLER_NAME + '/index', { playlists: playlists.playlists, errorMessage: err })
        })
    },
    sortBy: function (req, res, next) {
        var category = req.body.category;
        var rate = req.body.rate;
        var name = undefined;

        playlists.sortBy(category, rate, function (err, data) {
            res.render(CONTROLLER_NAME + '/public', { categories: constants.categories, data: data })
        })
    },
    deletePlaylist: function (req, res, next) {
        var id = req.body.id;
        playlists.deletePlaylist(id, function (err) {
            playlists.getHomePage(function (err, playlists) {
                res.render(CONTROLLER_NAME + '/index', { playlists: playlists.playlists, errorMessage: err })
            })
        })
    },
    deleteVideo: function (req, res, next) {
        var id = req.body.id;
        var url = req.body.videoURL;
        playlists.deleteVideo(id, url, function (err) {
            playlists.getHomePage(function (err, playlists) {
                res.render(CONTROLLER_NAME + '/index', { playlists: playlists.playlists, errorMessage: err })
            })
        })
    }
}