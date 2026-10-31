// ============================================================
// LAYER   : Service
// PURPOSE : Holds the BUSINESS RULES for students.
//           Rule here: two students cannot have the same ID.
// USED BY : StudentUI
// TALKS TO: StudentRepository (to store/fetch), Student (Model)
// ============================================================

using System.Collections.Generic;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services
{
    public class StudentService
    {
        // The service does not create its own repository.
        // Program.cs creates it and hands it in through the constructor.
        private StudentRepository studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        // Returns a message the UI can show to the user.
        public string AddStudent(Student student)
        {
            // Business rule: the ID must be unique.
            if (studentRepository.GetById(student.StudentID) != null)
            {
                return "Error: A student with this ID already exists.";
            }

            studentRepository.Add(student);
            return "Success: Student added.";
        }

        public List<Student> GetAllStudents()
        {
            return studentRepository.GetAll();
        }

        public Student FindStudentById(int studentId)
        {
            return studentRepository.GetById(studentId);
        }
    }
}
