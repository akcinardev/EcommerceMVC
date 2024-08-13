using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceWeb.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(20, ErrorMessage = "Name can not exceed 20 characters!")]
        public string Name { get; set; }

		[DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100!")]
		public int DisplayOrder { get; set; }
    }
}
