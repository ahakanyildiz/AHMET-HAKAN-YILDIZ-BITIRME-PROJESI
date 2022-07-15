using Movies.DataAccess.Abstract;
using Movies.Entities;
using Movies.Entities.Model;


namespace Movies.DataAccess.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext movieDbContext;

        public MovieRepository()
        {
            movieDbContext = new MovieDbContext();
        }

        //Video eklemek için veritabanıyla iletişim halinde olan methodu buraya yazdım.
        #region AddMovie
        public MoviesEntity AddMovie(MoviesEntity movie)
        {
                movieDbContext.tblMovie.Add(movie);
                movieDbContext.SaveChanges();
                return movie;        
        }
        #endregion


        //Video silmek için veritabanıyla iletişim halinde olan methodu buraya yazdım.
        #region DeleteMovie
        public void DeleteMovie(int id)
        {
            movieDbContext.tblMovie.Remove(GetMovieDetail(id));
            movieDbContext.SaveChanges();
        }
        #endregion


        //Videoyu ID'sine göre get edebilmek ve her get edildiğinde görüntülenme sayısının increment edildiği methodu buraya yazdım.
        #region GetMovieDetail
        public MoviesEntity GetMovieDetail(long id)
        {

            var u = movieDbContext.tblMovie.Find(id);
            if (u is null)
            {
                return u;
            }
            else
            {
                // Burda girilen ID'ye ait videoyu getirip views degerini 1 arttırıyor.
                u.views = u.views + 1;

                // Nihayetinde veritabanında da güncelliyor.
                movieDbContext.tblMovie.Update(u); 
                movieDbContext.SaveChanges();
                return u;
            }
        }
        #endregion


        //Videoları tür ID'sine göre listeleyen method.
        #region GetMovieListByGenreId
        public IEnumerable<MoviesEntity> GetMovieListByGenreId(int id)
        {
            var u = movieDbContext.tblMovie.Where(x => x.genres.Contains(" "+id.ToString() +",".ToString()));
            return u;
        }
        #endregion


        //Videoları puanına göre listeleyen method.
        #region GetMovieListByRateFilter
        public List<MoviesEntity> GetMovieListByRateFilter(int rate)
        {
            var b = movieDbContext.tblMovie.Where(x => x.vote_average >= rate).ToList();
            return b;
        }
        #endregion


        //Videoları vizyona çıkış tarihine göre listeleyen methodu buraya yazdım.
        #region GetMovieListByRelaseDate
        public IEnumerable<MoviesEntity> GetMovieListByRelaseDate(string date)
        {
            IQueryable<MoviesEntity> u = movieDbContext.tblMovie.Where(x => x.release_date == date);
            return u;

        }
        #endregion


        //Kayıtlı bütün videoları getiren method..
        #region Get All Movies
        public List<MoviesEntity> GetMovies()
        {
            return movieDbContext.tblMovie.ToList();
        }
        #endregion

        /*Aramak istediğiniz videonun başlığını, puanı'nın hangi rakamdan yüksek olduğunu ve yayınlanma yılını girmenizle getiren method.
        İŞLEM ==> ("title","rate","YYYY")*/
        #region Search
        public IEnumerable<MoviesEntity> Search(string title, string rate, string year)
        {
            IQueryable<MoviesEntity> search = movieDbContext.tblMovie;

            if (title != null && rate !=null  && year!=null)
            {   
                search = movieDbContext.tblMovie.Where(x => (x.title.ToLower().StartsWith(title) || x.title.ToUpper().StartsWith(title)) && x.vote_average >= Convert.ToDecimal(rate) && x.release_date.StartsWith(year));
            }

        return search;
        }
        #endregion

        //Videoyu güncellemek için yazdığım method.
        #region UpdateMovie
        public MoviesEntity UpdateMovie(MoviesEntity movie)
        {
            movieDbContext.tblMovie.Update(movie);
            movieDbContext.SaveChanges();
            return movie;
        }
        #endregion

        //En çok görüntülenen 10 video.
        #region ListMostViewed10Movies
        public IEnumerable<MoviesEntity> ListMostViewed10Movies()
        {
            var u = movieDbContext.tblMovie.OrderByDescending(x => x.views).Take(10);
            return u;
        }
        #endregion

        //Puanı en yüksek olan 10 video.
        #region ListTopRated10Movies
        public IEnumerable<MoviesEntity> ListTopRated10Movies()
        {
            var u = movieDbContext.tblMovie.OrderByDescending(x => x.vote_average).Take(10);
            return u;
        } 
        #endregion

    }
}
