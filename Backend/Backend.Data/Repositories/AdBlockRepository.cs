using Backend.Data.Entities;
using Backend.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Data.Repositories
{
	public class AdBlockRepository : IRepository<AdBlock>
	{
		private readonly AdvertisingCompanyContext _context = new AdvertisingCompanyContext();
		public void Add(AdBlock itemToAdd)
		{
			ArgumentValidator.ValidateObjectNotNull(itemToAdd, nameof(itemToAdd));

			_context
				.AdBlocks
				.Add(itemToAdd);
		}

		public void DeleteById(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			if (!CheckIfExists(Id))
			{
				throw new ArgumentException("Рекламный блок с таким Id не найден");
			}

			var adBlockToDelete = GetById(Id);

			_context
				.AdBlocks
				.Remove(adBlockToDelete);
			
		}

		public AdBlock GetById(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			if (!CheckIfExists(Id))
			{
				throw new ArgumentException("Рекламный блок с таким Id не найден");
			}

			return _context
				.AdBlocks
				.First(adBlock => adBlock.Id == Id);
		}

		public IEnumerable<AdBlock> GetAll()
		{
			return _context.AdBlocks;
		}

		public void Update(AdBlock itemToUpdate)
		{
			ArgumentValidator.ValidateObjectNotNull(itemToUpdate, nameof(itemToUpdate));

			if (!CheckIfExists(itemToUpdate.Id))
			{
				throw new ArgumentException("Рекламный блок с таким Id не найден");
			}

			_context
				.Entry(itemToUpdate)
				.State = EntityState.Modified;
		}

		public bool CheckIfExists(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			return _context
				.AdBlocks
				.FirstOrDefault(adBlock => adBlock.Id == Id)
				!= null;
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
