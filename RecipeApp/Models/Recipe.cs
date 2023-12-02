using MongoDB.Bson;

namespace RecipeApp.Models
{
    public class Recipe
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
    }
}
