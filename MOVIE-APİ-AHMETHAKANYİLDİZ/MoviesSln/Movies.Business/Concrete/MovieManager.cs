using Movies.Business.Abstract;
using Movies.DataAccess.Abstract;
using Movies.DataAccess.Concrete;
using Movies.Entities.Model;


namespace Movies.Business.Concrete
{
    public class MovieManager : IMovieService
    {
        private IMovieRepository _movieRepository;

        public MovieManager()
        {
            _movieRepository = new MovieRepository();
        }

        #region AddMovie
        public MoviesEntity AddMovie(MoviesEntity movie)
        {
            return _movieRepository.AddMovie(movie);
        }
        #endregion

        #region DeleteMovie
        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }
        #endregion

        #region GetMovieDetail
        public MoviesEntity GetMovieDetail(long id)
        {
            return _movieRepository.GetMovieDetail(id);
        }
        #endregion

        #region GetMovieListByGenreId
        public IEnumerable<MoviesEntity> GetMovieListByGenreId(int id)
        {
            return _movieRepository.GetMovieListByGenreId(id);
        }
        #endregion

        #region GetMovieListByRateFilter
        public List<MoviesEntity> GetMovieListByRateFilter(int rate)
        {
            return _movieRepository.GetMovieListByRateFilter(rate);
        }
        #endregion

        #region GetMovieListByRelaseDate
        public IEnumerable<MoviesEntity> GetMovieListByRelaseDate(string date)
        {
            return _movieRepository.GetMovieListByRelaseDate(date);
        }
        #endregion

        #region GetAllMovies
        public List<MoviesEntity> GetMovies()
        {
            return _movieRepository.GetMovies();
        }
        #endregion

        #region Search
        public IEnumerable<MoviesEntity> Search(string title, string rate, string year)
        {
            return _movieRepository.Search(title, rate, year);
        }
        #endregion

        #region UpdateMovie
        public MoviesEntity UpdateMovie(MoviesEntity movie)
        {
            return _movieRepository.UpdateMovie(movie);
        }
        #endregion

        #region ListMostViewed10Movies
        public IEnumerable<MoviesEntity> ListMostViewed10Movies()
        {
            return _movieRepository.ListMostViewed10Movies();
        }
        #endregion

        #region ListTopRated10Movies
        public IEnumerable<MoviesEntity> ListTopRated10Movies()
        {
            return _movieRepository.ListTopRated10Movies();
        } 
        #endregion

    }
}
