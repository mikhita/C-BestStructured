

using ConsoleApp1.Recipes;
using ConsoleApp1.Recipes.Ingredients;

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(), new RecipeConsoleUserInterection());
cookiesRecipesApp.Run("recipes.txt");

public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInterection _recipesUserInterection;
    public CookiesRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInterection recipesUserInterection)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInterection = recipesUserInterection;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInterection.PrintExistingRecipes(allRecipes);
        //_recipesUserInterection.PromptToCreateRecipe();
        //var ingredients = _recipesUserInterection.ReadIngredientsFromUser();
        //if(ingredients.Count > 0) 
        //{
        //    var recipe = new Recipe(ingredients);
        //    allRecipes.Add(recipe);
        //    _recipesRepository.Write(filePath, allRecipes);
        //    _recipesRepository.ShowMessage("Ingredient added:");
        //    _recipesRepository.ShowMessage(recipe.ToString());
        //}else
        //{
        //    Console.WriteLine("No ingredients was choosen" + 
        //        "recipe will not be saved!");
        //}
        _recipesUserInterection.Exit();
    }

}

public interface IRecipesUserInterection
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
}

public class RecipeConsoleUserInterection : IRecipesUserInterection
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing reciepes are:" + Environment.NewLine);

            var count = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{count}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                count++;
            }
        }
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
}
public class RecipesRepository : IRecipesRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>
        {
            new Recipe(new List<Ingredient>
            {
                new Weatflour(),
                new Speltflour(),
                new Butter()
            }),
            new Recipe(new List<Ingredient>
            {
                new Cardamon(),
                new Chocolate(),
                new Cinnamon()
            }),
            new Recipe(new List<Ingredient>
            {
                new CocoaPowder(),
                new Sugar(),
                new Butter()
            })
        };
    }
}