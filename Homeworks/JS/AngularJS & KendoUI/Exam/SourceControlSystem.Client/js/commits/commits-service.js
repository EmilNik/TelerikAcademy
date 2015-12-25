(function () {
    'use strict';

    function commits(data) {
        function getPublicCommits() {
            return data.get('api/commits');
        }

        function getCommitDetails(id){
            return data.get('api/commits/' + id);
        }

        function getCommitsByProject(projectId){
            return data.get('api/commits/byproject/' + projectId);
        }

        function createCommit(commit) {
            return data.post('api/commits', commit);
        }

        return {
            getPublicCommits: getPublicCommits,
            getCommitDetails: getCommitDetails,
            getCommitsByProject: getCommitsByProject,
            createCommit: createCommit
        };
    }

    angular.module('myApp.services')
        .factory('commits', ['data', commits]);
}());