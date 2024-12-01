using Microsoft.AspNetCore.Identity;

namespace OHD_API.Models
{
    public class User : IdentityUser
    {
<<<<<<< HEAD
=======
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
>>>>>>> 1b8b0fcaa8e36160a20d035239584e895dc31639
    }
}
