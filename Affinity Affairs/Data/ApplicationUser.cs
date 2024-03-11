using Microsoft.AspNetCore.Identity;

namespace Affinity_Affairs.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
