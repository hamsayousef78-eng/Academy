using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Student
    {
        public int id {  get; set; }
        public string name { get; set; }
        public int age { get; set; }
        [ForeignKey("Department")]
        public int departmentId { get; set; }
        //Navigation property
        public Department department { get; set; }

    }
}
