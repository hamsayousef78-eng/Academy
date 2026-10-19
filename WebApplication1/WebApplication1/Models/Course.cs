namespace WebApplication1.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Enrollment> enrollments { get; set; }
    }
}
