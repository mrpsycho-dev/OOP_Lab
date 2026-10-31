using System.Collections.Generic;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services
{
    public class StudentService
    {
        private StudentRepository studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public string AddStudent(Student student)
        {
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
