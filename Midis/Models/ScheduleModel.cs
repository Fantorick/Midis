using Midis.Domains;

namespace Midis.Models
{
    public class ScheduleModel
    {
        public IEnumerable<Schedule> Schedules { get; set; }

        public ScheduleModel() { }
        public ScheduleModel(IEnumerable<Schedule> s) 
        {
            Schedules = s;
        }

    }
}
