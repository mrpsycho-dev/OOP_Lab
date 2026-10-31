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
