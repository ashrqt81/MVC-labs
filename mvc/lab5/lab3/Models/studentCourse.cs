using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Models
    //each row has one student and one course and its degree
    //student may dublicate
{
    public class studentCourse
    {
        [ForeignKey("Student")]
        public int stdId { get; set; }
        [ForeignKey("Course")] 
        public int crsId { get; set; }
        public int degree { get; set; }

        //nav properties
        public virtual Student Student { get; set; }
        public virtual course Course { get; set; }

        //many to many relation divide to one to many & one to many
    }
}
