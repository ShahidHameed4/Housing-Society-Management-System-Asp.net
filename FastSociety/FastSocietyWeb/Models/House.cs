using System.ComponentModel.DataAnnotations;
namespace FastSocietyWeb.Models
{
    public class House
    {
        [Key]
        public string houseNo { get; set; }

        [Required]
        public string type { get; set; }
        public string Description { get; set; }
        public int Block { get; set; }



    }
}
