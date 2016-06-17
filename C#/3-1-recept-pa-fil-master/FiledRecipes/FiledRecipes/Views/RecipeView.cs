using FiledRecipes.Domain;
using FiledRecipes.App.Mvp;
using FiledRecipes.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FiledRecipes.Views
{
    /// <summary>
    /// 
    /// </summary>
    public class RecipeView : ViewBase, IRecipeView
    {
        public void Show(IRecipe recipe)
        {
            Header = recipe.Name; //tilldela receptens namn i headern
            ShowHeaderPanel(); // visa headern
            Console.WriteLine("\nIngridienser\n===================");
            //Skriver ut ingridienserna med en radbrytning
            foreach (IIngredient ingridient in recipe.Ingredients)
            {
                Console.WriteLine(ingridient);
            }
            int count = 1;
            Console.WriteLine("\nGör så här\n===================");
            //skriver ut instruktioner samt nummrering som ökas varje gång
            foreach (string instruction in recipe.Instructions)
            {
                Console.WriteLine("<{0}>", count++);
                Console.WriteLine("{0}\n", instruction);
            }
        }
        public void Show(IEnumerable<IRecipe> recipes)
        {
            //visa alla recepten
            foreach (Recipe recipe in recipes)
            {
                Show(recipe);
                ContinueOnKeyPressed();
            }

        }
    }
}