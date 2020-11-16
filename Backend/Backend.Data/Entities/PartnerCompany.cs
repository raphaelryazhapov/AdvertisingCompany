using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
	[Table("PartnerCompany")]
	public class PartnerCompany
	{
		[Column("Id")]
		public Guid Id { get; set; }

		[Column("Name")]
		public string Name { get; set; }

		[Column("OwnerId")]
		public Guid OwnerId { get; set; }

		[ForeignKey("OwnerId")]
		public Contact Owner { get; set; }

		[Column("PartnerTypeId")]
		public Guid PartnerTypeId { get; set; }

		[ForeignKey("PartnerTypeId")]
		public PartnerType PartnerType { get; set; }

		[Column("AdBlockCount")]
		public int AdBlockCount { get; set; }

		public ICollection<AdBlock> AdBlocks { get; set; }
	}
}
