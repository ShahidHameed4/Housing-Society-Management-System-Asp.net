using System.ComponentModel.DataAnnotations;

namespace FastSocietyWeb.Models
{
	public class AllocateHouse
	{
		
			[Key]
			public string House_Number { get; set; }

			public string Name { get; set; }

			public string Mobile { get; set; }

			public string Email { get; set; }

			public string BirthDate { get; set; }

			public string password { get; set; }


	}
}
