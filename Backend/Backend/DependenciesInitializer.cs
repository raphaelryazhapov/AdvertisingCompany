using Backend.Data;
using Backend.Data.Entities;
using Backend.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Web
{
	public static class DependenciesInitializer
	{
		public static void ConfigureRepositories(IServiceCollection services)
		{
			services.AddSingleton<IRepository<PartnerCompany>, PartnerCompanyRepository>();
			services.AddSingleton<IRepository<AdBlock>, AdBlockRepository>();
			services.AddSingleton<IRepository<AdBlockType>, AdBlockTypeRepository>();
			services.AddSingleton<IRepository<PartnerType>, PartnerTypeRepository>();
			services.AddSingleton<IRepository<Contact>, ContactRepository>();
		}
	}
}
