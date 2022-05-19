using lab6.Models;

namespace lab6.service
{
    public interface Istudent
    {
        public List<Student> GetStudents();
        public void addStudent(Student std);
    }
}
