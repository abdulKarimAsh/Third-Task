using Domin;
using Infrastructure.Services.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Repositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        List<SubCategory> GetSubByCategoryId(int categoryId);
    }
}
