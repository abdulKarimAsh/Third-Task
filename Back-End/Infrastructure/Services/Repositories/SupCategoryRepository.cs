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
    public class SupCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        private readonly LibraryContext context;

        public SupCategoryRepository(LibraryContext _context) : base(_context)
        {
            context = _context;
        }

        public List<SubCategory> GetSubByCategoryId(int categoryId)
        {
            return context.SubCategories
                .Where(b => b.CategoryId == categoryId)
                .ToList();
        }
    }
}
