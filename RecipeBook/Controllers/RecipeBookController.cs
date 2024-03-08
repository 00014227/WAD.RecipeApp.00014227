using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Model;
using RecipeBook.Repositories;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeBookController : ControllerBase
    {
        private readonly IRepository<RecipeBookItems> _recipeItemsRepository;
        public RecipeBookController(IRepository<RecipeBookItems> recipeItemsRepository)
        {
            _recipeItemsRepository = recipeItemsRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RecipeBookItems>> GetAll() => await _recipeItemsRepository.GetAllAsync();
        [HttpGet("id")]
        [ProducesResponseType(typeof(RecipeBookItems), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetByID(int id)
        {
            var resultedToDo = await _recipeItemsRepository.GetByIDAsync(id);
            return resultedToDo == null ? NotFound() : Ok(resultedToDo);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Create(RecipeBookItems items)
        {
            await _recipeItemsRepository.AddAsync(items);
           

            return CreatedAtAction(nameof(GetByID), new { id = items.Id }, items);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
      
            await _recipeItemsRepository.DeleteAsync(id);
            return NoContent();


        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, RecipeBookItems items)
        {
            if (id != items.Id) return BadRequest();
            await _recipeItemsRepository.UpdateAsync(items);

            return NoContent();
        }

    }
}
