namespace WebApplication1.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        //Navigation property
        public List<Student> students { get; set; } = new List<Student>();
    }
}
