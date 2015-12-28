(function () {
    'use strict';

    var commitsService = function projectsService($q, data) {

        function getCommits() {
            var defered = $q.defer();
            data.get('api/commits')
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(res);
                });

            return defered.promise;
        }

        return {
            get: getCommits
        };
    };

    angular
        .module('myApp.services')
        .factory('commitsService', ['$q', 'data', commitsService]);
}());