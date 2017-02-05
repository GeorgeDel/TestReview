(function () {
    "use strict";

    var likesService = function ($resource) {


        return $resource("http://localhost:3989/Api/Upload/UpdateLikes/", {},
        {

            query: { method: 'GET', isArray: false }
        }

            );


    }
    angular.module("App").service("likesService", ["$resource", likesService]);

}());