using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="name is required"), StringLength(10, MinimumLength = 3)]
        
        public string Name { get; set; }
        [Range(20,30)]
        public string? age { get; set; }
      //  [NotMapped]//not a column
        public string? StdImg { get; set; }
        public virtual Department? department { get; set; }
       
        [ForeignKey("department")]//put befor foreignkey property and take navigation property name
        public int deptno { get; set; }

       // public virtual List<studentCourse> mycourse { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[A-Za-z0-9]+.[A-Za-z]{2,4}")]
        public string? Email { get; set; }

       // [Remote("checkUsername","Student")]
        public string? Username { get; set; }


        [Required]
        public string? Password { get; set; }
        [NotMapped]
        [Compare ("Password")]
        public string Cpassword { get; set; }
    }
}
