using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace lab3.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//will not be auto increment
        public int DeptId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public virtual List<course> deptCourse { get; set; }
        //public virtual  List<Student> students { get; set; }
        public virtual ICollection<Student> students { get; set; }//icollection so data cant duplicate

        public Department()
        {
            students= new List<Student>();//so  we can add student in department
        }
        
    }
    
    
    
}

