using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Midis.Domains;
using System.Data;

namespace Midis.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserMidis>
    {
        public DbSet<AssessmentJournal> AssessmentJournals { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<NumberGroup> Groups { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
