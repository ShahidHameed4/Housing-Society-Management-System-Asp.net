using System.ComponentModel.DataAnnotations;

namespace FastSocietyWeb.Models
{
    public class Employee
    {
        [Key]
        public int Emp_ID { get; set; }
        [Required]
        public string Emp_Name { get; set; }

        public string Emp_Salary { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
