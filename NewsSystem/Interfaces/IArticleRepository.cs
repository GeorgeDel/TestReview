using System.Collections.Generic;
using NewsSystem.Repository;

namespace NewsSystem.Interfaces
{
   public interface IArticleRepository
   {
       void UpdateLikes(int userId, int articleId);
       int Save(Article article);
       void Delete(int articleId);
       void Update(Article article);
       Article GetArticleByArticleId(int articleId);
       List<Article> GetArticleByUserId(int userId);
       void UpdateComment(Article article);
   }
}
