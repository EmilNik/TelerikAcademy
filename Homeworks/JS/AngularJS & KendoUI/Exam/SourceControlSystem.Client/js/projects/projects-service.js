(function(){
    'use strict';

    function projects(data) {
        var PROJECTS_URL = 'api/projects';

        function getPublicProjects() {
            return data.get(PROJECTS_URL);
        }

        function getProjectDetails(id){
            return data.get(PROJECTS_URL + '/' + id);
        }

        function filterProjects(filters) {
            return data.get(PROJECTS_URL + '/all', filters);
        }

        function createProject(project) {
            return data.post(PROJECTS_URL, project);
        }

        function getAllProjects(){
            return data.get(PROJECTS_URL + '/all');
        }

        return {
            getPublicProjects: getPublicProjects,
            createProject: createProject,
            filterProjects: filterProjects,
            getProjectDetails: getProjectDetails,
            getAllProjects: getAllProjects
        };
    }

    angular.module('myApp.services')
        .factory('projects', ['data', projects]);
}());