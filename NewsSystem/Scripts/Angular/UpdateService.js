(function () {
    "use strict";

    var updateService = function ($resource) {


        return $resource("http://localhost:3989/Api/Upload/Update/", {},
        {

            query: { method: 'POST', isArray: false }
        }

            );
    }
    angular.module("App").service("updateService", ["$resource", updateService]);

}());