(function() {
    'use strict';

    function allProjects() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/all-projects-directive.html'
        };
    }

    angular.module('myApp.directives')
        .directive('allProjects', [allProjects]);
}());