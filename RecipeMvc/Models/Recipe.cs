namespace RecipeMvc.Models
{
	public class Recipe
	{
		public int RecipeId { get; set; }
		public string Name { get; set; }
		public int RecipePortions { get; set; }
		public string Instructions { get; set; }
		public ICollection<RecipeIngredient>? Ingredients { get; set; }	
	}
}
