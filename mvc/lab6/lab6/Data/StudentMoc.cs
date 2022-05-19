using lab6.Models;
using lab6.service;

namespace lab6.Data
{
    public class StudentMoc:Istudent//represent database(dependancy)
    {
        
        //each object created from studentmoc class will have its own student list
          List<Student> students = new List<Student>()//make the list static
        {
         
            new Student(){Id = 1, Name ="malek",age=8},
            new Student(){Id=2, Name ="masa" ,age=98},
            new Student(){Id=2, Name ="yasser" ,age=33}


        };//list is private
        //set,get
        public List<Student> GetStudents() //instance member function but can deall wz static members(list)
        {
            return students;
        }
        public void addStudent(Student std)
        {
            students.Add(std);
        }

    }
    
}
