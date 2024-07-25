using Domin;
using Infrastructure.DataBeasContexts;
using Infrastructure.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Repositories
{
    internal class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(LibraryContext _context) : base(_context)
        {
        }
    }
}
