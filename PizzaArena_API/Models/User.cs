using Microsoft.AspNetCore.Identity;

namespace PizzaArena_API.Models
{
    public class User : IdentityUser
    {
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }
}
