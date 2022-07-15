using Movies.Business.Abstract;
using Movies.DataAccess.Abstract;
using Movies.DataAccess.Concrete;
using Movies.Entities.Model;

namespace Movies.Business.Concrete
{
    public class GenreManager : IGenreService
    {
        private IGenreRepository _genreRepository;
        public GenreManager()
        {
            _genreRepository = new GenreRepository();
        }
        public async Task<GenreEntity> AddGenre(GenreEntity movie)
        {
            return await _genreRepository.AddGenre(movie);
        }

        public async Task DeleteGenre(int id)
        {
           await _genreRepository.DeleteGenre(id);
        }

        public async Task<GenreEntity> GetGenreById(int id)
        {
            return await _genreRepository.GetGenreById(id);
        }

        public async Task<List<GenreEntity>> ListGenres()
        {
            return await _genreRepository.ListGenres();
        }

        public async Task<GenreEntity> UpdateGenre(GenreEntity movie)
        {
            return await _genreRepository.UpdateGenre(movie);
        }
    }
}
