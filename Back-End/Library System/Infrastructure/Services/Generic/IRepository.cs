using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Generic
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Update(T entity);
        T? Get(int id);
        List<T> GetAll();
        T Delete(T entity);
        void SavaChanges();
    }
}
