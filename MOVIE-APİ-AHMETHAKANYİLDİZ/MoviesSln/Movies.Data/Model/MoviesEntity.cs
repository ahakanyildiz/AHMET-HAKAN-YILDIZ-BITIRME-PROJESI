using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;


namespace Movies.Entities.Model
{
    public class MoviesEntity:EntityTypeConfiguration<MoviesEntity>
    {
        [Required]
        public string adult { get; set; }
        public string? belongs_to_collection { get; set; }
        [Required]
        public string budget { get; set; }
        [Required]
        public string genres { get; set; }
        public string? homepage { get; set; }
        [Key]
        public Int64 id { get; set; }
        public string? imdb_id { get; set; }
        public string? original_language { get; set; }
        [Required]
        public string original_title { get; set; }
        public string? overview { get; set; }
        public string? popularity { get; set; }
        public string? poster_path { get; set; }
        public string? production_companies { get; set; }
        public string? production_countries { get; set; }
        public string? release_date { get; set; }
        public int? revenue { get; set; }
        public decimal? runtime { get; set; }
        public string? spoken_languages { get; set; }
        public string? status { get; set; }
        public string? tagline { get; set; }
        public string? title { get; set; }
        public string? video { get; set; }
        public decimal? vote_average { get; set; }
        public int? vote_count { get; set; }
        public int? views { get; set; }
    }
  
}
