using System.ComponentModel.DataAnnotations;

namespace Recap.Models
{
    public class Araba
    {
        [Key]
        public int ArabaId { get; set; }
        [Required, StringLength(20)]
        public string Marka { get; set; }
        [StringLength(20)]
        public string? Model { get; set; }
    }
}
