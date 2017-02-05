(function () {
    "use strict";

    var loginService = function ($resource) {
        

        return $resource("Api/login/GetUser/", {},
        {

            query: { method: 'GET', isArray: false  }
    }

            );


    }
    angular.module("App").service("loginService", ["$resource", loginService]);
}());