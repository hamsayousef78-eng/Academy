using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Student
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int age { get; set; }
        [ForeignKey("department")]
        public int departmentId { get; set; }
        //Navigation property
        public Department department { get; set; }

        public List<Enrollment> enrollments { get; set; }

    }
}
