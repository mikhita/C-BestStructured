namespace ConsoleApp1.Recipes.Ingredients
{
    public class Cardamon : Ingredient
    {
        public override int Id => 6;
        public override string Name => "Cardamon";

        public override string PreparationInstruction => $"Cardamon, {base.PreparationInstruction}";
    }
}
