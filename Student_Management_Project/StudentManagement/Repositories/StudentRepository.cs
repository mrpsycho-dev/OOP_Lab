// ============================================================
// LAYER   : Repository
// PURPOSE : The ONLY place where Student objects are stored and fetched.
//           It knows HOW data is stored (a List), but knows NO rules.
// USED BY : StudentService, and EnrollmentService (to check a student exists).
// TALKS TO: Student (Model)
// ============================================================

using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class StudentRepository
    {
        // Temporary in-memory storage. The data disappears when the program closes.
        private List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetAll()
        {
            return students;
        }

        // Returns the student with this ID, or null if there is none.
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
