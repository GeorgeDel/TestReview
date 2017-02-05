(function () {
    "use strict";

    var articleService = function($resource) {

        return $resource("http://localhost:3989/Api/Upload/ArticlesByUser?", {},
            {
                query: { method: "GET", isArray: true }
            }
        );
    }
    angular.module("App").service("articleService", ["$resource", articleService]);
}());