using System.Collections.Generic;
using System.IO;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class CourseRepository
    {
        private List<Course> courses = new List<Course>();
        private string filePath;

        public CourseRepository(string filePath)
        {
            this.filePath = filePath;
            LoadFromFile();
        }

        public void Add(Course course)
        {
            courses.Add(course);
            SaveToFile();
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

        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line.Trim() == "")
                {
                    continue;
                }

                string[] parts = line.Split('|');
                int id = int.Parse(parts[0]);
                int creditHours = int.Parse(parts[2]);
                courses.Add(new Course(id, parts[1], creditHours));
            }
        }

        private void SaveToFile()
        {
            List<string> lines = new List<string>();
            foreach (Course course in courses)
            {
                lines.Add(course.CourseID + "|" + course.CourseName + "|" + course.CreditHours);
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
