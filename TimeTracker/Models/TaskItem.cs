using System.Globalization;

namespace TimeTracker.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = new Guid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsRunning { get; set; } = false;
        public bool IsCompleted { get; set; }= false;

        public TimeSpan ElapsedTime
        {
            get
            {
                if (StartTime == null)
                {
                    return TimeSpan.Zero;
                }
                if (IsRunning)
                {
                    return DateTime.Now - StartTime.Value;
                }else if(EndTime!=null){
                    return EndTime.Value - StartTime.Value;
                }
                return TimeSpan.Zero;
            }
        }

        public string FormattedTime
        {
            get
            {
                return $"{ElapsedTime.Hours}:{ElapsedTime.Minutes}:{ElapsedTime.Seconds}";
            }
        }
    }
}
