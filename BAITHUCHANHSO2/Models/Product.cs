using System.ComponentModel.DataAnnotations;

namespace BAITHUCHANHSO2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        // navigation property thuộc tính điều hướng 
    }
}
