(function () {
    'use strict';

    function HomeController($scope, notifier, projectsService, moment, identity, statistics) {
        var vm = this;
        $scope.identity = identity;
        $scope.moment = moment;

        projectsService.get()
            .then(function (res) {
                vm.projects = res
            });

        statistics.get()
            .then(function (res) {
                vm.statistics = res;
            })
    }

    angular.module('myApp.controllers')
        .controller('HomeController', ['$scope', 'notifier', 'projectsService', 'moment', 'identity', 'statistics', HomeController]);
})();