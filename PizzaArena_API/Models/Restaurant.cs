namespace PizzaArena_API.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string ImageUrl { get; set; }   
        public string OpeningHours { get; set; } 
        public string Address { get; set; }
    }
}
