(function () {
    'use strict';

    function data($http, $q, baseUrl) {

        function get(url, params) {
            var defered = $q.defer();

            $http
                .get(baseUrl + url, {
                    params: params
                })
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defered.reject(err.data);
                });

            return defered.promise;
        }

        function post(url, data) {
            var defered = $q.defer();

            $http
                .post(baseUrl + url, data)
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defered.reject(err.data);
                });

            return defered.promise;
        }

        function put(url, data) {
            var defered = $q.defer();

            $http
                .put(baseUrl + url, '"' + data.collaborator + '"')
                .then(function (response) {
                    defered.resolve(response.data);
                }, function (err) {
                    defered.reject(err.data);
                });

            return defered.promise;
        }

        return {
            get: get,
            post: post,
            put: put
        }
    }

    angular.module('myApp.services')
        .factory('data', ['$http', '$q', 'baseUrl', data]);
}());