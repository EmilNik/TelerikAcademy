(function () {
    'use strict';

    function FilterProjectsController($scope, projectsService, moment, notifier) {
        var vm = this;
        $scope.moment = moment;

        vm.getAll = function (params) {
            projectsService.getAll(params)
                .then(function (res) {
                    vm.projects = res;
                    console.log(vm.projects);
                }, function (err) {
                    notifier.error(err.Message);
                })
        }

    }

    angular.module('myApp.controllers')
        .controller('FilterProjectsController', ['$scope', 'projectsService', 'moment','notifier', FilterProjectsController]);
})();