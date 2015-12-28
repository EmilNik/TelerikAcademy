(function () {
    'use strict';

    var statistics = function ($q, data) {
        function get() {
            var defered = $q.defer();
            data.get('api/statistics')
            .then(function (res) {
                defered.resolve(res);
            }, function (err) {
                defered.reject(res);
            })

            return defered.promise;
        }

        return {
            get: get
        }
    }

    angular.module('myApp.services')
        .factory('statistics', ['$q', 'data', statistics]);
}());