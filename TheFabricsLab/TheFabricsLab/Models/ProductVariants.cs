using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TheFabricsLab.Models
{
    public class ProductVariants
    {
        [Key]
        public int VariantID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
        public string Color { get; set; }
        [Precision(16,2)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageFile { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
