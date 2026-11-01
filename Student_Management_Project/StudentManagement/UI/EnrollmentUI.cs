using StudentManagement.Services;

namespace StudentManagement.UI;

public class EnrollmentUI(EnrollmentService enrollmentService)
{
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("""
                --- Enrollment Menu ---
                1. Enroll a student in a course
                2. Show all enrollments
                3. Change the course of an enrollment
                4. Cancel an enrollment
                0. Back to main menu
                """);
            var choice = Input.ReadText("Choose: ");
            Console.Clear();

            switch (choice)
            {
                case "1": EnrollStudent(); break;
                case "2": ShowAllEnrollments(); break;
                case "3": UpdateEnrollment(); break;
                case "4": CancelEnrollment(); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
            Input.Pause();
        }
    }

    private void EnrollStudent()
    {
        var studentId = Input.ReadInt("Enter student ID: ");
        var courseId = Input.ReadInt("Enter course ID: ");

        Console.WriteLine(enrollmentService.Enroll(studentId, courseId));
    }

    private void ShowAllEnrollments()
    {
        var enrollments = enrollmentService.GetAllEnrollments();
        if (enrollments.Count == 0)
            Console.WriteLine("No enrollments yet.");

        foreach (var enrollment in enrollments)
            Console.WriteLine($"Enrollment {enrollment.EnrollmentID} | Student {enrollment.StudentID} | Course {enrollment.CourseID}");
    }

    private void UpdateEnrollment()
    {
        ShowAllEnrollments();
        var enrollmentId = Input.ReadInt("\nEnter ID of the enrollment to change: ");
        var newCourseId = Input.ReadInt("Enter the new course ID: ");

        Console.WriteLine(enrollmentService.UpdateEnrollment(enrollmentId, newCourseId));
    }

    private void CancelEnrollment()
    {
        ShowAllEnrollments();
        var enrollmentId = Input.ReadInt("\nEnter ID of the enrollment to cancel: ");

        Console.WriteLine(Input.Confirm("Are you sure?") ? enrollmentService.CancelEnrollment(enrollmentId) : "Cancel aborted.");
    }
}
