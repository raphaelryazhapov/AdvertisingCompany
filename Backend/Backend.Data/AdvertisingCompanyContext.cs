using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class AdvertisingCompanyContext : DbContext
	{
		public DbSet<AdBlockType> AdBlockTypes { get; set; }

		public DbSet<PartnerType> PartnerTypes { get; set; }

		public DbSet<Contact> Contacts { get; set; }

		public DbSet<PartnerCompany> PartnerCompanies { get; set; }

		public DbSet<AdBlock> AdBlocks { get; set; }


		public AdvertisingCompanyContext(DbContextOptions options)
			: base(options)
		{
			this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PartnerCompany>(entity =>
			{
				entity.HasMany(company => company.AdBlocks)
					.WithOne(adblock => adblock.PartnerCompany)
					.HasForeignKey(adblock => adblock.CompanyId)
					.OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<AdBlock>(entity =>
			{
				entity.HasOne(adblock => adblock.PartnerCompany)
					.WithMany(company => company.AdBlocks)
					.HasForeignKey(adblock => adblock.CompanyId);
			});
		}
	}
}
