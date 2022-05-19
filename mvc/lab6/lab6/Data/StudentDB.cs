using lab6.Models;
using lab6.service;

namespace lab6.Data
{
    public class StudentDB : Istudent
    {    //class represent database
        private ITIDBContext _db;

        //deals wz  BDcontext

        public StudentDB(ITIDBContext db)
        {
            _db = db;
        }
        public void addStudent(Student std)
        {
            _db.Students.Add(std);
            _db.SaveChanges();
        }

        public List<Student> GetStudents()
        {
            return _db.Students.ToList();
        }
    }

    public class stdMONGO
    {
        //deals wz mongo BD
    }
    //wz each class we have to create different object in controller
}
