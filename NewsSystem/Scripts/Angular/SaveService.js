(function () {
    "use strict";

    var saveService = function ($resource) {


        return $resource("http://localhost:3989/Api/Upload/Save/", {},
        {

            query: { method: 'POST', isArray: false }
        }

            );


    }
    angular.module("App").service("saveService", ["$resource", saveService]);

}());