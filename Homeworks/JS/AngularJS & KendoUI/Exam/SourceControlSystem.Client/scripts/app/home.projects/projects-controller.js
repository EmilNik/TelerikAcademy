(function () {
    'use strict';

    function ProjectsController($routeParams, notifier, projectsService) {
        var vm = this;
        vm.addProject = function (project, addProjectForm) {
            if (addProjectForm.$valid) {
                projectsService.addProject(project)
                    .then(function (res) {
                        notifier.success('Project added successfully!')
                    }, function (err) {
                        notifier.error(err.Message)
                    });
            }
        }

        projectsService.getLicenses()
            .then(function (response) {
                vm.licenses = response;
            })

        if ($routeParams.id) {
            projectsService.getProjectById($routeParams.id)
                .then(function (response) {
                    vm.projectById = response;
                })
        }

        vm.getProject = function (id) {
            projectsService.getProject(id);
        }
    }

    angular.module('myApp.controllers')
        .controller('ProjectsController', ['$routeParams', 'notifier', 'projectsService', ProjectsController]);
})();