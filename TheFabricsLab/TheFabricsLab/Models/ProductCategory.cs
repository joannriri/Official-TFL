using System.ComponentModel.DataAnnotations;

namespace TheFabricsLab.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryID {  get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
