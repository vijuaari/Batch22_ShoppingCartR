using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCartR.Models
{
    public class ProductImage
    {
        public int ProductImageId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [ForeignKey ("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
