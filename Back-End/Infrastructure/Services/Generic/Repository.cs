using Infrastructure.DataBeasContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Generic
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryContext context;

        public Repository(LibraryContext _context)
        {
            context = _context;
        }
        public T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public T Delete(T entity)
        {
            return context.Remove(entity).Entity;
        }

        public T? Get(int id)
        {
            return context.Find<T>(id);
        }

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void SavaChanges()
        {
            context.SaveChanges();
        }

        public T Update(T entity)
        {
            return context.Update(entity).Entity;
        }
    }
}
