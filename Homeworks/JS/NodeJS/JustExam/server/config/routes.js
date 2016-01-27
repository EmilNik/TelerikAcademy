var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function (app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.logout);
    
    app.get('/playlists/create', auth.isAuthenticated, controllers.playlists.getCreate);
    app.post('/playlists/create', auth.isAuthenticated, controllers.playlists.postCreate);

    app.get('/playlists/public', controllers.playlists.getPublic);
    app.post('/playlists/public', controllers.playlists.sortBy);
    
    app.get('/playlists/details/:id', auth.isAuthenticated, controllers.playlists.getById);
    app.post('/playlists/details/:id', auth.isAuthenticated, controllers.playlists.postById);
    
    app.get('/profiles/update', auth.isAuthenticated, controllers.profiles.getUpdateProfile)
    app.get('/profiles/:username', auth.isAuthenticated, controllers.profiles.getProfile)

    app.get('/', controllers.playlists.getHomePage);
    app.post('/deletePlaylist', controllers.playlists.deletePlaylist);
    app.post('/deleteVideo', controllers.playlists.deleteVideo);

    app.get('*', function (req, res) {
        res.render('index');
    });
};