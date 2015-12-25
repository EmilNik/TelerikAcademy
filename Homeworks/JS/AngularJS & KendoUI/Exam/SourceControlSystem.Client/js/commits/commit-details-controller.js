(function () { 
    'use strict';

    function CommitDetailsController($routeParams, $location, identity, notifier, commits) {
        if (!identity.isAuthenticated()) {
            notifier.error('Please, login or register!');
            $location.path('/unauthorized');
        }

        var vm = this;
        vm.id = $routeParams.id; // $routeParams['id']

        commits.getCommitDetails(vm.id)
            .then(function (commit) { 
                vm.currentCommit = commit;
            });
    }

    angular.module('myApp.controllers')
        .controller('CommitDetailsController', ['$routeParams', '$location', 'identity', 'notifier', 'commits', CommitDetailsController]);
}());