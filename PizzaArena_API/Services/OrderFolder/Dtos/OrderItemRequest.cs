namespace PizzaArena_API.Services.OrderFolder.Dtos
{
    public class OrderItemRequest
    {
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public int ItemPrice { get; set; }
        public string ItemName { get; set; }
    }
}
