using Microsoft.EntityFrameworkCore;
using RecipeBook.Model;

namespace RecipeBook.Data
{
    public class RecipeDBContext : DbContext
    {
        public RecipeDBContext(DbContextOptions<RecipeDBContext> options) : base(options) { }
        public DbSet<RecipeBookItems> RecipeBookItems { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
