﻿namespace ConsoleApp1.Recipes.Ingredients
{
    public class Chocolate : Ingredient
    {
        public override int Id => 4;
        public override string Name => "Chocolate";

        public override string PreparationInstruction => $"Chocolate, {base.PreparationInstruction}";
    }
}
