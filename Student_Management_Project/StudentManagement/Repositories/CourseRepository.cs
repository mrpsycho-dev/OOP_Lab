// ============================================================
// LAYER   : Repository
// PURPOSE : The ONLY place where Course objects are stored and fetched.
// USED BY : CourseService, and EnrollmentService (to check a course exists).
// TALKS TO: Course (Model)
// ============================================================

using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class CourseRepository
    {
        private List<Course> courses = new List<Course>();

        public void Add(Course course)
        {
            courses.Add(course);
        }

        public List<Course> GetAll()
        {
            return courses;
        }

        // Returns the course with this ID, or null if there is none.
        public Course GetById(int courseId)
        {
            foreach (Course course in courses)
            {
                if (course.CourseID == courseId)
                {
                    return course;
                }
            }
            return null;
        }
    }
}
