using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Business.Abstract;
using Movies.Entities.Model;

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService _genreService)
        {
            this._genreService = _genreService;

        }

        [HttpGet]
        /// <summary>
        ///  View All Genres
        /// </summary>
        /// <returns></returns>
        public async Task<List<GenreEntity>> GetAllGenre()
        {
            return await _genreService.ListGenres();

        }

        [HttpGet("{id}")]
        /// <summary>
        ///  View a genre by id
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetGenreById(int id)
        {
            try
            {
                if (_genreService.GetGenreById(id) == null)
                    return NotFound();
                return Ok(await _genreService.GetGenreById(id));
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
            
        }

        [HttpPost]
        /// <summary>
        ///  Add new genre
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AddGenre(GenreEntity genreEntity)
        {
            try
            {
                return Ok(_genreService.AddGenre(genreEntity));
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
            
        }

        [HttpPut]
        /// <summary>
        ///  Update Genre
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UpdateGenre(GenreEntity genreEntity)
        {
            try
            {
                if (_genreService.GetGenreById(genreEntity.id) == null)
                    return BadRequest("Genre not found of by id");
                return Ok(_genreService.UpdateGenre(genreEntity));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
  
        }

        [HttpDelete]
        /// <summary>
        ///  Remove Genre 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (_genreService.GetGenreById(id) != null)
                {
                    await _genreService.DeleteGenre(id);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
  
        }


    }
}
