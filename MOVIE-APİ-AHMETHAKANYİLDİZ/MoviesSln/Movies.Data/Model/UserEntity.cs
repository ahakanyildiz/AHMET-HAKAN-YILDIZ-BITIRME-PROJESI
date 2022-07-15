using System.ComponentModel.DataAnnotations;


namespace Movies.Entities.Model
{
    public class UserEntity
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}
