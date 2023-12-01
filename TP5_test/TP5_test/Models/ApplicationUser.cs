using Microsoft.AspNetCore.Identity;

namespace TP5_test.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string city { get; set; }
    }
}
