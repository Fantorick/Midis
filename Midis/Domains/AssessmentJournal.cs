using Microsoft.AspNetCore.Identity;
using Midis.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Midis.Domains
{
    public class AssessmentJournal : IEntity
    {
        [Key]
        public long Id { get; set; }
        public DateOnly Data { get; set; }
        // Номер пары
        public int PairNumber { get; set; }
        public virtual Item Item { get; set; }
        public virtual UserMidis Student { get; set; }
        // Оценка
        public char Grade { get; set; }
    }
}
