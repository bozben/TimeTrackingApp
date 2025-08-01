namespace TimeTracker.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string ColorCode { get; set; }
    }
}
