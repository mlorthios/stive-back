using System;
namespace stive_back.DTOs.Product
{
    public class ProductRequest
    {
        public string Name { get; set; }
        
        public string Description { get; set; }

        public List<string> Images { get; set; }
        
        public string Reference { get; set; }
        
        public float Price { get; set; }
        
        public int Category { get; set; }
    }
}

