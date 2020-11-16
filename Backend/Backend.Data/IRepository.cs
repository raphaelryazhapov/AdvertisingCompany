using System;
using System.Collections.Generic;

namespace Backend.Data
{
	public interface IRepository<T>
		where T: class
	{
		public T GetById(Guid Id);

		public IEnumerable<T> GetAll();

		public void Add(T itemToAdd);

		public void Update(T itemToUpdate);

		public void DeleteById(Guid Id);

		public bool CheckIfExists(Guid Id);

		public void Save();
	}
}
