namespace PizzaArena_API.Services.OrderFolder.Dtos
{
    public class OrderCreateRequest
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Other { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }

        // A kosár tartalma (tételek)
        public List<OrderItemRequest> Items { get; set; }
    }
}
