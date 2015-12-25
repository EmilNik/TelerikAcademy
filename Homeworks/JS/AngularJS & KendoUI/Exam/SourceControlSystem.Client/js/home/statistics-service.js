(function() {
    'use strict';

    function statistics($q, data) {

        var allStatistics;

        function getStats() {
            if (allStatistics) {
                return $q.when(allStatistics);
            }
            else {
                return data.get('api/statistics')
                    .then(function (stats) {
                        allStatistics = stats;
                        return allStatistics;
                    });
            }
        }

        return {
            getStats: getStats
        };
    }

    angular.module('myApp.services')
        .factory('statistics', ['$q', 'data', statistics]);
}());