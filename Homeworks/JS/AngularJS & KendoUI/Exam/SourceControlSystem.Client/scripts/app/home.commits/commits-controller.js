(function () {
    'use strict';

    function CommitsController(notifier, commitsService) {
        var vm = this;

        commitsService.get()
            .then(function (res) {
                vm.commits = res;
                console.log(vm.commits)
            })
    }

    angular.module('myApp.controllers')
        .controller('CommitsController', ['notifier', 'commitsService', CommitsController]);
})();