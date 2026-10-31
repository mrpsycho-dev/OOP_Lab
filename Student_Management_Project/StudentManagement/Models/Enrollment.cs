// ============================================================
// LAYER   : Model
// PURPOSE : Holds ONE link between a student and a course.
//           It stores only the two IDs, not the whole objects.
// USED BY : EnrollmentService creates it,
//           EnrollmentRepository stores it,
//           EnrollmentUI displays it.
// ============================================================

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
