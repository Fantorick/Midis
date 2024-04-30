using Microsoft.AspNetCore.Identity;
using Midis.Domains;

namespace Midis.Models
{
    public class UsersModel
    {
        public int Count { get; set; }
        public List<string> Role { get; set; }
        public List<string> Group { get; set; }
        public List<UsersModel> Users { get; set; }
    }
}
