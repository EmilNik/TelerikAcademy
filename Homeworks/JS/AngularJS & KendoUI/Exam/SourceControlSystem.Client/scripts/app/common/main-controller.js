(function () {
    'use strict';

    function MainController(identity, auth) {
        var vm = this;

        waitForLogin();

        vm.logout = function () {
            vm.globallySetCurrentUser = undefined;
            auth.logout();
            waitForLogin();
        };

        function waitForLogin() {
            identity.getUser()
                .then(function (user) {
                    vm.globallySetCurrentUser = user;
                    console.log(user);
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('MainController', ['identity', 'auth', MainController]);
})();