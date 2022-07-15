using Movies.Entities.Model;


namespace Movies.DataAccess.Abstract
{
    public interface IMovieRepository
    {
        MoviesEntity GetMovieDetail(long id);
        IEnumerable<MoviesEntity> GetMovieListByGenreId(int id);
        List<MoviesEntity> GetMovies();
        List<MoviesEntity> GetMovieListByRateFilter(int rate);
        IEnumerable<MoviesEntity> GetMovieListByRelaseDate(string date);
        IEnumerable<MoviesEntity> Search(string title,string rate, string year);
        MoviesEntity AddMovie(MoviesEntity movie);
        MoviesEntity UpdateMovie(MoviesEntity movie);
        void DeleteMovie(int id);
        IEnumerable<MoviesEntity> ListMostViewed10Movies();
        IEnumerable<MoviesEntity> ListTopRated10Movies();

    }
}
