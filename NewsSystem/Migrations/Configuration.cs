using System.Collections.Generic;

namespace NewsSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using  NewsSystem.Repository;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsSystem.Repository.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewsSystem.Repository.MyContext context)
        {
  

            var users = new List<User>
            {
                new User
                {
                    CanPublishArticles = true,
                    NumberOfLikes = 2,
                    Password = "11",
                    UserId = 1,
                    UserName = "george"
                },


                   new User
                {
                    CanPublishArticles = false,
                    NumberOfLikes = 2,
                    Password = "12",
                    UserId = 1,
                    UserName = "CanPublishUser"
                },

                new User {CanPublishArticles = true, NumberOfLikes = 2, Password = "p", UserId = 2, UserName = "p"}


            };

            users.ForEach(s => context.User.AddOrUpdate(p => p.UserId, s));
            context.SaveChanges();

            var arctles = new List<Article>
            {
                new Article{ArticleId = 1, Body = "this is a test", PublishDate = DateTime.UtcNow,Title = "test", UserId = 1, Comments = "this is good"},
                new Article{ArticleId = 2, Body = "this is a test", PublishDate = DateTime.UtcNow,Title = "second test", UserId = 2, Comments = "this is ok"}

            };

            arctles.ForEach(s => context.Article.AddOrUpdate(p => p.ArticleId, s));
            context.SaveChanges();


        }
    }
}
