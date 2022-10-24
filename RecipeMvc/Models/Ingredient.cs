using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeMvc.Models
{
	public class Ingredient
	{
		public int IngredientId { get; set; }
		public string Name { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 100.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal PircePerUnit { get; set; }
		public string Unit { get; set; }

	}
}
