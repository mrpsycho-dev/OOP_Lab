// ============================================================
// LAYER   : Service
// PURPOSE : Holds the BUSINESS RULES for courses.
//           Rule here: two courses cannot have the same ID.
// USED BY : CourseUI
// TALKS TO: CourseRepository (to store/fetch), Course (Model)
// ============================================================

using System.Collections.Generic;
using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services
{
    public class CourseService
    {
        private CourseRepository courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public string AddCourse(Course course)
        {
            // Business rule: the ID must be unique.
            if (courseRepository.GetById(course.CourseID) != null)
            {
                return "Error: A course with this ID already exists.";
            }

            courseRepository.Add(course);
            return "Success: Course added.";
        }

        public List<Course> GetAllCourses()
        {
            return courseRepository.GetAll();
        }

        public Course FindCourseById(int courseId)
        {
            return courseRepository.GetById(courseId);
        }
    }
}
