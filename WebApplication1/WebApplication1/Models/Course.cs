namespace WebApplication1.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string category { get; set; } = string.Empty;
        public int durationHours { get; set; }
        public double price { get; set; }
        public string? ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CourseRound> courseRounds { get; set; }
        //public List<Enrollment> enrollments { get; set; }
    }
}
