var UsersController = require('./UsersController'),
    PlaylistsController = require('./PlaylistsController'),
    ProfilesController = require('./ProfilesController');

module.exports = {
    users: UsersController,
    playlists: PlaylistsController,
    profiles: ProfilesController
};