using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Midis.Data;
using Midis.Domains;

namespace Midis.DataAccessLayer
{
    public class ScheduleSqlRepository : SqlRepository<Schedule>
    {
        public ScheduleSqlRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override IEnumerable<Schedule> ReadList()
        {
            return _context.Schedules
            .Include(x => x.Teacher)
            .Include(x => x.Group)
            .Include(x => x.Item);
        }
    }
}
