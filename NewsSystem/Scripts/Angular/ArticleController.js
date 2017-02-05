(function () {
    "use strict";

    var controller = function (articleService, $scope, localStorageService, deleteService, likesService, saveService, updateService) {

        var model = this;

        model.data = {
            title: "",
            message: "",
            date: "",
            userId: localStorageService.get("userId")
    }


        $scope.hasResult = false;
        $scope.hasError = false;


        $scope.showAdd = false;
        $scope.showAddtable = function () {

            if ($scope.showAdd === false) {
                $scope.showAdd = true;
            } else {
                $scope.showAdd = false;
            }
           
        }


        $scope.output = [];
        $scope.delete = [];
   

        var init = function() {
            var userid = (localStorageService.get("userId"));
            $scope.UserName = (localStorageService.get("userName"));
            $scope.canPubish = (localStorageService.get("canPublishArticles"));
            $scope.NumberOfLikes = (localStorageService.get("NumberOfLikes"));
            articleService.query({ UserId: userid })
                .$promise.then
                (
                    function(response) {
                        $scope.output = response;
                     
                        $scope.hasResult = true;
                        $scope.hasError = false;


                    },
                    function(errorResponse) {
                        $scope.errorMessage = errorResponse.data;
                        $scope.hasError = true;
                        $scope.hasResult = false;
                    }
                );

        }

      
        var deleteArticle = function (articleId) {
            deleteService.query({ articleId: articleId })
                .$promise.then
                (
                    function (response) {
                        $scope.delete = response;
                        alert("Deleted");
                        init();
                    });

        }

        $scope.deleteArticle = deleteArticle;


        $scope.readOnly = true;
        $scope.editmode = false;

        var edit = function() {
            
            if ($scope.readOnly === true) {
                
                $scope.readOnly = false;
                $scope.editmode = true;
            } else {
                $scope.readOnly = true;
                $scope.editmode = false;
            }
        }
   
        $scope.edit = edit;


      

        var saveUpdate = function (atricle) {

            updateService.query(atricle)
                .$promise.then
                (
                    function (response) {
                        $scope.readOnly = false;
                        edit();
                        init();
                      
                       
                    });


        }

        $scope.SaveUpdate = saveUpdate;


        var likeArticle = function (articleId, userId) {

            if ($scope.NumberOfLikes <= 0) {
                
                alert("Sorry, you are out of likes");
            }
            else
            {


                likesService.query({ articleId: articleId, userid: userId })
                    .$promise.then
                    (
                        function(response) {
                            init();
                        });
            }

        }

        $scope.likeArticle = likeArticle;

        var saveArticle = function () {
            var data = model.data; 

            saveService.query(data)
                .$promise.then
                (
                    function (response) {
                        $scope.showAdd = true;
                        $scope.showAddtable();
                        init();
                        alert("Success");
                    });


        }

        $scope.saveArticle = saveArticle;










        init();
    }







    angular.module("App").controller("ArticleController", ["articleService", "$scope", "localStorageService","deleteService","likesService","saveService","updateService", controller]);
}());