using Microsoft.AspNetCore.Identity;
using Midis.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Midis.Domains
{
    public class Schedule : IEntity
    {
        [Key]
        public long Id { get; set; }
        // Чётность недели
        public bool ParityOfTheWeek { get; set; }
        // День недели
        public int DayOfTheWeek { get; set; }
        public virtual NumberGroup Group{ get; set; }
        // Номер пары
        public int PairNumber { get; set; }
        public virtual Item Item { get; set; }
        public string Cabinet { get; set; }
        public virtual UserMidis Teacher { get; set; }
    }
}
