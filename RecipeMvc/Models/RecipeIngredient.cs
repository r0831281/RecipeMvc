namespace RecipeMvc.Models
{
	public class RecipeIngredient
	{
        public int Id { get; set; }
		public double Measurement { get; set; }
		public string Unit { get; set; }
		public int IngredientId { get; set; }
		public int RecipeId { get; set; }
		public Recipe? Recipe { get; set; }
		public Ingredient? Ingredient { get; set; }
    }
}
