namespace WebApplication1.Models
{
    public class CourseRound
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int instructorId { get; set; }
        //Navigation
        public Instructor ?instructor { get; set; } 
        public int courseId { get; set; }
        //Navigation
        public Course ?course { get; set; }
        public DateTime startDate {  get; set; }
        public DateTime?EndDate { get; set; }
        public int capacity { get; set; }
        public bool IsActive { get; set; } = true;
        //public List<Enrollment> enrollments { get; set; }
    }
}
