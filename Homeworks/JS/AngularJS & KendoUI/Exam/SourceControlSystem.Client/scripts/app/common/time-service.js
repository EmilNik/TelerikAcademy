(function () {
    'use strict';

    function timeService(moment) {
        return {
            fromNow: function (time) {
                return moment(time).fromNow()
            }
        };
    }

    angular
        .module('myApp.services')
        .factory('moment', ['moment', timeService]);
}());