namespace lab3.Models
{
    public class course
    {
        //to set coureseid as PK wz data flunt in context file
        public int courseId { get; set; }
        public string courseName { get; set; }
        //many to many relation course and department
        public virtual List<Department> departments { get; set; }
        public virtual List<studentCourse> studentCrs { get; set; }
    }
}
