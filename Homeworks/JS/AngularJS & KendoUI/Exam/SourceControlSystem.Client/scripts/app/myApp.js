(function () {
    'use strict';

    function config($routeProvider, $locationProvider) {

        $locationProvider.html5Mode(true);

        var CONTROLLER_VIEW_NAME = 'vm';
        var VIEWS_TEMPLATES_COMMON_PATH = 'views/templates/';

        // Use this for resolve: to verify if user is logged in.
        var routeUserChecks = {
            authenticated: {
                authenticate: function (auth) {
                    return auth.isAuthenticated();
                }
            }
        };

        $routeProvider
            .when('/', {
                templateUrl: VIEWS_TEMPLATES_COMMON_PATH + 'home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_VIEW_NAME
            })
            .when('/unauthorized', {
                templateUrl: VIEWS_TEMPLATES_COMMON_PATH + 'home/unauthorised.html',
                controller: 'UnauthorizedController',
                controllerAs: CONTROLLER_VIEW_NAME
            })
            .when('/identity/register', {
                templateUrl: VIEWS_TEMPLATES_COMMON_PATH + 'identity/register.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_VIEW_NAME
            })
            .when('/identity/login', {
                templateUrl: VIEWS_TEMPLATES_COMMON_PATH + 'identity/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_VIEW_NAME
            })
            .when('/projects/add', {
                templateUrl: VIEWS_TEMPLATES_COMMON_PATH + 'projects/add.html',
                controller: 'ProjectsController',
                controllerAs: CONTROLLER_VIEW_NAME
            })
            .when('/projects/:id', {
                templateUrl: VIEWS_TEMPLATES_COMMON_PATH + 'projects/project.html',
                controller: 'ProjectsByIdController',
                controllerAs: CONTROLLER_VIEW_NAME
            })
            .when('/projects', {
                templateUrl: VIEWS_TEMPLATES_COMMON_PATH + 'projects/filterProjects.html',
                controller: 'FilterProjectsController',
                controllerAs: CONTROLLER_VIEW_NAME
            })
            .otherwise({ redirectTo: '/' });
    }

    var run = function run($http, $cookies, $rootScope, auth, notifier) {

        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                notifier.warning('Please log into your account first!');
                $location.path('/unauthorized');
            }
        });

        if (auth.isAuthenticated()) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $cookies.get('authentication');
        }
    };

    angular.module('myApp.services', []);
    angular.module('myApp.directives', []);
    angular.module('myApp.filters', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'myApp.controllers', 'myApp.directives', 'myApp.filters'])
        .config(['$routeProvider', '$locationProvider', config])
        // Edit this constant according to server URL
        .constant('baseUrl', 'http://spa.bgcoder.com/')
        .value('toastr', toastr)
        .value('jQuery', jQuery)
        .value('moment', moment)
        .run(['$http', '$cookies', '$rootScope', 'auth', 'notifier', run])
}());