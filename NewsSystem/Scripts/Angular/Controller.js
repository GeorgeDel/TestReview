(function () {
    "use strict";

    var controller = function (loginService, $scope, $window, localStorageService) {


        var model = this;

        model.data = {
            UserName :"" ,
            password:""
            }


   
        $scope.hasResult = false;
        $scope.hasError = false;

        model.result = {
            output: []
        };

        model.getNumbers = function () {
            loginService.query({ UserName: model.data.UserName, password: model.data.password })
                .$promise.then
                (
                    function (response) {
                        $scope.output = response;
                        $scope.hasResult = true;
                        $scope.hasError = false;

                        localStorageService.set("userId", response.UserId);
                        localStorageService.set("userName", response.UserName);
                        localStorageService.set("canPublishArticles", response.CanPublishArticles);
                        localStorageService.set("NumberOfLikes", response.NumberOfLikes);
                        $window.location.href = "/Home/View";

                    },
                    function (errorResponse) {
                        $scope.errorMessage = errorResponse.data;
                        $scope.hasError = true;
                        $scope.hasResult = false;
                    }
                );
        }
    }
    angular.module("App").controller("loginController", ["loginService", "$scope", "$window","localStorageService", controller]);
}());