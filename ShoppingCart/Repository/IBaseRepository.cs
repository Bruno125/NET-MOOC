using System;
using System.Collections.Generic;

namespace ShoppingCart.Repository
{
    public interface IBaseRepository<T>
    {

		bool Save(T entity);
		IEnumerable<T> GetAll();
		T Get(long id);
		bool Delete(long id);
		bool Update(T student);

    }
}
