using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Title can not exceed 30 characters.")]
        public string Title { get; set; }

        [Required]
		[MaxLength(300, ErrorMessage = "Description can not exceed 300 characters.")]
		public string Description { get; set; }

        [Required]
		[MaxLength(30, ErrorMessage = "ISBN can not exceed 30 characters.")]
		public string ISBN { get; set; }
        
        [Required]
		[MaxLength(30, ErrorMessage = "Author can not exceed 30 characters.")]
		public string Author { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "Category can not be left blank.")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
