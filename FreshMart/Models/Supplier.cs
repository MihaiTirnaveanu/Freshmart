namespace FreshMart.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Product>? Products { get; set; }

    }
}
