using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FiledRecipes.Domain
{
    /// <summary>
    /// Holder for recipes.
    /// </summary>
    public class RecipeRepository : IRecipeRepository
    {
        /// <summary>
        /// Represents the recipe section.
        /// </summary>
        private const string SectionRecipe = "[Recept]";

        /// <summary>
        /// Represents the ingredients section.
        /// </summary>
        private const string SectionIngredients = "[Ingredienser]";

        /// <summary>
        /// Represents the instructions section.
        /// </summary>
        private const string SectionInstructions = "[Instruktioner]";

        /// <summary>
        /// Occurs after changes to the underlying collection of recipes.
        /// </summary>
        public event EventHandler RecipesChangedEvent;

        /// <summary>
        /// Specifies how the next line read from the file will be interpreted.
        /// </summary>
        private enum RecipeReadStatus { Indefinite, New, Ingredient, Instruction };

        /// <summary>
        /// Collection of recipes.
        /// </summary>
        private List<IRecipe> _recipes;

        /// <summary>
        /// The fully qualified path and name of the file with recipes.
        /// </summary>
        private string _path;

        /// <summary>
        /// Indicates whether the collection of recipes has been modified since it was last saved.
        /// </summary>
        public bool IsModified { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the RecipeRepository class.
        /// </summary>
        /// <param name="path">The path and name of the file with recipes.</param>
        public RecipeRepository(string path)
        {
            // Throws an exception if the path is invalid.
            _path = Path.GetFullPath(path);

            _recipes = new List<IRecipe>();
        }

        /// <summary>
        /// Returns a collection of recipes.
        /// </summary>
        /// <returns>A IEnumerable&lt;Recipe&gt; containing all the recipes.</returns>
        public virtual IEnumerable<IRecipe> GetAll()
        {
            // Deep copy the objects to avoid privacy leaks.
            return _recipes.Select(r => (IRecipe)r.Clone());
        }

        /// <summary>
        /// Returns a recipe.
        /// </summary>
        /// <param name="index">The zero-based index of the recipe to get.</param>
        /// <returns>The recipe at the specified index.</returns>
        public virtual IRecipe GetAt(int index)
        {
            // Deep copy the object to avoid privacy leak.
            return (IRecipe)_recipes[index].Clone();
        }

        /// <summary>
        /// Deletes a recipe.
        /// </summary>
        /// <param name="recipe">The recipe to delete. The value can be null.</param>
        public virtual void Delete(IRecipe recipe)
        {
            // If it's a copy of a recipe...
            if (!_recipes.Contains(recipe))
            {
                // ...try to find the original!
                recipe = _recipes.Find(r => r.Equals(recipe));
            }
            _recipes.Remove(recipe);
            IsModified = true;
            OnRecipesChanged(EventArgs.Empty);
        }

        /// <summary>
        /// Deletes a recipe.
        /// </summary>
        /// <param name="index">The zero-based index of the recipe to delete.</param>
        public virtual void Delete(int index)
        {
            Delete(_recipes[index]);
        }

        /// <summary>
        /// Raises the RecipesChanged event.
        /// </summary>
        /// <param name="e">The EventArgs that contains the event data.</param>
        protected virtual void OnRecipesChanged(EventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of 
            // a race condition if the last subscriber unsubscribes 
            // immediately after the null check and before the event is raised.
            EventHandler handler = RecipesChangedEvent;

            // Event will be null if there are no subscribers. 
            if (handler != null)
            {
                // Use the () operator to raise the event.
                handler(this, e);
            }
        }
        public void Load()
        {
            //Skapa lista som kan innehålla referencer till receptobjekt
            List<IRecipe> listRecipes = new List<IRecipe>();
            RecipeReadStatus recipeStatus = new RecipeReadStatus();

            //Öppna textfilen för läsning
            using (StreamReader reader = new StreamReader(_path))
            {
                Recipe myRecipe = null;
                string line;
                //Läs rad från textfilen tills det är slut på filen
                while ((line = reader.ReadLine()) != null)
                {
                    //Om det är en tom rad fortsätt med att läsa in nästa rad
                    if (line.Length == 0) { continue; }
                    //om det är en avdelning för nytt recept
                    if (line == SectionRecipe)
                    {
                        recipeStatus = RecipeReadStatus.New;
                    }
                    //eller om det är avdelning för ingridienser
                    else if (line == SectionIngredients)
                    {
                        recipeStatus = RecipeReadStatus.Ingredient;
                    }
                    //eller om det är avdelningen för instruktioner
                    else if (line == SectionInstructions)
                    {
                        recipeStatus = RecipeReadStatus.Instruction;
                    }
                    //annars är det ett namn, en ingridiens eller en instruktion
                    else
                    {
                        if (recipeStatus == RecipeReadStatus.New)
                        {
                            myRecipe = new Recipe(line);
                            listRecipes.Add(myRecipe);
                        }
                        //eller om status är satt att raden ska tolkas som ett recepts namn
                        else if (recipeStatus == RecipeReadStatus.Ingredient)
                        {
                            string[] values = line.Split(';');
                            //Om antalet delar inte är tre
                            if (values.Length != 3)
                            {
                                throw new FileFormatException();
                            }
                            //Skapa ett ingridientsobjekt och initiera det med de tre delarna för mängd, mått och namn
                            Ingredient ingredient = new Ingredient();
                            ingredient.Amount = values[0];
                            ingredient.Measure = values[1];
                            ingredient.Name = values[2];

                            //Lägg till ingridiensen till receptets lista med ingridienser
                            myRecipe.Add(ingredient);
                        }
                        //eller om status är satt att raden ska tolkas som en instruktion
                        else if (recipeStatus == RecipeReadStatus.Instruction)
                        {
                            myRecipe.Add(line);
                        }
                        else
                        {
                            throw new FileFormatException();
                        }
                    }

                }
                //Sortera listan med recept med avseende på receptens namn
                _recipes = listRecipes.OrderBy(sort => sort.Name).ToList();

                //Tilldela avsedd egenskap i klassen, IsModified, ett värde som indikera att listan med recept är oförändrad
                IsModified = false;

                //Utlös händelse om att recept har läst in genom att anropa metoden OnRecipesChanged och skicka med parametern EventArgs.Empty
                OnRecipesChanged(EventArgs.Empty);

            }
        }
        public void Save()
        {
            //Skapar en StreamWriter-objekt och skriver strängar till filen recipe.txt
            using (StreamWriter writer = new StreamWriter(_path))
            {
                foreach (var recipe in _recipes)
                {
                    writer.WriteLine(SectionRecipe);
                    writer.WriteLine(recipe.Name);
                    writer.WriteLine(SectionIngredients);

                    foreach (var ingridient in recipe.Ingredients)
                    {
                        writer.WriteLine("{0};{1};{2}", ingridient.Amount, ingridient.Measure, ingridient.Name);
                    }
                    writer.WriteLine(SectionInstructions);
                    foreach (string instruction in recipe.Instructions)
                    {
                        writer.WriteLine(instruction);
                    }
                }
            }
        }
    }
}