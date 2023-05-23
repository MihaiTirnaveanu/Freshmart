using System.ComponentModel;

namespace FreshMart.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public double Price { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
    }
}
