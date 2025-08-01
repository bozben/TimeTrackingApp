using System.Globalization;

namespace TimeTracker.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsRunning { get; set; } = false;
        public bool IsCompleted { get; set; }= false;
        public bool ShowFullDescription { get; set; } = false;

        public TimeSpan TotalElapsedTime { get; set; } = TimeSpan.Zero;
        public TimeSpan ElapsedTime
        {
            get
            {
                if (IsRunning && StartTime.HasValue)
                {
                    return TotalElapsedTime + (DateTime.Now - StartTime.Value);
                }
                else
                {
                    return TotalElapsedTime;
                }
            }
        }
        public string Category { get; set; } = "Genel";
        public string FormattedTime
        {
            get
            {
                return $"{ElapsedTime.Hours:D2}s : {ElapsedTime.Minutes:D2}dk : {ElapsedTime.Seconds:D2}sn";
            }
        }
    }
}
