(function () {
    'use strict';

    function notifierService(toastr) {
        toastr.options.positionClass = 'toast-bottom-right';
        toastr.options.preventDuplicates = true;
        toastr.options.closeButton = true;
        toastr.options.closeMethod = 'fadeOut';
        toastr.options.timeOut = 1000;

        return {
            success: function (msg) {
                toastr.success(msg);
            },
            warning: function (msg) {
                toastr.warning(msg);
            },
            error: function (msg) {
                toastr.error(msg);
            }
        };
    };

    angular
        .module('myApp.services')
        .factory('notifier', ['toastr', notifierService]);
}());