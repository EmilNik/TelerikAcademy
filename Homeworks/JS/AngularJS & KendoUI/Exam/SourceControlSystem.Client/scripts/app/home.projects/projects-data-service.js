(function () {
    'use strict';

    var projectsService = function projectsService($q, data) {
        var projects;

        function getProjects() {
            var defered = $q.defer();
            data.get('api/projects')
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(res);
                });

            return defered.promise;
        }

        function addProject(project) {
            var defered = $q.defer();
            data.post('api/projects', project)
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(err);
                })

            return defered.promise;
        }

        function getProject(id) {
            var defered = $q.defer();
            data.get('api/projects/' + id)
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(res);
                })

            return defered.promise;
        }

        function getLicenses() {
            var defered = $q.defer();
            data.get('api/licenses')
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(res);
                })

            return defered.promise;
        }

        function getProjectById(id) {
            var defered = $q.defer();
            data.get('api/projects/' + id)
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(res);
                })

            return defered.promise;
        }

        function addCollaborator(id, collaborator) {
            var defered = $q.defer();
            data.put('api/projects/' + id, { collaborator })
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(err);
                })

            return defered.promise;
        }

        function getAll(params) {
            var defered = $q.defer();
            var url = 'api/projects/all?';
            if (!params.Page) {
                params.Page = 1;
            }

            if (!params.PageSize) {
                params.PageSize = 10;
            }

            url += 'page=' + params.Page + '&';
            url += 'pagesize=' + params.PageSize;

            if (params.Filter) {
                url += '&';
                url += 'filter=' + params.Filter || '';
            }

            if (params.OrderType) {
                url += '&';
                url += 'orderType=' + params.OrderType || '';
            }

            if (params.OnlyPublic) {
                url += '&';
                url += 'onlyPublic=' + params.OnlyPublic || false;
            }
            if (params.ByUser) {
                url += '&';
                url += 'byuser=' + params.ByUser || '';
            }

            data.get(url)
                .then(function (res) {
                    defered.resolve(res);
                }, function (err) {
                    defered.reject(err);
                })

            return defered.promise;
        }

        return {
            get: getProjects,
            addProject: addProject,
            getProject: getProject,
            getLicenses: getLicenses,
            getProjectById: getProjectById,
            addCollaborator: addCollaborator,
            getAll: getAll
        };
    };

    angular
        .module('myApp.services')
        .factory('projectsService', ['$q', 'data', projectsService]);
}());