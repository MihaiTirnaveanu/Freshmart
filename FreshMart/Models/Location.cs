namespace FreshMart.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string TimeSchedule { get; set; }

        public ICollection<Category>? Categories { get; set; }
    }
}
