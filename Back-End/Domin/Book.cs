using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PublicationYear { get; set; }


        public int AuthorId { get; set; }
        public Author Authors { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategories { get; set; }

    }
}
