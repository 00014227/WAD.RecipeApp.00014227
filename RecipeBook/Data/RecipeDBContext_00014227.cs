using Microsoft.EntityFrameworkCore;
using RecipeBook.Model;

namespace RecipeBook.Data
{
    public class RecipeDBContext_00014227 : DbContext
    {
        public RecipeDBContext_00014227(DbContextOptions<RecipeDBContext_00014227> options) : base(options) { }
        public DbSet<RecipeBookItems_00014227> RecipeBookItems { get; set; }
        public DbSet<Category_00014227> Categories { get; set; }
    }
}
