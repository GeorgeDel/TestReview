(function () {
    "use strict";

    var deleteService = function($resource) {


        return $resource("http://localhost:3989/Api/Upload/Delete/", {},
            {
                query: { method: 'GET', isArray: false }
            }
        );
    }
    angular.module("App").service("deleteService", ["$resource", deleteService]);

}());