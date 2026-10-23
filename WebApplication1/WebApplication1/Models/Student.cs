using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Student
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string? phone { get; set; }
        public string? ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        //public List<Enrollment> enrollments { get; set; }

    }
}           
