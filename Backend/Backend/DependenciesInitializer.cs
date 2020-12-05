using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Web
{
	public class DependenciesInitializer
	{
		private readonly IConfiguration _configuration;

		public DependenciesInitializer(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureRepositories(IServiceCollection services)
		{
			services.AddSingleton<IRepository<PartnerCompany>, PartnerCompanyRepository>();
			services.AddSingleton<IRepository<AdBlock>, AdBlockRepository>();
			services.AddSingleton<IRepository<AdBlockType>, AdBlockTypeRepository>();
			services.AddSingleton<IRepository<PartnerType>, PartnerTypeRepository>();
			services.AddSingleton<IRepository<Contact>, ContactRepository>();
		}

		public void ConfigureDbContext(IServiceCollection services)
		{
			services.AddSingleton<AdvertisingCompanyContext>(
				provider =>
				{
					var optionsBuilder = new DbContextOptionsBuilder(new DbContextOptions<AdvertisingCompanyContext>())
						.UseSqlServer(_configuration["AdvertisingAgencyConnectionString"]);

					return new AdvertisingCompanyContext(optionsBuilder.Options);
				});
		}
	}
}
