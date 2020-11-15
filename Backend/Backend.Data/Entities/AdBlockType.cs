using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
	[Table("AdBlockType")]
	public class AdBlockType
	{
		[Column("Id")]
		public Guid Id { get; set; }

		[Column("Name")]
		public string Name { get; set; }
	}
}
