using System.Data.Entity;

namespace NewsSystem.Repository
{
    public class MyContext : DbContext
    {
    
            public DbSet<User> User { get; set; }
            public DbSet<Article> Article { get; set; }
        
    }
}