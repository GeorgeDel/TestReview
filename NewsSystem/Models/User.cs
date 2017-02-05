namespace NewsSystem.Repository
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int NumberOfLikes { get; set; }
        public bool CanPublishArticles { get; set; }

    }
}