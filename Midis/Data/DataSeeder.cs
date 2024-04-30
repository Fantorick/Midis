using Midis.Data.Abstractions;
using Midis.Models;
using Microsoft.AspNetCore.Identity;
using Midis.Domains;
using DocumentFormat.OpenXml.Spreadsheet;
using Midis.BlazorServices;

namespace Midis.Data
{
    public class DataSeeder : IDataSeeder
    {
        public async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] rolesNames =
            {
                "Админ",
                "Студент",
                "Учитель"
            };

            foreach (var roleName in rolesNames)
            {
                var role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }

        public async Task CreateUsers(UserManager<UserMidis> userManager)
        {            
            var admin = new UserMidis
            {
                Email = "admin@mail.ru",
                UserName = "admin@mail.ru",
                FullName = "Администратор",
            };
            await userManager.CreateAsync(admin, "aA123456!");
            await userManager.AddToRoleAsync(admin, "Админ");
        }
        public async Task Seed(UserManager<UserMidis> userManager, RoleManager<IdentityRole> roleManager)
        {
            await CreateRoles(roleManager);
            await CreateUsers(userManager);
        }
    }
}
