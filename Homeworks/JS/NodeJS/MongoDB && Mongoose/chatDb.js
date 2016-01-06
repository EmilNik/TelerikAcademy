'use strict'

var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost:27017/ChatDb');

var User = mongoose.model('User', {
    user: {
        type: String,
        required: true,
        index: {
            unique: true
        }
    },
    pass: {
        type: String,
        required: true
    }
});

var Message = mongoose.model('Message', {
    from: {
        type: String,
        required: true
    },
    to: {
        type: String,
        required: true
    },
    text: {
        type: String,
        required: true
    }
});

function registerUser(userObj) {
    if (!userObj || typeof userObj !== 'object') {
        console.log('Invalid user');
        return;
    }

    var newUser = new User(userObj);
    newUser.save(function (err, addedUser) {
        if (err) {
            if (err.code == 11000) {
                console.log('There is already an user with this username!\n');
                return;
            }
            console.log(err + '\n');
            return;
        }

        console.log(addedUser.user + ' registered successfully!\n')
    });
}

function sendMessage(messageObj) {
    if (!messageObj || typeof messageObj !== 'object') {
        console.log('Invalid message\n');
        return;
    }

    var newMessage = new Message(messageObj);
    newMessage.save(function (err, addedMessage) {
        if (err) {
            return console.log(err.errmsg + '\n');
        }

        console.log('Message with ID ' + addedMessage._id + ' was sent successfully!\n')
    });
}

function getMessages(members) {
    if (!members ||
        typeof members !== 'object' ||
        !members.with ||
        !members.and) {
        console.log('Invalid user\n');
        return;
    }

    return Message.find()
        .where('from').in([members.with, members.and])
        .where('to').in([members.with, members.and])
        .exec(function (err, receivedMessages) {
            if (err) {
                console.log(err);
                return
            }
            console.log(receivedMessages.length + ' messages between ' + members.with + ' and ' + members.and + '.');
            console.log('All messages:');

            receivedMessages.forEach(function (message) {
                console.log('From: ' + message.from + '\t To: ' + message.to);
                console.log(message.text + '\n');
            }, this);
        })
}

module.exports = {
    registerUser: registerUser,
    sendMessage: sendMessage,
    getMessages: getMessages
};