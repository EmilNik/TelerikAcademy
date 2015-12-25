(function () {
    'use strict';

    function CommitsController($location, commits, identity, notifier) {
        var vm = this;
        vm.identity = identity;
        vm.request = {
            page: 1
        };

        vm.prevPage = function () {
            if (vm.request.page === 1) {
                return;
            }

            vm.request.page--;
            vm.filterCommits();
        };

        vm.nextPage = function () {
            if (!vm.commits || vm.commits.length === 0) {
                return;
            }

            vm.request.page++;
            vm.filterCommits();
        };

        vm.filterCommits = function () {
            commits.filterProjects(vm.request)
                .then(function (filteredCommits) {
                    vm.projects = filteredCommits;
                });
        };

        commits.getPublicCommits()
            .then(function (publicCommits) { 
                vm.commits = publicCommits;
            });

        vm.createCommit = function (newCommit) {
            commits.createCommit(newCommit)
                .then(function () {

                    notifier.success('Commit created');
                    $location.path('/commits/');
                });
        };
    }

    angular.module('myApp.controllers')
        .controller('CommitsController', ['$location', 'commits', 'identity', 'notifier', CommitsController]);
}());