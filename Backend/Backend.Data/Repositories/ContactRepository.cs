using Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Data.Repositories
{
	public class ContactRepository : IRepository<Contact>
	{
		public void Add(Contact itemToAdd)
		{
			throw new NotImplementedException();
		}

		public void DeleteById(Guid Id)
		{
			throw new NotImplementedException();
		}

		public Contact GetById(Guid Id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Contact> GetAll()
		{
			throw new NotImplementedException();
		}

		public void Update(Contact itemToUpdate)
		{
			throw new NotImplementedException();
		}

		public bool CheckIfExists(Guid Id)
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
	}
}
