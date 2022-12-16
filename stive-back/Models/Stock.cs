namespace stive_back.Models;
using System.ComponentModel.DataAnnotations;

public class Stock
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Quantity { get; set; }
    
    public string Comment { get; set; }
    
    public Product Product { get; set; }
    
    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}