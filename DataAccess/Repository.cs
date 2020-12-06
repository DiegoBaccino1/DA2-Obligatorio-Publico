using DataAccessInterface;
using Exceptiones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> DbSet;
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.DbSet = context.Set<T>();
            this.context = context;
        }
        
        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T Get(int id)
        {
            T retorno = DbSet.Find(id);
            if (retorno == null)
                throw new EntidadNoExisteExcepcion();
            return retorno;
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
