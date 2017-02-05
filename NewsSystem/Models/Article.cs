using System;
using System.Security.Policy;

namespace NewsSystem.Repository
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        public int UserId { get; set; }
        public int NumberOfLikes { get; set; }
        public string Comments { get; set; }

    }
}