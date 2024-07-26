using Domin;
using Infrastructure.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksByAuthorEF(int id);
        IEnumerable<Book> GetBooksBySubId(int id);
        IEnumerable<Book> GetBooksByAuthorSQL(int id);
    }
}
