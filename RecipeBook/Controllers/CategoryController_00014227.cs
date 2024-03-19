using Microsoft.AspNetCore.Mvc;
using RecipeBook.Model;
using RecipeBook.Repositories;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController_00014227 : ControllerBase
    {
        private readonly IRepository_00014227<Category_00014227> _categoryRepository;
        public CategoryController_00014227(IRepository_00014227<Category_00014227> repository)
        {
            _categoryRepository = repository;
        }



        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Create(Category_00014227 categories)
        {
            await _categoryRepository.AddAsync(categories);
            return CreatedAtAction(nameof(GetByID), new { id = categories.ID }, categories);
        }



        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category_00014227>> Get()
        {
            return await _categoryRepository.GetAllAsync();
        }








        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var resultedCategory = await _categoryRepository.GetByIDAsync(id);
            if (resultedCategory == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(resultedCategory);
            }
        }



        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.DeleteAsync(id);
            return NoContent();
        }









        // PUT api/<CategoryController>/5
        [HttpPut]
        public async Task<IActionResult> Update(Category_00014227 categories)
        {
            //if(id!=items.ID) return BadRequest();
            await _categoryRepository.UpdateAsync(categories);
            return NoContent();
        }






    

    }
}
