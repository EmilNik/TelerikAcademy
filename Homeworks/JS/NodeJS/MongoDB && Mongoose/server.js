var chatDb = require('./chatDb.js');

chatDb.registerUser({ user: 'DonchoMinkov', pass: '123456q' });
chatDb.registerUser({ user: 'NikolayKostov', pass: '123456q' })

chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
});

chatDb.getMessages({
    with: 'DonchoMinkov',
    and: 'NikolayKostov'
});