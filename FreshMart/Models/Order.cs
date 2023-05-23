namespace FreshMart.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string Code { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }

    }
}
