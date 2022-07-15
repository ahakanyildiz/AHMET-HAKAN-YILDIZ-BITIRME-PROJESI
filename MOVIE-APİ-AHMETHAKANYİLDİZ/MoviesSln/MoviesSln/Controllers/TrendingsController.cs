using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Business.Abstract;

namespace Movies.Api.Controllers
{

    [ApiController, Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class TrendingsController : ControllerBase
    {
        private readonly IMovieService movieService;

        public TrendingsController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet,Route("[Action]")]
        public IActionResult ListTopRated10Movies()
        {
            try
            {
                return Ok(movieService.ListTopRated10Movies());
            }
            catch (Exception ex)
            {
               return Problem(ex.Message);
            }
            
        }

        [HttpGet, Route("[Action]")]
        public IActionResult ListMostViewed10Movies()
        {
            try
            {
                return Ok(movieService.ListMostViewed10Movies());
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
            
        }
    }
}
