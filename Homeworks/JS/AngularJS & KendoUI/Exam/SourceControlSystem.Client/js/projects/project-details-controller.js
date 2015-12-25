(function () { 
    'use strict';

    function ProjectDetailsController($routeParams, $location, commits, collaborators, identity, notifier, projects) {
        if (!identity.isAuthenticated()) {
            notifier.error('Please, login or register!');
            $location.path('/unauthorized');
        }

        var vm = this;
        vm.id = $routeParams.id; // $routeParams['id']

        vm.sortBy = '';

        projects.getProjectDetails(vm.id)
            .then(function (project) { 
                vm.currentProject = project;
            });

        commits.getCommitsByProject(vm.id)
            .then(function(commits){
                vm.commits = commits;
            });

        collaborators.getCollaborators(vm.id)
            .then(function(collaborators){
                vm.collaborators = collaborators;
            });

        vm.filterMine = function(){
            vm.commits = vm.commits.filter(function(item){
                item.UserName === identity.currentUser;
            });
        };

        vm.sortByUser = function(){
            vm.sortBy = 'UserName';
        };

        vm.sortByDate = function(){
            vm.sortBy = 'CreatedOn';
        };

    }

    angular.module('myApp.controllers')
        .controller('ProjectDetailsController', ['$routeParams', '$location', 'commits', 'collaborators','identity', 'notifier', 'projects', ProjectDetailsController]);
}());