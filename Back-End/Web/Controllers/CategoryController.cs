using Domin;
using Infrastructure.Services.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.DTOs;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> repo;

        public CategoryController(IRepository<Category> _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Categories = repo.GetAll();
            if (Categories == null)
            {
                return NotFound();
            }
            return Ok(Categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Category = repo.Get(id);
            if (Category == null)
            {
                return NotFound();
            }
            return Ok(Category);
        }

        [HttpPost]
        public ActionResult<Category> Create(CategoryDTO Category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Category == null)
            {
                return BadRequest();
            }
            var addCategory = new Category()
            {
                Name = Category.Name
            };
            repo.Add(addCategory);
            repo.SavaChanges();
            return Ok(addCategory);
        }

        [HttpPut("{id}")]
        public ActionResult<Category> Update(int id, CategoryDTO Category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (Category == null)
                return BadRequest();

            var updateCategory = repo.Get(id);
            if (updateCategory == null)
                return NotFound();

            updateCategory.Name = Category.Name;

            repo.Update(updateCategory);
            repo.SavaChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Category = repo.Get(id);
            if (Category == null)
                return NotFound();

            repo.Delete(Category);
            repo.SavaChanges();
            return NoContent();
        }
    }
}
