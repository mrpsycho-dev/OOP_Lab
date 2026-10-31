// ============================================================
// LAYER   : Service
// PURPOSE : Holds the BUSINESS RULES for enrolling a student in a course.
//           Rules: the student must exist, the course must exist,
//           and the same student cannot join the same course twice.
// USED BY : EnrollmentUI
// TALKS TO: EnrollmentRepository (store/fetch enrollments)
//           StudentRepository    (does this student exist?)
//           CourseRepository     (does this course exist?)
//           Enrollment, Student, Course (Models)
// ============================================================

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

        // This service needs THREE repositories, so it receives three objects.
        public EnrollmentService(
            EnrollmentRepository enrollmentRepository,
            StudentRepository studentRepository,
            CourseRepository courseRepository)
        {
            this.enrollmentRepository = enrollmentRepository;
            this.studentRepository = studentRepository;
            this.courseRepository = courseRepository;
        }

        // Returns a message the UI can show to the user.
        public string Enroll(int studentId, int courseId)
        {
            // Rule 1: the student must exist.
            Student student = studentRepository.GetById(studentId);
            if (student == null)
            {
                return "Error: Student not found.";
            }

            // Rule 2: the course must exist.
            Course course = courseRepository.GetById(courseId);
            if (course == null)
            {
                return "Error: Course not found.";
            }

            // Rule 3: no duplicate enrollment.
            foreach (Enrollment existing in enrollmentRepository.GetAll())
            {
                if (existing.StudentID == studentId && existing.CourseID == courseId)
                {
                    return "Error: This student is already enrolled in this course.";
                }
            }

            // All rules passed, so create the Enrollment and store it.
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
