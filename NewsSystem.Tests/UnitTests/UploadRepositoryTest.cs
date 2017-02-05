using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsSystem.Controllers;
using NewsSystem.Interfaces;
using NewsSystem.Repository;

namespace NewsSystem.Tests.UnitTests
{
    [TestClass]
   public class UploadRepositoryTest
    {
        [TestMethod]
        public void Given_UserId_When_GetArticleByUserId_Then_ReturnArticle()
        {
            const int anyUserId = 1000;
            var article = CreateArticle();
            var atricleList = article;
            var mock = new Mock<IArticleRepository>();

            var request = new HttpRequestMessage(HttpMethod.Get, "Api/Upload/ArticlesByUser/");
    
            mock.Setup(article2 => article2.GetArticleByArticleId(anyUserId)).Returns(atricleList);
  
            var login = CreateController(request, mock.Object);      
            login.GetArticleByArticleId(anyUserId);

            mock.Verify(m => m.GetArticleByArticleId(anyUserId));
        }

          [TestMethod]
        public void Given_UserId_When_ArticlesByUser_Then_ReturnArticlesList()
        {
            const int anyUserId = 1000;
            var article = CreateArticle();
            var atricleList = new List<Article> { article };
            var mock = new Mock<IArticleRepository>();

            var request = new HttpRequestMessage(HttpMethod.Get, "Api/Upload/ArticlesByArticle/");

            mock.Setup(article2 => article2.GetArticleByUserId(anyUserId)).Returns(atricleList);

            var login = CreateController(request, mock.Object);
            login.GetArticleByUserId(anyUserId);

            mock.Verify(m => m.GetArticleByUserId(anyUserId));
        }

          [TestMethod]
          public void Given_UserIdandArticleId_When_UpdateLikes_Then_ReturnArticlesList()
          {
              const int anyUserId = 1000;
              const int anyArticleId = 1200;
              var mock = new Mock<IArticleRepository>();
              var request = new HttpRequestMessage(HttpMethod.Get, "Api/Upload/UpdateLikes/");

              mock.Setup(article => article.UpdateLikes(anyUserId, anyArticleId));

              var login = CreateController(request, mock.Object);
              login.UpdateLikes(anyUserId,anyArticleId);

              mock.Verify(m => m.UpdateLikes(anyUserId, anyArticleId));
          }

          [TestMethod]
          public void Given_Article_When_Save_Then_SaveArticle()
          {

              var mock = new Mock<IArticleRepository>();
              var request = new HttpRequestMessage(HttpMethod.Post, "Api/Upload/Save/");
              var article = CreateArticle();

              mock.Setup(article2 => article2.Save(article));

              var login = CreateController(request, mock.Object);
              login.Save(article);

              mock.Verify(m => m.Save(article));
          }


          [TestMethod]
          public void Given_Article_When_Update_Then_UpdateArticles()
          {

              var mock = new Mock<IArticleRepository>();
              var request = new HttpRequestMessage(HttpMethod.Post, "Api/Upload/update/");
              var article = CreateArticle();

              mock.Setup(article2 => article2.Update(article));

              var login = CreateController(request, mock.Object);
              login.Update(article);

              mock.Verify(m => m.Update(article));
          }

          [TestMethod]
          public void Given_Article_When_Delete_Then_DeleteArticles()
          {

              var mock = new Mock<IArticleRepository>();
              var request = new HttpRequestMessage(HttpMethod.Post, "Api/Upload/Delete/");
              var article = CreateArticle();

              mock.Setup(article2 => article2.Delete(article.ArticleId));

              var login = CreateController(request, mock.Object);
              login.Delete(article.ArticleId);

              mock.Verify(m => m.Delete(article.ArticleId));
          }

        private static UploadController CreateController(HttpRequestMessage request, IArticleRepository mock)
        {
            var login = new UploadController(mock) { Request = request };
            login.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration();
            login.Request = request;

            return login;

        }

        private static Article CreateArticle()
        {
            var article = new Article
            {
                ArticleId = 1000,
                Body = "teeeee",
                NumberOfLikes = 2,
                PublishDate = DateTime.UtcNow,
                Title = "test",
                UserId = 1
            };
            return article;
        }
    }
}
