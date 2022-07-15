using Movies.Business.Abstract;
using Movies.DataAccess.Abstract;
using Movies.DataAccess.Concrete;
using Movies.Entities.Model;


namespace Movies.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository userRepository;
       public UserManager()
        {
            userRepository = new UserRepository();
        }
        public UserEntity GetUser(string Username, string Password)
        {
            return userRepository.GetUser(Username, Password);
        }
    }
}
