var Playlist = require('mongoose').model('Playlist'),
    constants = require('../common/constants');

var cache = {
    expires: undefined,
    data: undefined
};

var homePageCahce = {
    expires: undefined,
    data: undefined
};

module.exports = {
    create: function (playlist, user, callback) {
        if (constants.categories.indexOf(playlist.category) < 0) {
            callback('Invalid category!');
            return;
        }

        playlist.creator = user.username;
        playlist.date = new Date();

        Playlist.create(playlist, callback);
    },
    public: function (page, pageSize, category, callback) {
        page = page || 1;
        pageSize = pageSize || 10;

        if (category) {
            Playlist
                .find({
                    $and: [
                        { 'category': category }
                    ]
                }).sort({
                    date: 'desc'
                })
                .limit(pageSize)
                .skip((page - 1) * pageSize)
                .exec(function (err, foundPlaylists) {
                    if (err) {
                        callback(err);
                        return;
                    }

                    Playlist.count().exec(function (err, numberOfPlaylists) {
                        var data = {
                            playlists: foundPlaylists,
                            currentPage: page,
                            pageSize: pageSize,
                            total: numberOfPlaylists
                        };

                        cache.data = data;
                        cache.expires = new Date() + 10;
                        callback(err, data);
                        return;
                    });
                })
        }

        if (page == 1 && cache.expires && cache.expires < new Date()) {
            callback(null, cache.data);
            return;
        }

        Playlist
            .find({
                $and: [
                    { 'isPublic': true }
                ]
            })
            .sort({
                date: 'desc'
            })
            .limit(pageSize)
            .skip((page - 1) * pageSize)
            .exec(function (err, foundPlaylists) {
                if (err) {
                    callback(err);
                    return;
                }

                Playlist.count().exec(function (err, numberOfPlaylists) {
                    var data = {
                        playlists: foundPlaylists,
                        currentPage: page,
                        pageSize: pageSize,
                        total: numberOfPlaylists
                    };

                    cache.data = data;
                    cache.expires = new Date() + 10;
                    callback(err, data);
                    return;
                });
            })
    },
    findById: function (id, callback) {
        Playlist
            .find({ '_id': id }, function (err, playlist) {
                callback(err, playlist);
                return;
            })
    },
    postVideoURL: function (id, videoURL, callback) {
        Playlist.findOne({ '_id': id }, function (err, playlist) {
            if (err) {
                callback(err, playlist);
                return;
            }
            var url = videoURL.replace("watch?v=", "v/")
            var playlistURLs = playlist.videoURLs;
            playlistURLs.push(url);

            playlist.update({ 'videoURLs': playlistURLs }, function (err) {
                if (err) {
                    callback(err, playlist);
                    return;
                }
            })

            callback(err, playlist);
        })
    },
    addView: function (id, callback) {
        Playlist.findOne({ '_id': id }, function (err, playlist) {
            if (err) {
                callback(err, playlist);
                return;
            }

            var playlistViews = playlist.views || 0;
            playlistViews += 1;
            playlist.update({ 'views': playlistViews }, function (err, playlist) {
                if (err) {
                    callback(err, playlist);
                    return;
                }
            })

            callback(err, playlist);
        });
    },
    rate: function (id, rate, callback) {
        Playlist.findOne({ '_id': id }, function (err, playlist) {
            if (err) {
                callback(err, playlist);
                return;
            }

            var allRatings = playlist.allRatings;
            allRatings.push(rate);

            var sum = 0;
            for (var i = 0, len = allRatings.length; i < len; i++) {
                sum += allRatings[i];
            }
            var avrg = sum / allRatings.length;
            avrg = avrg.toFixed(2);

            playlist.update({ 'rating': avrg, 'allRatings': allRatings }, function (err) {
                if (err) {
                    callback(err, playlist);
                    return;
                }
            })
            Playlist.findOne({ '_id': id }, function (err, playlist) {
                callback(err, playlist);
                return;
            })
        })
    },
    comment: function (id, comment, username, callback) {
        Playlist.findOne({ '_id': id }, function (err, playlist) {
            if (err) {
                callback(err, playlist);
                return;
            }
            var newComment = {
                username: username,
                content: comment
            };

            var comments = playlist.comments;
            comments.push(newComment);

            playlist.update({ 'comments': comments }, function (err) {
                if (err) {
                    callback(err, playlist);
                    return;
                }
            })

            callback(err, playlist);
        })
    },
    getHomePage: function (callback) {
        if (cache.expires && cache.expires < new Date()) {
            callback(null, cache.data);
            return;
        }

        Playlist
            .find({
                $and: [
                    { 'isPublic': true }
                ]
            })
            .sort({
                views: 'desc'
            })
            .limit(8)
            .exec(function (err, foundPlaylists) {
                if (err) {
                    callback(err);
                    return;
                }

                Playlist.count().exec(function (err, numberOfPlaylists) {
                    var data = {
                        playlists: foundPlaylists
                    };

                    homePageCahce.data = data;
                    homePageCahce.expires = new Date() + 10;
                    callback(err, data);
                    return;
                });
            })
    },
    sortBy: function (category, rate, callback) {
        if (category) {
            Playlist
                .find({
                    $and: [{
                        category: category
                    }]
                })
                .limit(10)
                .exec(function (err, foundPlaylists) {
                    foundPlaylists.sort(function (a, b) {
                        if (rate) {
                            return b.rating - a.rating;
                        }
                        return b.date - a.date;
                    });

                    var data = {
                        playlists: foundPlaylists
                    };

                    callback(err, data);
                    return;
                })
        } else {
            Playlist
                .find({})
                .limit(10)
                .exec(function (err, foundPlaylists) {
                    foundPlaylists.sort(function (a, b) {
                        if (rate) {
                            return b.rate - a.rate;
                        }
                        return b.date - a.date;
                    });

                    var data = {
                        playlists: foundPlaylists
                    };

                    callback(err, data);
                    return;
                })
        }
    },
    deletePlaylist: function (id, callback) {
        Playlist
            .find({
                '_id': id
            })
            .remove(function (err) {
                if (err) {
                    console.log(err)
                }
            });
    },
    deleteVideo: function (id, deleteUrl, callback) {
        var urls = [];

        Playlist
            .find({
                '_id': id
            })
            .exec(function (err, playlist) {
                urls = playlist[0].videoURLs;
                urls.forEach(function (url) {
                    if (url == deleteUrl) {
                        urls.remove(url);
                        return;
                    }
                }, this);
                console.log('>>>>>>>>>>>>>>>>>>>>>>>' + urls)
return;
                playlist.update({ 'videURLs': urls }, function (err) {
                    if (err) {
                        callback(err, playlist);
                        return;
                    }
                })
            });
    }
}