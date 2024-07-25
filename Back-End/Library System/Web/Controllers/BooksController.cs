using Domin;
using Infrastructure.Services.Generic;
using Infrastructure.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository repo;

        public BooksController(IBookRepository _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var books = repo.GetAll();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = repo.Get(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("ByAuthorSQL/{authorId}")]
        public ActionResult<Book> GetBooksByAuthorSQL(int authorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = repo.GetBooksByAuthorSQL(authorId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("ByAuthorEF/{authorId}")]
        public ActionResult<Book> GetBooksByAuthorEF(int authorId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var book = repo.GetBooksByAuthorEF(authorId);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> Create(BookDTO book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (book == null)
            {
                return BadRequest();
            }
            var addBook = new Book()
            {
                Title = book.Title,
                PublicationYear = book.PublicationYear,
            };
            repo.Add(addBook);
            repo.SavaChanges();
            return Ok(addBook);
        }
        [HttpPut("{id}")]
        public ActionResult<Book> Update(int id, BookDTO book)
        { 
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            if (book == null)
                return BadRequest();

            var Book = repo.Get(id);
            if(Book == null)
                return NotFound();

            Book.Title = book.Title;
            Book.PublicationYear = book.PublicationYear;

            repo.Update(Book);
            repo.SavaChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)    
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var book = repo.Get(id);
            if (book == null)
                return NotFound();

            repo.Delete(book);
            repo.SavaChanges();
            return NoContent();
        }


    }
}
