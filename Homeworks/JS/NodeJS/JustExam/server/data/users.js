var User = require('mongoose').model('User');

module.exports = {
    create: function (user, callback) {
        User.create(user, callback);
    },
    rate: function (username, rate, callback) {
        User.findOne({ 'username': username }, function (err, user) {
            if (err) {
                callback(err, user);
                return;
            }

            var allRatings = user.allRatings;
            allRatings.push(rate);

            var sum = 0;
            for (var i = 0, len = allRatings.length; i < len; i++) {
                sum += allRatings[i];
            }
            var avrg = sum / allRatings.length;
            avrg = avrg.toFixed(2);

            user.update({ 'rating': avrg, 'allRatings': allRatings }, function (err) {
                if (err) {
                    callback(err, user);
                    return;
                }
            })
        })
    }
};