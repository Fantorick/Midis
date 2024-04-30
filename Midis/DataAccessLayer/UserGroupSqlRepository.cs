using Microsoft.EntityFrameworkCore;
using Midis.Data;
using Midis.Domains;

namespace Midis.DataAccessLayer
{
    public class UserGroupSqlRepository : SqlRepository<UserGroup>
    {
        public UserGroupSqlRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override IEnumerable<UserGroup> ReadList()
        {
            return _context.UserGroups
            .Include(x => x.User)
            .Include(x => x.Group);
        }
        public IEnumerable<UserMidis> ReadListUsers()
        {
            return _context.Users;
        }
    }
}
