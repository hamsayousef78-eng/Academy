namespace WebApplication1.Models
{
    public class Instructor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string? phone { get; set; }
        public string specialization { get; set; }
        public string? bio { get; set; }
        public string? ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public List<CourseRound>? courseRounds { get; set; }
    }
}
