using Microsoft.EntityFrameworkCore;
using Movies.DataAccess.Abstract;
using Movies.Entities;
using Movies.Entities.Model;

namespace Movies.DataAccess.Concrete
{
    public class GenreRepository : IGenreRepository
    {
        private MovieDbContext genreDbContext;

        public GenreRepository()
        {
            genreDbContext = new MovieDbContext();
        }

        //Tür eklemek için veritabanıyla iletişim halinde olan methodu buraya yazdım.
        #region AddGenre
        public async Task<GenreEntity> AddGenre(GenreEntity movie)
        {
            genreDbContext.tblGenre.Add(movie);
            await genreDbContext.SaveChangesAsync();
            return movie;
        }
        #endregion

        //Tür silmek için veritabanıyla iletişim halinde olan methodu buraya yazdım.
        #region DeleteGenre
        public async Task DeleteGenre(int id)
        {
            genreDbContext.tblGenre.Remove(genreDbContext.tblGenre.Find(id));
            await genreDbContext.SaveChangesAsync();
        }
        #endregion

        //Türleri listelemek için veritabanıyla iletişim halinde olan methodu buraya yazdım.
        #region ListGenres
        public async Task<List<GenreEntity>> ListGenres()
        {
            var u = genreDbContext.tblGenre.ToListAsync();
            return await u;
        }
        #endregion

        //Tür güncellemek için veritabanıyla iletişim halinde olan methodu buraya yazdım.
        #region UpdateGenre
        public async Task<GenreEntity> UpdateGenre(GenreEntity movie)
        {
            genreDbContext.tblGenre.Update(movie);
            await genreDbContext.SaveChangesAsync();
            return movie;
        }
        #endregion

        //Tür'ü id'sine göre get edebilmek için veritabanıyla iletişim halinde olan methodu buraya yazdım.
        #region GetGenreById
        public async Task<GenreEntity> GetGenreById(int id)
        {
            return await genreDbContext.tblGenre.Where(x => x.id == id).FirstOrDefaultAsync();
        }
        #endregion
    }
}
