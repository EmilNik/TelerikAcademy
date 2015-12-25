(function(){
    'use strict';

    function licenses(data) {
        var LICENSES_URL = 'api/licenses';

        function getLicenses() {
            return data.get(LICENSES_URL);
        }

        return {
            getLicenses: getLicenses
        };
    }

    angular.module('myApp.services')
        .factory('licenses', ['data', licenses]);
}());