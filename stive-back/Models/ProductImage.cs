namespace stive_back.Models;
using System.ComponentModel.DataAnnotations;

public class ProductImage
{
    [Key]
    public int Id { get; set; }
    
    public string Url { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}