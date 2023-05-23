namespace FreshMart.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice => Quantity * Product.Price;

        public int ProductId { get; set; }

        public int ShoppingCartId { get; set; }

        public Product? Product { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
