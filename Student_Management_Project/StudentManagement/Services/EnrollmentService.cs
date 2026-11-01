using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services;

public class EnrollmentService(
    EnrollmentRepository enrollmentRepository,
    StudentRepository studentRepository,
    CourseRepository courseRepository)
{
    public string Enroll(int studentId, int courseId)
    {
        var student = studentRepository.GetById(studentId);
        if (student is null)
            return "Error: Student not found.";

        var course = courseRepository.GetById(courseId);
        if (course is null)
            return "Error: Course not found.";

        if (enrollmentRepository.GetAll().Any(e => e.StudentID == studentId && e.CourseID == courseId))
            return "Error: This student is already enrolled in this course.";

        var nextId = enrollmentRepository.GetAll().Select(e => e.EnrollmentID).DefaultIfEmpty(0).Max() + 1;
        enrollmentRepository.Add(new Enrollment(nextId, studentId, courseId));

        return $"Success: {student.Name} is now enrolled in {course.CourseName}.";
    }

    public string UpdateEnrollment(int enrollmentId, int newCourseId)
    {
        var enrollment = enrollmentRepository.GetById(enrollmentId);
        if (enrollment is null)
            return "Error: Enrollment not found.";

        var course = courseRepository.GetById(newCourseId);
        if (course is null)
            return "Error: Course not found.";

        if (enrollmentRepository.GetAll().Any(e => e.StudentID == enrollment.StudentID && e.CourseID == newCourseId))
            return "Error: This student is already enrolled in that course.";

        enrollmentRepository.Update(enrollment with { CourseID = newCourseId });
        return $"Success: Enrollment changed to {course.CourseName}.";
    }

    public string CancelEnrollment(int enrollmentId)
    {
        if (enrollmentRepository.GetById(enrollmentId) is null)
            return "Error: Enrollment not found.";

        enrollmentRepository.Delete(enrollmentId);
        return "Success: Enrollment cancelled.";
    }

    public List<Enrollment> GetAllEnrollments() => enrollmentRepository.GetAll();
}
