using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
	[Table("Contact")]
	public class Contact
	{
		[Column("Id")]
		public Guid Id { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("Surname")]
		public string Surname { get; set; }

		[Column("Patronymic")]
		public string Patronymic { get; set; }
	}
}
