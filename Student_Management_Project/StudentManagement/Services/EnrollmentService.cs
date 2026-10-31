using System.Collections.Generic;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services
{
    public class EnrollmentService
    {
        private EnrollmentRepository enrollmentRepository;
        private StudentRepository studentRepository;
        private CourseRepository courseRepository;

        public EnrollmentService(
            EnrollmentRepository enrollmentRepository,
            StudentRepository studentRepository,
            CourseRepository courseRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        public string Enroll(int studentId, int courseId)
        {
            Student student = studentRepository.GetById(studentId);
            if (student == null)
            {
                return "Error: Student not found.";
            }

            Course course = courseRepository.GetById(courseId);
            if (course == null)
            {
                return "Error: Course not found.";
            }

            foreach (Enrollment existing in enrollmentRepository.GetAll())
            {
                if (existing.StudentID == studentId && existing.CourseID == courseId)
                {
                    return "Error: This student is already enrolled in this course.";
                }
            }

            int newId = enrollmentRepository.GetAll().Count + 1;
            Enrollment enrollment = new Enrollment(newId, studentId, courseId);
            enrollmentRepository.Add(enrollment);

            return "Success: " + student.Name + " is now enrolled in " + course.CourseName + ".";
        }

        public List<Enrollment> GetAllEnrollments()
        {
            return enrollmentRepository.GetAll();
        }
    }
}
