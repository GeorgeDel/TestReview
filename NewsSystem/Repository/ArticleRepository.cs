using System;
using System.Collections.Generic;
using System.Linq;
using NewsSystem.Interfaces;

namespace NewsSystem.Repository
{
    public class ArticleRepository : IArticleRepository
    {

        public void UpdateLikes(int userId, int articleId)
        {
            using (var db = new MyContext())
            {
                try
                {

                    var query = (from u in db.User.AsNoTracking()
                        where u.UserId == userId
                        select u).First();


                    db.User.Attach(query);

                    query.NumberOfLikes --;

                    var query2 = (from a in db.Article.AsNoTracking()
                        where a.ArticleId == articleId
                        select a).First();


                    db.Article.Attach(query2);

                    query2.NumberOfLikes++;


                    db.SaveChanges();
                }                 
                catch (Exception)
                {
                }
            }
        }

        public int Save(Article article)
        {
            article.PublishDate = DateTime.UtcNow.Date;
 
            using (var db = new MyContext())
            {

                db.Article.Add(article);
                db.SaveChanges();

                return article.ArticleId;
            }
        }

        public void Delete(int articleId)
        {

            using (var db = new MyContext())
            {
                var query = (from u in db.Article.AsNoTracking()
                             where u.ArticleId == articleId
                             select u).First();



                db.Article.Attach(query);
                db.Article.Remove(query);
                db.SaveChanges();

            }

        }

        public void Update(Article article)
        {
           article.PublishDate = DateTime.UtcNow.Date;
            ;

            using (var db = new MyContext())
            {

                try
                {
       
                    db.Article.Attach(article);
                    db.Entry(article).Property(x => x.Body).IsModified = true;
                    db.Entry(article).Property(x => x.Title).IsModified = true;
                    db.Entry(article).Property(x => x.PublishDate).IsModified = true;
                   
      

                    db.SaveChanges();

                }
                catch (Exception)
                {
                }

            }
        }


        public Article GetArticleByArticleId(int articleId)
        {
            using (var db = new MyContext())
            {

                try
                {
                    var query = (from a in db.Article.AsNoTracking()
                        where a.ArticleId == articleId
                        select a).First();


                    return query;
                }

                catch (Exception)
                {
                    return null;
                }
            }
        }

        public  List<Article> GetArticleByUserId(int userId)
        {
            using (var db = new MyContext())
            {
                try
                {

                    var query = (from a in db.Article.AsNoTracking()
                        where a.UserId == userId
                        select a).ToList();


                    return query;
                }

                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void UpdateComment(Article article)
        {
            throw new NotImplementedException();
        }
    }
}