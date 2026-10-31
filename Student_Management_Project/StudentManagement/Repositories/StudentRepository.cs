using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int studentId)
        {
            foreach (Student student in students)
            {
                if (student.StudentID == studentId)
                {
                    return student;
                }
            }
            return null;
        }
    }
}
