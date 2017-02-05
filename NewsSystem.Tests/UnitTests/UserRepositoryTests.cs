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
    public class UserRepositoryTests
    {
        private const string Username = "anyUserName";
        private const string Password = "anyPassword";

        [TestMethod]
        public void Given_UserDetails_When_Login_RequestUserFromRepo()
        {
            var anyUser = CreateUser();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/Api/login/");
            var mock = new Mock<IUserRepository>();
            mock.Setup(user => user.GetUser(Username, Password)).Returns(anyUser);
            var config = new HttpConfiguration();

            var login = new LoginController(mock.Object) { Request = request };
            login.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            login.Request = request;
            login.GetUser(Username, Password);

            mock.Verify(m => m.GetUser(Username, Password));
        }

        private static User CreateUser()
        {
            var anyUser = new User
            {
                CanPublishArticles = true,
                NumberOfLikes = 3,
                Password = Password,
                UserId = 3,
                UserName = Username
            };

            return anyUser;
        }

    }
}
