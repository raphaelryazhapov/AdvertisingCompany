using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
	[Table("AdBlock")]
	public class AdBlock
	{
		[Key]
		[Column("Id")]
		public Guid Id { get; set; }

		[Column("AdBlockTypeId")]
		public Guid AdBlockTypeId { get; set; }

		[ForeignKey("AdBlockTypeId")]
		public AdBlockType AdBlockType { get; set; }

		[Column("Cost")]
		public int Cost { get; set; }
		
		[Column("CompanyId")]
		public Guid CompanyId { get; set; }

		[ForeignKey("CompanyId")]
		public PartnerCompany PartnerCompany { get; set; }
	}
}
