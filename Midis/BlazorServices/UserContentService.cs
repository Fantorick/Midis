using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Midis.Abstract;
using Midis.Domains;

namespace Midis.BlazorServices
{
    public class UserContentService : ContentService
    {

        protected readonly UserManager<UserMidis> userManager;
        protected readonly RoleManager<IdentityRole> role;
        protected IRepository<UserGroup> userGroup;

        public UserContentService(IRepository<NumberGroup> repositoryGroup,
            IRepository<Item> repositoryItem, 
            IRepository<Schedule> repositorySchedule,
            IRepository<UserMidis> repositoryTeacher,
            IRepository<UserGroup> userGroup,
            RoleManager<IdentityRole> role,
            UserManager<UserMidis> userManager) : base(repositoryGroup, repositoryItem, repositorySchedule, repositoryTeacher)
        {
            this.userManager = userManager;
            this.role = role;
            this.userGroup = userGroup;
            
        }
        public UserManager<UserMidis> GetRepositoryUser()
        {
            return userManager;
        }
        public RoleManager<IdentityRole> GetRepositoryRole()
        {
            return role;
        }
        public IRepository<UserGroup> GetRepositoryUserGroup()
        {
            return userGroup;
        }
    }
}
