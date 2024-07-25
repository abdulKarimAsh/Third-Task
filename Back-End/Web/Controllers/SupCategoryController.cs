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
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository repo;

        public SubCategoryController(ISubCategoryRepository _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public ActionResult<List<SubCategory>> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var SubCategories = repo.GetAll();
            if (SubCategories == null)
            {
                return NotFound();
            }
            return Ok(SubCategories);
        }

        [HttpGet("{id}")]
        public ActionResult<SubCategory> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var SubCategory = repo.Get(id);
            if (SubCategory == null)
            {
                return NotFound();
            }
            return Ok(SubCategory);
        }
        [HttpGet("GetSubByCateoryId/{categoryid}")]
        public ActionResult<SubCategory> GetSubByCateoryId(int categoryid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var SubCategory = repo.GetSubByCategoryId(categoryid);
            if (SubCategory == null)
            {
                return NotFound();
            }
            return Ok(SubCategory);
        }

        [HttpPost]
        public ActionResult<SubCategory> Create(SubCategoryDTO SubCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (SubCategory == null)
            {
                return BadRequest();
            }
            var addSubCategory = new SubCategory()
            {
                Name = SubCategory.Name,
                CategoryId = SubCategory.CategoryId
            };
            repo.Add(addSubCategory);
            repo.SavaChanges();
            return Ok(addSubCategory);
        }

        [HttpPut("{id}")]
        public ActionResult<SubCategory> Update(int id, SubCategoryDTO SubCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (SubCategory == null)
                return BadRequest();

            var updateSubCategory = repo.Get(id);
            if (updateSubCategory == null)
                return NotFound();

            updateSubCategory.Name = SubCategory.Name;
            updateSubCategory.CategoryId = SubCategory.CategoryId;

            repo.Update(updateSubCategory);
            repo.SavaChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<SubCategory> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var SubCategory = repo.Get(id);
            if (SubCategory == null)
                return NotFound();

            repo.Delete(SubCategory);
            repo.SavaChanges();
            return NoContent();
        }
    }
}
