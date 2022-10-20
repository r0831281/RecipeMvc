namespace RecipeMvc.Models
{
	public class RecipeIngredient
	{
		public RecipeIngredient(int ingredientId, int recipeId)
		{
			IngredientId = ingredientId;
			RecipeId = recipeId;
		}

        public int Id { get; set; }
		public double Measurment { get; set; }
		public string Unit { get; set; }

		public string Instructions { get; set; }
		public int IngredientId { get; set; }
		public int RecipeId { get; set; }
		public Recipe? Recipe { get; set; }
		public Ingredient? Ingredient { get; set; }
    }
}
