using Movies.Entities.Model;

namespace Movies.DataAccess.Abstract
{
    public interface IUserRepository
    {
        public UserEntity GetUser(string Username,string Password);
        public string GetMd5ByPassword(string password);
    }
}
