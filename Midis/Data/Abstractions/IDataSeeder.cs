using Midis.Models;
using Microsoft.AspNetCore.Identity;
using Midis.Domains;

namespace Midis.Data.Abstractions
{
    public interface IDataSeeder
    {
        Task Seed(UserManager<UserMidis> userManager, RoleManager<IdentityRole> roleManager);
    }
}
