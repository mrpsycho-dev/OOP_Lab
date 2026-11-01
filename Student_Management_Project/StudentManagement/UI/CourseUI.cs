using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.UI;

public class CourseUI(CourseService courseService)
{
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("""
                --- Course Menu ---
                1. Add a course
                2. Show all courses
                3. Update a course
                4. Delete a course
                0. Back to main menu
                """);
            var choice = Input.ReadText("Choose: ");
            Console.Clear();

            switch (choice)
            {
                case "1": AddCourse(); break;
                case "2": ShowAllCourses(); break;
                case "3": UpdateCourse(); break;
                case "4": DeleteCourse(); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
            Input.Pause();
        }
    }

    private void AddCourse()
    {
        var course = new Course(
            Input.ReadInt("Enter course ID: "),
            Input.ReadText("Enter course name: "),
            Input.ReadInt("Enter credit hours: "));

        Console.WriteLine(courseService.AddCourse(course));
    }

    private void ShowAllCourses()
    {
        var courses = courseService.GetAllCourses();
        if (courses.Count == 0)
            Console.WriteLine("No courses yet.");

        foreach (var course in courses)
            Console.WriteLine($"{course.CourseID} | {course.CourseName} | {course.CreditHours} credit hours");
    }

    private void UpdateCourse()
    {
        ShowAllCourses();
        var course = new Course(
            Input.ReadInt("\nEnter ID of the course to update: "),
            Input.ReadText("Enter new course name: "),
            Input.ReadInt("Enter new credit hours: "));

        Console.WriteLine(courseService.UpdateCourse(course));
    }

    private void DeleteCourse()
    {
        ShowAllCourses();
        var id = Input.ReadInt("\nEnter ID of the course to delete: ");

        Console.WriteLine(Input.Confirm("Are you sure?") ? courseService.DeleteCourse(id) : "Delete cancelled.");
    }
}
