using Domin;
using Infrastructure.DataBeasContexts;
using Infrastructure.Services.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.Repositories
{
    public class BookRepository : Repository<Book> ,IBookRepository
    {
        private readonly LibraryContext context;

        public BookRepository(LibraryContext _context) : base(_context)
        {
            context = _context;
        }

        public  IEnumerable<Book> GetBooksByAuthorEF(int authorId)
        {
            return context.Books
                .Where(b => b.AuthorId == authorId)
                .ToList();
        }

        public IEnumerable<Book> GetBooksByAuthorSQL(int authorId)
        {
            return context.Books
                .FromSqlRaw("EXEC GetBooksByAuthor @AuthorId", new SqlParameter("@AuthorId", authorId))
                .ToList();
        }

        public IEnumerable<Book> GetBooksBySubId(int subId)
        {
            return context.Books
                .Where(b => b.SubCategoryId == subId)
                .ToList();
        }
    }
}
