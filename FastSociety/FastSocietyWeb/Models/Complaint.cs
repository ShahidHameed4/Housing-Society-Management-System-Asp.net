using System.ComponentModel.DataAnnotations;

namespace FastSocietyWeb.Models
{
    public class Complaint
    {
        [Key]
        public int Complaint_ID { get; set; }
        [Required]
        public string User_ID { get; set; }

        public string Complaint_Type { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

    }
}
