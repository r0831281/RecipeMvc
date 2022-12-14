using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeMvc.Models.ViewModels
{
    public class RecipeIngredientsViewModel
    {
        public Recipe Recipe { get; set; }
        public List<RecipeIngredient>? RecipeIngredients { get; set; }
        public RecipeIngredient RecipeIngredient { get; set; }
        public SelectList? Ingredients { get; set; }
    }
}
