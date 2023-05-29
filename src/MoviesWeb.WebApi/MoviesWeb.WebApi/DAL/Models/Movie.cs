using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWeb.WebApi.DAL.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [MaxLength(30)]
        public string? Name { get; set; }
        public DateTime DateOfProduction { get; set; }
        [MaxLength(50)]
        public string? Category { get; set; }
        [Range(0, 300)]
        public int MovieLength { get; set; }
        public decimal BoxOffice { get; set; }
        [Range(0, 10)]
        public double MovieMark { get; set; }
        [MaxLength(50)]
        public string? ProductionCountry { get; set; }

        public ICollection<Actor>?Actors { get; set; }   
    }
}
