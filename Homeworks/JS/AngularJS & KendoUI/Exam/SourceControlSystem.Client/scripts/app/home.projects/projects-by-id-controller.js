(function () {
    'use strict';

    function ProjectsByIdController($scope, $routeParams, projectsService, moment, notifier) {
        var vm = this;
        vm.moment = moment;

        if ($routeParams.id) {
            projectsService.getProjectById($routeParams.id)
                .then(function (response) {
                    vm.projectById = response;
                    vm.projectById.added = moment(vm.projectById.CreatedOn).fromNow();
                })
        }

        vm.addCollaborator = function (collabrotaro) {
            projectsService.addCollaborator($routeParams.id, collabrotaro.toString())
                .then(function () {
                    notifier.success("Collaborator added successfully!")
                }, function (err) {
                    notifier.error(err.Message)
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('ProjectsByIdController', ['$scope', '$routeParams', 'projectsService', 'moment', 'notifier', ProjectsByIdController]);
})();