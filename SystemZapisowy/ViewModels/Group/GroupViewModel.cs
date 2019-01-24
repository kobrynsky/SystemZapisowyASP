using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Day;

namespace SystemZapisowy.ViewModels.Group
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public string Type { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public int DayId { get; set; }
        public string Teacher { get; set; }
        public int MaximumSeats { get; set; }
        public int OccupiedSeats { get; set; }
        public CourseViewModel Cours { get; set; }
        public DayViewModel Day { get; set; }
    }
}