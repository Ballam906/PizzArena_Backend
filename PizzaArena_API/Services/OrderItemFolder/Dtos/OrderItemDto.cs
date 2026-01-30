namespace PizzaArena_API.Services.OrderItemFolder.Dtos
{
    public class OrderItemDto
    {
        public record OrderItemAddDto(int ItemPrice, int Piece, int Order_Id, int Item_Id);
        public record OrderItemUpdateDto(int ItemPrice, int Piece);
    }
}
