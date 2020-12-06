using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IRepository<T> where T:class
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Save();
    }
}
