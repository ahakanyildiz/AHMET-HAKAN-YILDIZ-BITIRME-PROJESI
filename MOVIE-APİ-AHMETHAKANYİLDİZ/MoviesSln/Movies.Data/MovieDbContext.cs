using Microsoft.EntityFrameworkCore;
using Movies.Entities.Model;

namespace Movies.Entities
{
    public class MovieDbContext :DbContext
    {
        //Migration işlemleri yaparken bu constructor'ı yorum satırı haline getirmek gerekiyor(EF CORE BUG).
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }
        public MovieDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Database=dbMovies;Port=5432;User Id=postgres;Password=1234");
        }

        public DbSet<Model.MoviesEntity> tblMovie { get; set; }
        public DbSet<GenreEntity> tblGenre { get; set; }
        public DbSet<UserEntity> tblUser { get; set; }
    }
}
