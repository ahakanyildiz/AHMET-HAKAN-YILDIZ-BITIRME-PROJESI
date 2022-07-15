using Movies.Entities.Model;


namespace Movies.Business.Abstract
{
    public interface IMovieService
    {
        MoviesEntity GetMovieDetail(long id);
        IEnumerable<MoviesEntity> GetMovieListByGenreId(int id);
        List<MoviesEntity> GetMovieListByRateFilter(int rate);
        IEnumerable<MoviesEntity> GetMovieListByRelaseDate(string date);
        IEnumerable<MoviesEntity> Search(string title, string rate, string year);
        MoviesEntity AddMovie(MoviesEntity movie);
        MoviesEntity UpdateMovie(MoviesEntity movie);
        void DeleteMovie(int id);
        List<MoviesEntity> GetMovies();
        IEnumerable<MoviesEntity> ListMostViewed10Movies();
        IEnumerable<MoviesEntity> ListTopRated10Movies();
    }
}
