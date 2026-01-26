using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaArena_API.Models
{
    public class ChefSpecial
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string CustomNote { get; set; }
    }
}

