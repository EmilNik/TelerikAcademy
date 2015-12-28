(function () {
    'use strict';

    function UnauthorizedController() {
        var vm = this;

        console.log('UnauthorizedController')
    }

    angular.module('myApp.controllers')
        .controller('UnauthorizedController', [UnauthorizedController]);
})();