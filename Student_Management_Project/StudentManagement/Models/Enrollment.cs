namespace StudentManagement.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public Enrollment(int enrollmentId, int studentId, int courseId)
        {
            EnrollmentID = enrollmentId;
            StudentID = studentId;
            CourseID = courseId;
        }
    }
}
