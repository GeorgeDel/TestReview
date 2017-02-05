using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsSystem.Repository;

namespace NewsSystem.Tests.IntegrationTests
{

    [TestClass]
   public class UserRepositoryTests
    {
        private const string Login = "george";
        private const string VaildPassword = "11";
         [TestMethod]
        public void Given_CorrectLoginDetails_When_Login_Then_ReturnUser()
         {
             var result = GetUser(Login, VaildPassword);
             result.UserName.Should().Be(Login);
         }

         [TestMethod]
         public void Given_IncorrectLoginDetails_When_Login_Then_ReturnNull()
         {
             var result = GetUser(Login, "anyworngPassword");
             result.Should().BeNull();
         }

         [TestMethod]
         public void Given_EmptytDetails_When_Login_Then_ReturnNull()
         {
             const string username = "";
             const string password = "";

             var result = GetUser(username, password);
             result.Should().BeNull();
         }

         [TestMethod]
         public void Given_UserThatCanPublish_When_Login_Then_CanPublishShouldBeTrue()
         {
             var result = GetUser(Login, VaildPassword);
             result.CanPublishArticles.Should().BeTrue();
         }

         [TestMethod]
         public void Given_UserThatCanNOTPublish_When_Login_Then_CanPublishShouldBeFalse()
         {
             var result = GetUser("CannotPublish", "1");
             result.CanPublishArticles.Should().BeFalse();
         }






        private static User GetUser(string userName, string password)
        {
            var userRepo = new UserRepository();
            return userRepo.GetUser(userName, password);
        }
    }
}
