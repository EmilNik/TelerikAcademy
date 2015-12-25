(function () {
    'use strict';

    function ProjectsController($scope, projects, identity) {
        var vm = this;
        vm.filterApplied = false;
        vm.identity = identity;
        vm.request = {
            page: 1
        };

        vm.prevPage = function () {
            if (vm.request.page === 1) {
                return;
            }

            vm.request.page--;
            vm.filterProjects();
        };

        vm.nextPage = function () {
            if (!vm.projects || vm.projects.length === 0) {
                return;
            }

            vm.request.page++;
            vm.filterProjects();
        };

        vm.filterProjects = function () {
            vm.filterApplied = true;
            projects.filterProjects(vm.request)
                .then(function (filteredProjects) {
                    vm.projects = filteredProjects;
                });
        };

        if (identity.isAuthenticated()) {
            if (vm.filterApplied){
                projects.filterProjects(vm.request)
                .then(function (filteredProjects) {
                    vm.projects = filteredProjects;
                });
            } else {
                projects.getAllProjects()
                .then(function (allProjects) { 
                    vm.projects = allProjects;
                });
            }
            
        } else {
            projects.getPublicProjects()
            .then(function (publicProjects) { 
                vm.projects = publicProjects;
            });
        }
    }

    angular.module('myApp.controllers')
        .controller('ProjectsController', ['$scope', 'projects', 'identity', ProjectsController]);
}());