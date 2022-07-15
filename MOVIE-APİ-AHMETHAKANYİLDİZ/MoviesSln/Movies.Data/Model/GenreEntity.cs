using System.ComponentModel.DataAnnotations;


namespace Movies.Entities.Model
{
    public class GenreEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
