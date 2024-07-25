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
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> repo;

        public AuthorController(IRepository<Author> _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Authors = repo.GetAll();
            if (Authors == null)
            {
                return NotFound();
            }
            return Ok(Authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Author = repo.Get(id);
            if (Author == null)
            {
                return NotFound();
            }
            return Ok(Author);
        }

        [HttpPost]
        public ActionResult<Author> Create(AuthorDTO Author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Author == null)
            {
                return BadRequest();
            }
            var addAuthor = new Author()
            {
                Name = Author.Name,
                DateOfBirth = Author.DateOfBirth
            };
            repo.Add(addAuthor);
            repo.SavaChanges();
            return Ok(addAuthor);
        }

        [HttpPut("{id}")]
        public ActionResult<Author> Update(int id, AuthorDTO author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (author == null)
                return BadRequest();

            var updateAuthor = repo.Get(id);
            if (updateAuthor == null)
                return NotFound();

            updateAuthor.Name = author.Name;
            updateAuthor.DateOfBirth = author.DateOfBirth;

            repo.Update(updateAuthor);
            repo.SavaChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Author> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Author = repo.Get(id);
            if (Author == null)
                return NotFound();

            repo.Delete(Author);
            repo.SavaChanges();
            return NoContent();
        }
    }
}
