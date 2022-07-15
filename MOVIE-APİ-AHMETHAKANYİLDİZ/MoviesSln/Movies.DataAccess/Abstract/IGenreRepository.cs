using Movies.Entities.Model;


namespace Movies.DataAccess.Abstract
{
    public interface IGenreRepository
    {
        Task<List<GenreEntity>> ListGenres();
        Task<GenreEntity> AddGenre(GenreEntity movie);
        Task<GenreEntity> GetGenreById(int id);
        Task<GenreEntity> UpdateGenre(GenreEntity movie);
        Task DeleteGenre(int id);
    }
}
