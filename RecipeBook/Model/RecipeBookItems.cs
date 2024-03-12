using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.Model
{
    public class RecipeBookItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public int CookingTimeInMinutes { get; set; }
        public DateTime CreatedAt { get; set; }

        // Nullable foreign key
        public int? CategoryID { get; set; }

        // Navigation property
        [ForeignKey("CategoryID")]
        public Category? Category { get; set; }
    }
}
