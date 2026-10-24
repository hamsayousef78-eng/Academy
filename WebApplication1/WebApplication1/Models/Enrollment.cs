namespace WebApplication1.Models
{
    public class Enrollment
    {
       public int id { get; set; }

        public int studentId { get; set; }

        //Navigation
        public Student? student { get; set; } = null!;
        public int courseRoundId { get; set; }
        //Navigation
        public CourseRound? courseRound { get; set; } = null!;
        public DateTime enrollmentDate { get; set; }
        //public bool? status { get; set; }
    }
}
