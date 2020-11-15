using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
	[Table("PartnerType")]
	public class PartnerType
	{
		[Column("Id")]
		public Guid Id { get; set; }

		[Column("Name")]
		public string Name { get; set; }
	}
}
