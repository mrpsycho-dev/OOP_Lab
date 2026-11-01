using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services;

public class CourseService(CourseRepository courseRepository, EnrollmentRepository enrollmentRepository)
{
    public string AddCourse(Course course)
    {
        if (courseRepository.GetById(course.CourseID) is not null)
            return "Error: A course with this ID already exists.";

        courseRepository.Add(course);
        return "Success: Course added.";
    }

    public string UpdateCourse(Course course)
    {
        if (courseRepository.GetById(course.CourseID) is null)
            return "Error: Course not found.";

        courseRepository.Update(course);
        return "Success: Course updated.";
    }

    public string DeleteCourse(int courseId)
    {
        if (courseRepository.GetById(courseId) is null)
            return "Error: Course not found.";

        if (enrollmentRepository.GetAll().Any(e => e.CourseID == courseId))
            return "Error: Cannot delete. Students are enrolled in this course. Cancel those enrollments first.";

        courseRepository.Delete(courseId);
        return "Success: Course deleted.";
    }

    public List<Course> GetAllCourses() => courseRepository.GetAll();

    public Course FindCourseById(int courseId) => courseRepository.GetById(courseId);
}
