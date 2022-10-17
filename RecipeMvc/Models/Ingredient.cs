using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeMvc.Models
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
        public decimal PircePerUnit { get; set; }
		public string Unit { get; set; }

	}
}
