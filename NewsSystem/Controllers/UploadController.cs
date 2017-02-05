using System.Net;
using System.Net.Http;
using System.Web.Http;
using NewsSystem.Interfaces;
using NewsSystem.Repository;

namespace NewsSystem.Controllers
{
    public class UploadController : ApiController
    {
        private readonly IArticleRepository _articleRepository;

        public UploadController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        [RouteAttribute("Api/Upload/ArticlesByUser/{userId=userId}")]
        [HttpGet]
        public HttpResponseMessage GetArticleByUserId(int userId)
        {
            var articles = _articleRepository.GetArticleByUserId(userId);    
           return Request.CreateResponse(HttpStatusCode.OK, articles);
           
        }
       
        [RouteAttribute("Api/Upload/ArticlesByArticle/{articleId=articleId}")]
        [HttpGet]
        public HttpResponseMessage GetArticleByArticleId(int articleId)
        {
            var articles = _articleRepository.GetArticleByArticleId(articleId);    
           return Request.CreateResponse(HttpStatusCode.OK, articles);        
        }


        [RouteAttribute("Api/Upload/Save/{article=article}")]
        [HttpPost]
        public HttpResponseMessage Save([FromBody] Article article)
        {
            var articles = _articleRepository.Save(article);
            return Request.CreateResponse(HttpStatusCode.OK, articles);
        }


        [RouteAttribute("Api/Upload/Delete/{article=article}")]
        [HttpGet]
        public HttpResponseMessage Delete(int articleId)
        {
            _articleRepository.Delete(articleId);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [RouteAttribute("Api/Upload/Update/{article=article}")]
        [HttpPost]
        public HttpResponseMessage Update([FromBody] Article article)
        {
            _articleRepository.Update(article);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [RouteAttribute("Api/Upload/UpdateLikes/{userId=userId}/{articleId=articleId}")]
        [HttpGet]
        public HttpResponseMessage UpdateLikes(int userId, int articleId)
        {
            _articleRepository.UpdateLikes(userId,articleId);
            return Request.CreateResponse(HttpStatusCode.OK);

        }


        [RouteAttribute("Api/Upload/UpdateComments/{userId=userId}/{articleId=articleId}")]
        [HttpGet]
        public IHttpActionResult UpdateComments([FromBody] Article article)
        {
            _articleRepository.UpdateComment(article);
            return Ok();

        }


    }
}
