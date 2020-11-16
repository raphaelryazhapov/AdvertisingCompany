using Backend.Data.Entities;
using Backend.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Data.Repositories
{
	public class AdBlockTypeRepository : IRepository<AdBlockType>
	{
		private readonly AdvertisingCompanyContext _context;

		public AdBlockTypeRepository(AdvertisingCompanyContext context)
		{
			_context = context;
		}

		public void Add(AdBlockType itemToAdd)
		{
			ArgumentValidator.ValidateObjectNotNull(itemToAdd, nameof(itemToAdd));

			_context
				.AdBlockTypes
				.Add(itemToAdd);
		}

		public void DeleteById(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			if (!CheckIfExists(Id))
			{
				throw new ArithmeticException("Типа рекламных блоков с таким Id нет");
			}

			var adBlockTypeToDelete = GetById(Id);

			_context
				.AdBlockTypes
				.Remove(adBlockTypeToDelete);
		}

		public AdBlockType GetById(Guid Id)
		{
			ArgumentValidator.ValidateGuidNotEmpty(Id, nameof(Id));

			if (!CheckIfExists(Id))
			{
				throw new ArithmeticException("Типа рекламных блоков с таким Id нет");
			}

			return _context
				.AdBlockTypes
				.First(adBlockType => adBlockType.Id == Id);
		}

		public IEnumerable<AdBlockType> GetAll()
		{
			return _context.AdBlockTypes;
		}

		public void Update(AdBlockType itemToUpdate)
		{
			ArgumentValidator.ValidateObjectNotNull(itemToUpdate, nameof(itemToUpdate));

			if (!CheckIfExists(itemToUpdate.Id))
			{
				throw new ArithmeticException("Типа рекламных блоков с таким Id нет");
			}

			_context
				.Entry(itemToUpdate)
				.State = EntityState.Modified;
		}

		public bool CheckIfExists(Guid Id)
		{
			ArgumentValidator.ValidateObjectNotNull(Id, nameof(Id));

			return _context
				.AdBlockTypes
				.FirstOrDefault(adBlockType => adBlockType.Id == Id)
				!= null;
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
