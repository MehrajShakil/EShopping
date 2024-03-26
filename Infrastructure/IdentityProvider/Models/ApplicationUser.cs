using Microsoft.AspNetCore.Identity;

namespace IdentityProvider.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
