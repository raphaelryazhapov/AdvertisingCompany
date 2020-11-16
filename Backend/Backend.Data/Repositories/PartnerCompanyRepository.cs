using Backend.Data.Entities;
using Backend.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Data.Repositories
{
	public class PartnerCompanyRepository : IRepository<PartnerCompany>
	{
		private readonly AdvertisingCompanyContext _context;

		public PartnerCompanyRepository(AdvertisingCompanyContext context)
		{
			_context = context;
		}

		public void Add(PartnerCompany itemToAdd)
		{
			ArgumentValidator.ValidateObjectNotNull(itemToAdd, nameof(itemToAdd));

			_context
				.PartnerCompanies
				.Add(itemToAdd);
		}

		public void DeleteById(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			if (!CheckIfExists(Id))
			{
				throw new ArgumentException("Компания с таким Id не найдена");
			}

			var companyToRemove = GetById(Id);
			_context
				.PartnerCompanies
				.Remove(companyToRemove);
		}

		public PartnerCompany GetById(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			if (!CheckIfExists(Id))
			{
				throw new ArgumentException("Компания с таким Id не найдена");
			}

			return _context
				.PartnerCompanies
				.Include(company => company.Owner)
				.Include(company => company.PartnerType)
				.Include(company => company.AdBlocks)
				.FirstOrDefault(company => company.Id == Id);
		}

		public IEnumerable<PartnerCompany> GetAll()
		{
			return _context
				.PartnerCompanies
				.Include(company => company.Owner)
				.Include(company => company.PartnerType)
				.Include(company => company.AdBlocks);
		}

		public void Update(PartnerCompany itemToUpdate)
		{
			ArgumentValidator.ValidateObjectNotNull(itemToUpdate, nameof(itemToUpdate));

			if (!CheckIfExists(itemToUpdate.Id))
			{
				throw new ArgumentException("Компания с таким Id не найдена");
			}

			_context
				.Entry(itemToUpdate)
				.State = EntityState.Modified;
		}

		public bool CheckIfExists(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			return _context
				.PartnerCompanies
				.FirstOrDefault(company => company.Id == Id)
				!= null;
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
