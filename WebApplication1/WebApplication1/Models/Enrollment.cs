namespace WebApplication1.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        public int studentId { get; set; }

        //Navigation
        public Student student { get; set; }
        public int courseId { get; set; }
        //Navigation
        public Course course { get; set; }
    }
}
