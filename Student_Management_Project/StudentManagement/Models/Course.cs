namespace StudentManagement.Models;

public record Course(int CourseID, string CourseName, int CreditHours);

//public class Course
//{
//    public int CourseID { get; set; }
//    public string CourseName { get; set; }
//    public int CreditHours { get; set; }

//    public Course(int courseID, string courseName, int creditHours)
//    {
//        CourseID = courseID;
//        CourseName = courseName;
//        CreditHours = creditHours;
//    }
//}