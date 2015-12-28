(function () {
    'use strict';

    function RegisterController($location, auth, notifier) {
        var vm = this;

        vm.register = function (user, registerForm) {
            if (registerForm.$valid) {
                auth.register(user)
                    .then(function () {
                        // Redirect to login
                        notifier.success("Register successful!")
                        $location.path('/');
                    }, function (err) {
                        notifier.error("User already exists!")
                    });
            }
        }
    }

    angular.module('myApp.controllers')
        .controller('RegisterController', ['$location', 'auth', 'notifier', RegisterController]);
})();