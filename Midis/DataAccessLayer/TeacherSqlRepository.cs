using DocumentFormat.OpenXml.Office2010.Excel;
using Midis.Abstract;
using Midis.Data;
using Midis.Domains;
using NuGet.Protocol.Core.Types;

namespace Midis.DataAccessLayer
{
    public class TeacherSqlRepository : IRepository<UserMidis>
    {
        private readonly ApplicationDbContext _context;
        public TeacherSqlRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(UserMidis entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entry = _context.Users.Find(id);
            _context.Users.Remove(entry);
            _context.SaveChanges();
        }

        public UserMidis Read(string? Id)
        {
            var entry = _context
            .Users
                .FirstOrDefault(p => p.Id == Id);
            return entry;
        }

        public UserMidis Read(long? Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserMidis> ReadList()
        {
            var role = _context.Roles.Where(r => r.Name == "Учитель").First();
            var userRole = _context.UserRoles.Where(ur => ur.RoleId == role.Id);
            var teachers = new List<UserMidis>();

            foreach (var item in userRole)
            {
                teachers.Add(_context.Users.Where(u => u.Id == item.UserId).First());
            }
            return teachers;
        }

        public void Update(UserMidis entity)
        {
            throw new NotImplementedException();
        }
    }
}
