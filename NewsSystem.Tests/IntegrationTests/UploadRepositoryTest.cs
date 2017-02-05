using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsSystem.Repository;

namespace NewsSystem.Tests.IntegrationTests
{

    [TestClass]
    public class UploadRepositoryTest
    {
        [TestMethod]
        public void Given_ArticleId_When_LoadedArticle_then_LoadArticle()
        {
            const int articleId = 2;
            var result = LoadArticleById(articleId);
            result.ArticleId.Should().Be(articleId);
        }

        [TestMethod]
        public void Given_UserId_When_LoadArticleForUser_Then_LoadArticles()
        {
            var user = LoadVaildUser();
            var articleRepository = new ArticleRepository();
            var article = articleRepository.GetArticleByUserId(user.UserId);
            article.Count.Should().BePositive();
        }


        [TestMethod]
        public void Given_UserIdAndArticleId_When_Liked_Then_RemovelikeFromUser()
        {

            const int articleId = 2;
            var article = LoadArticleById(articleId);
            var user = LoadVaildUser();
            var articleRepository = new ArticleRepository();

            var likes = user.NumberOfLikes;
            articleRepository.UpdateLikes(user.UserId, article.ArticleId);

            var userAfterLikedArticle = LoadVaildUser();
            userAfterLikedArticle.NumberOfLikes.Should().Be(likes - 1);

        }

        [TestMethod]
        public void Given_UserIdAndArticleId_When_liked_Then_AddLikeToArtcile()
        {
            var articleId = 2;
            var article = LoadArticleById(articleId);
            var articleRepository = new ArticleRepository();
            var user = LoadVaildUser();

            var liked = article.NumberOfLikes;
            articleRepository.UpdateLikes(user.UserId, article.ArticleId);
            var articleAfterLiked = articleRepository.GetArticleByArticleId(articleId);
            articleAfterLiked.NumberOfLikes.Should().Be(liked + 1);

        }


        [TestMethod]
        public void Given_NewArticle_When_Save_Then_SaveArticle()
        {
            var article = CreateNewArticle();

            var articleRepository = new ArticleRepository();
            var articleId = articleRepository.Save(article);
            var result = LoadArticleById(articleId);
            result.Should().NotBeNull();
        }

        [TestMethod]
        public void Given_Article_When_Delete_Then_DeleteArticle()
        {
            var article = CreateNewArticle();
            var articleRepository = new ArticleRepository();
            var articleId = articleRepository.Save(article);

            var result = articleRepository.GetArticleByArticleId(articleId);

            articleRepository.Delete(result.ArticleId);

            var result2 = articleRepository.GetArticleByArticleId(articleId);
            result2.Should().Be(null);

        }

        [TestMethod]
        public void Give_Article_when_Edit_Then_UpdateArticle()
        {
            const string updateTitle= "edited";

            var article = CreateNewArticle();
            var articleRepository = new ArticleRepository();
            var articleId = articleRepository.Save(article);

            var savedArticle = articleRepository.GetArticleByArticleId(articleId);

            savedArticle.Title = updateTitle;

            articleRepository.Update(savedArticle);

            var editArticle = articleRepository.GetArticleByArticleId(articleId);

            editArticle.Title = updateTitle;
        }



        [TestMethod]
        public void Given_UserIdAndArticleId_When_AddComments_Then_AddCommentToUser()
        {
            const string testingComment ="newCommetn";
            const int articleId = 2;
            var article = LoadArticleById(articleId);
   
            var articleRepository = new ArticleRepository();

            article.Comments = testingComment;


            articleRepository.UpdateComment(article);

            var userAfterLikedArticle = LoadArticleById(articleId);
            userAfterLikedArticle.Comments.Should().Be(testingComment);

        }



        private static Article CreateNewArticle()
        {
            var article = new Article
            {
                ArticleId = 10000,
                Body = "test",
                NumberOfLikes = 1,
                PublishDate = DateTime.UtcNow,
                Title = "UnitTestTest",
                UserId = 1
            };
            return article;
        }

        private static Article LoadArticleById(int articleId)
        {
            var articleRepository = new ArticleRepository();
            return articleRepository.GetArticleByArticleId(articleId);
        }

        private static User LoadVaildUser()
        {
            const string login = "george";
            const string password = "11";

            var userRepository = new UserRepository();
            return userRepository.GetUser(login, password);
        }
    }
}
