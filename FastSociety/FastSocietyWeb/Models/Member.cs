using System.ComponentModel.DataAnnotations;

namespace FastSocietyWeb.Models
{
	public class Member
	{
		[Key]
		public int Member_ID { get; set; }
		[Required]
		public string Member_Name { get; set; }

		public string Member_Address { get; set; }

		public string Member_Phone { get; set; }

		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	}
}
