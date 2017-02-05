using NewsSystem.Repository;

namespace NewsSystem.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);

    }
}