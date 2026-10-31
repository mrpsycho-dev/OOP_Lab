namespace StudentManagement.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CreditHours { get; set; }

        public Course(int courseId, string courseName, int creditHours)
        {
            CourseID = courseId;
            CourseName = courseName;
            CreditHours = creditHours;
        }
    }
}
