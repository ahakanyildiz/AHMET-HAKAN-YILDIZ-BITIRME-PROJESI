using Movies.DataAccess.Abstract;
using Movies.Entities;
using Movies.Entities.Model;
using System.Security.Cryptography;
using System.Text;

namespace Movies.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private MovieDbContext _userContext;
        public UserRepository()
        {
            _userContext = new MovieDbContext();
        }

        #region MD5 GENERATOR
        public string GetMd5ByPassword(string md5pw)
        {
            using (var md5Hash = MD5.Create())
            {
                // Şifrenin byte dizisi olarak gösterdim.
                var sourceBytes = Encoding.UTF8.GetBytes(md5pw);

                // Oluşan byte dizisini şifreledim.
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Oluşan şifreli byte dizisinde "-" leri kaldırdım.
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                // Oluşan MD5'i döndürdüm.
                return hash;
            }
        } 
        #endregion

        public UserEntity GetUser(string Username, string Password)
        {
            //Kullanıcı adının hepsini küçük harfe çevirdim çünkü kullanıcı girişi yapılırken k.adında büyük, küçük harf duyarlılığı olsun istemedim.
            string usernamelower =Username.ToLower();

            //Kullanıcının girdiği string değeri veritabanındaki şifreyle eşleştirebilmek için MD5 çevirdim.
            Password = GetMd5ByPassword(Password);

            //Login validation işlemlerimi yaptığım sorgu..
            var u = _userContext.tblUser.Where(x => (x.username == Username  || x.username.ToLower()==usernamelower) && x.password == Password ).FirstOrDefault();
            return u;
        }


    }
}
