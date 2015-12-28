(function () {
    'use strict';

    function LoginController($scope, $location, notifier, identity, auth) {
        $scope.identity = identity;

        $scope.login = function (user, loginForm) {
            if (loginForm.$valid) {
                auth.login(user)
                    .then(function () {
                        // Redirect to home page
                        notifier.success("Login successful!")
                        $location.path('/');
                    }, function (err) {
                        notifier.error("Username?Password not valid!")
                    });
            }
            else {
                notifier.error('Username and password are required fields!')
            }
        }

        $scope.logout = function () {
            auth.logout()
            notifier.success('Successful logout!');
            if ($scope.user) {
                $scope.user.email = '';
                $scope.user.username = '';
                $scope.user.password = '';
            }

            $scope.loginForm.$setPristine();
            $location.path('/');
        }
    }

    angular.module('myApp.controllers')
        .controller('LoginController', ['$scope', '$location', 'notifier', 'identity', 'auth', LoginController]);
}());