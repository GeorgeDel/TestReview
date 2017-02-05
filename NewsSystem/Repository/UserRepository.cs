using System;
using System.Linq;
using NewsSystem.Interfaces;

namespace NewsSystem.Repository
{
    public class UserRepository: IUserRepository
    {
        public User GetUser(string username, string password)
        {
            using (var db = new MyContext())
            {
                try
                {
                    var query = (from u in db.User
                        where u.UserName == username
                        where u.Password == password
                        select u).First();

                    return query;

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}