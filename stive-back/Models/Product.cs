using System;
using System.ComponentModel.DataAnnotations;

namespace stive_back.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public virtual List<ProductImage> ProductImages { get; set; }
        
        public string Reference { get; set; }
        
        public float Price { get; set; }
        
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        
        public virtual List<Stock> Stocks { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}

