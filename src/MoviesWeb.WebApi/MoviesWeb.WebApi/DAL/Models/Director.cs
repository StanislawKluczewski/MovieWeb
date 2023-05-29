using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesWeb.WebApi.DAL.Models
{
    [Table("Directors")]
    public class Director
    {
        [Key]
        public int DirectorId { get; set; }
        [MaxLength(30)]
        public string? Name { get; set; }
        [MaxLength(30)]
        public string? Surname { get; set; }
        [MaxLength(30)]
        public string? Sex { get; set; }
        [Range(15,99)]
        public int Wiek { get; set; }
       
        [MaxLength(50)]
        public string? Nationality { get; set; }
        [Range(0,10)]
        public double DirectorMark { get; set; }
    }
}
