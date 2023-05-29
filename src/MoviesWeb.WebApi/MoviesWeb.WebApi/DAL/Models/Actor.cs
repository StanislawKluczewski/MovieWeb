using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWeb.WebApi.DAL.Models
{
    [Table("Actors")]
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [MaxLength(30)]
        public string? Name { get; set; }
        [MaxLength(30)]
        public string? Surname { get; set; }
        [MaxLength(30)]
        public string? Sex { get; set; }
        [Range(10,99)]
        public int Wiek { get; set; }
        [MaxLength(50)]
        public string? Nationality { get; set; }
        [Range(0,10)]
        public double ActorMark { get; set; }

        public ICollection<Movie>? ActorMovies { get; set; }
    }
}
