namespace RecipeMvc.Models
{
	public class RecipeIngredient
	{
		public int Id { get; set; }
		public double Measurment { get; set; }
		public string Unit { get; set; }

		public string Instructions { get; set; }
		public Recipe? Recipe { get; set; }
		public Ingredient? Ingredient { get; set; }
	}
}
