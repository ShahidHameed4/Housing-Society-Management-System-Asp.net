using System.ComponentModel.DataAnnotations;

namespace FastSocietyWeb.Models
{
    public class Annoucement
    {
        
        [Key]
        public string? Annouce { get; set; }
        public DateTime date { get; set; }
    }
}
