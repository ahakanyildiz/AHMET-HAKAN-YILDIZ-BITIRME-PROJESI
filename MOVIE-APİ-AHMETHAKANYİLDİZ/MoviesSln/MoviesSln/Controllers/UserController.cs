using Microsoft.AspNetCore.Mvc;
using Movies.Api.JWT;
using Movies.Business.Abstract;
using Movies.DataAccess.Redis;

namespace Movies.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTHelper _jwtHelper;
        private readonly IRedisHelper redisHelper;
        public UserController(IUserService _userService, IJWTHelper jWTHelper, IRedisHelper redisHelper)
        {
            this._userService = _userService;
            _jwtHelper = jWTHelper;
            this.redisHelper = redisHelper;
        }

        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var u = _userService.GetUser(username, password);
                if (u != null)
                {
                    redisHelper.SetListAsync("LoginsLog", "Username: " + username + " Time:" + DateTime.Now.ToString());
                    return Ok(_jwtHelper.GenerateToken(u.username));
                }
                return BadRequest();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
       
        }
    }
}
