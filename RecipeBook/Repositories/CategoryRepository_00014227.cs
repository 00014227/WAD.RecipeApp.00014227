﻿using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Model;

namespace RecipeBook.Repositories
{
    public class CategoryRepository_00014227 : IRepository_00014227<Category_00014227>
    {
        private readonly RecipeDBContext_00014227 _context;

        public CategoryRepository_00014227(RecipeDBContext_00014227 context)
        {
            _context = context;
        }

        // Add or create new entity
        public async Task AddAsync(Category_00014227 categories)
        {
            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();
        }

        // Delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Categories.FindAsync(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Category_00014227>> GetAllAsync() => await _context.Categories.ToArrayAsync();

        // Retrieve an entity from database using only an id
        public async Task<Category_00014227> GetByIDAsync(int id) => await _context.Categories.FindAsync(id);

        // Update the entity
        public async Task UpdateAsync(Category_00014227 categories)
        {
            _context.Entry(categories).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
