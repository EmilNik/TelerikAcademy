var mongoose = require('mongoose');

var requiredMessage = '{PATH} is required';

module.exports.init = function () {
    var playlistSchema = mongoose.Schema({
        title: { type: String, required: requiredMessage },
        description: { type: String, required: requiredMessage },
        videoURLs: { type: [String] },
        category: { type: String, required: requiredMessage },
        creator: { type: String, required: requiredMessage },
        date: { type: Date, required: requiredMessage },
        isPublic: { type: Boolean, required: requiredMessage },
        rating: { type: Number },
        allRatings: { type: [Number] },
        comments: [{
            username: String,
            content: String,
            date: Date
        }],
        views: { type: Number, default: 0 }
    });

    var Playlist = mongoose.model('Playlist', playlistSchema);
};
