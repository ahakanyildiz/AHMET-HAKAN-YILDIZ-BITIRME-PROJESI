using Movies.Entities.Model;

namespace Movies.Business.Abstract
{
    public interface IUserService
    {
        public UserEntity GetUser(string Username, string Password);
    }
}
