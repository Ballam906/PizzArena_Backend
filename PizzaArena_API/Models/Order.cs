using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaArena_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Other { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string User_Id { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.Now;
    }
}
