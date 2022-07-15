using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Business.Abstract;
using Movies.DataAccess.Redis;
using Movies.Entities.Model;

namespace Movies.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IRedisHelper redisHelper;
        public MovieController(IMovieService _movieService, IRedisHelper redisHelper)
        {
            this._movieService = _movieService;
            this.redisHelper = redisHelper;
        }


        #region AddMovie
        /// <summary>
        ///  Add a new video 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMovie([FromBody] MoviesEntity movie)
        {
            try
            {
                if (ModelState.IsValid) //MovieEntities'de Required alanlar girildi mi girilmedi mi diye check ediyor.
                    return Ok(_movieService.AddMovie(movie));
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
        #endregion

        #region DeleteMovie
        [HttpDelete]
        /// <summary>
        ///  Delete Video By Id
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                if (_movieService.GetMovieDetail(id) != null) //Girilen Id'ye ait bir movie varsa işlemi yap.
                {
                    var u = _movieService.GetMovieDetail(id);
                    redisHelper.SetListAsync("DeletedVideosList", "ID: " + id + "IMDB ID: " + u.imdb_id + "Rate" + u.vote_average); // Silinen videonun id'sini ve imdb id'sini de videoya ait datayı imdb'den alabileyim diye redis serverda yedekledim ki sonradan lazım olabilir.
                    _movieService.DeleteMovie(id);
                    return Ok();
                }
                else // Eğer böyle bir video yoksa Badrequest döndür.
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }
        #endregion

        #region GetMovieDetail
        /// <summary>
        ///  View a movie By Id (The view value is incremented by 1 with each request.) 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieDetail(long id)
        {
            try
            {
                var u = _movieService.GetMovieDetail(id); //Girilen Id'ye ait bir movie varsa işlemi yap.
                if (u is not null)
                {
                    await redisHelper.SetKeyAsync("LastSearchedVideo", "ID: " + id.ToString() + " Views " + u.views.ToString());
                    return Ok(u);
                }
                return NotFound();// Eğer böyle bir video yoksa Badrequest döndür.
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }


        }
        #endregion

        #region GetMovieListByGenreId
        /// <summary>
        ///  View Movies By Genre ID 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/[action]/{id}")]
        public IActionResult GetMovieListByGenreId(int id)
        {
            try
            {
                var u = _movieService.GetMovieListByGenreId(id);
                if (u is not null)
                {

                    return Ok(u);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }
        #endregion

        #region GetMovieListByRateFilter
        /// <summary>
        ///  View Movies By Vote Score
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{rate}")]
        public IActionResult GetMovieListByRateFilter(int rate)
        {
            try
            {
                var u = _movieService.GetMovieListByRateFilter(rate);
                if (u is not null)
                {
                    return Ok(u);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }
        #endregion

        #region GetMovieListByRelaseDate
        /// <summary>
        ///  Get Movies By Relase Date
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/{date}")]
        public IActionResult GetMovieListByRelaseDate(string date)
        {
            try
            {
                var u = _movieService.GetMovieListByRelaseDate(date);
                if (u is not null)
                {
                    return Ok(u);
                }
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }


        }
        #endregion

        #region GetAllMovies
        [HttpGet]
        /// <summary>
        ///  View All Movies
        /// </summary>
        /// <returns></returns>
        public List<MoviesEntity> GetMovies()
        {
            return _movieService.GetMovies();
        }
        #endregion

        #region Search
        /// <summary>
        ///  Search Video by title or by rate or by year 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]/")]
        public IActionResult Search(string title, string rate, string year)
        {
            try
            {
                var u = _movieService.Search(title, rate, year);
                if (u != null)
                    return Ok(u);
                return NotFound();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }
        #endregion

        #region UpdateMovie
        [HttpPut]
        /// <summary>
        ///  Update Movie Information
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateMovie(MoviesEntity movie)
        {
            try
            {
                if (_movieService.GetMovieDetail(movie.id) != null)
                    return Ok(_movieService.UpdateMovie(movie));
                return BadRequest();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }

        }
        #endregion

    }
}
