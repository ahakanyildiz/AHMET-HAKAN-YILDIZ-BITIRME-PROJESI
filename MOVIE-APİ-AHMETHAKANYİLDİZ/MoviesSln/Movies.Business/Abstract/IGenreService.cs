using Movies.Entities.Model;

namespace Movies.Business.Abstract
{
    public interface IGenreService
    {
        Task<List<GenreEntity>> ListGenres();
        Task<GenreEntity> AddGenre(GenreEntity movie);
        Task<GenreEntity> GetGenreById(int id);
        Task<GenreEntity> UpdateGenre(GenreEntity movie);
        Task DeleteGenre(int id);
    }
}
