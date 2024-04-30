using Microsoft.AspNetCore.Identity;

namespace Midis.Domains
{
    public class UserMidis : IdentityUser
    {
        public string FullName { get; set; }
    }
}
