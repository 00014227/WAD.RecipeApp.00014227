using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Model;

namespace RecipeBook.Repositories
{
    public class RecipeBookRepository:IRepository<RecipeBookItems>
    {
        // Private entity of deb context initiation
        private readonly RecipeDBContext _dbContext;

        //Construictor

        public RecipeBookRepository(RecipeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Create new entity

        public async Task AddAsync(RecipeBookItems entity)
        {
            entity.Category = await _dbContext.Categories.FindAsync(entity.CategoryID.Value);
            await _dbContext.RecipeBookItems.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        //Delete entity

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.RecipeBookItems.FindAsync(id);
            if (entity != null)
            {
                _dbContext.RecipeBookItems.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // GetAll entity

        public async Task<IEnumerable<RecipeBookItems>> GetAllAsync() => await _dbContext.RecipeBookItems.ToArrayAsync();

        // Get By Id

        public async Task<RecipeBookItems> GetByIDAsync(int id) 
        {
            return await _dbContext.RecipeBookItems.Include(t=>t.Category).FirstOrDefaultAsync(t => t.Id == id);
        } 


        // Update entity

        public async Task UpdateAsync(RecipeBookItems entity)
        {
            _dbContext.Entry(entity).State= EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

    }
}
