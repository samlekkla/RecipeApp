using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using RecipeApp.Models;

namespace RecipeApp.Controllers
{
    public class IngredientsController : Controller
    {
        public IActionResult Index()
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("recipe_app");
            var collection = database.GetCollection<Ingredient>("ingredients");

            List<Ingredient> ingredients = collection.Find(i => true).ToList();
            return View(ingredients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ingredient ingredient)
        {
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("recipe_app");
            var collection = database.GetCollection<Ingredient>("ingredients");
            collection.InsertOne(ingredient);

            return Redirect("/Ingredients");
        }

        public IActionResult Show(string Id)
        {
            ObjectId ingredientId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("recipe_app");
            var collection = database.GetCollection<Ingredient>("ingredients");

            Ingredient ingredient = collection.Find(i => i.Id == ingredientId).FirstOrDefault();

            return View(ingredient);
        }

        public IActionResult Edit(string Id)
        {
            ObjectId ingredientId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("recipe_app");
            var collection = database.GetCollection<Ingredient>("ingredients");

            Ingredient ingredient = collection.Find(i => i.Id == ingredientId).FirstOrDefault();

            return View(ingredient);

        }

        [HttpPost]
        public IActionResult Edit(String Id, Ingredient Ingredient)
        {
            ObjectId ingredientId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("recipe_app");
            var collection = database.GetCollection<Ingredient>("ingredients");

            Ingredient.Id = ingredientId;
            collection.ReplaceOne(i => i.Id == ingredientId, Ingredient);

            return Redirect("/Ingredients");
        }

        public IActionResult Delete(string Id)
        {
            ObjectId ingredientId = new ObjectId(Id);
            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("recipe_app");
            var collection = database.GetCollection<Ingredient>("ingredients");

            collection.DeleteOne(i => i.Id == ingredientId);

            return Redirect("/Ingredients");

        }

    }
}
