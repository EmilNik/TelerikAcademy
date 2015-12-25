(function () {
    'use strict';

    function collaborators(data) {
        function getCollaborators(projectId) {
            return data.get('api/projects/collaborators/' + projectId);
        }

        return {
            getCollaborators: getCollaborators
        };
    }

    angular.module('myApp.services')
        .factory('collaborators', ['data', collaborators]);
}());