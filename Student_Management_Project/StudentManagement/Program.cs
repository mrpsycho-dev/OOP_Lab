using StudentManagement.Repositories;
using StudentManagement.Services;
using StudentManagement.UI;

var studentRepository = new StudentRepository("Data/students.txt");
var courseRepository = new CourseRepository("Data/courses.txt");
var enrollmentRepository = new EnrollmentRepository("Data/enrollments.txt");

var studentService = new StudentService(studentRepository, enrollmentRepository);
var courseService = new CourseService(courseRepository, enrollmentRepository);
var enrollmentService = new EnrollmentService(enrollmentRepository, studentRepository, courseRepository);

var studentUI = new StudentUI(studentService);
var courseUI = new CourseUI(courseService);
var enrollmentUI = new EnrollmentUI(enrollmentService);

while (true)
{
    Console.Clear();
    Console.WriteLine("""
        === Student Management System ===
        1. Students
        2. Courses
        3. Enrollments
        0. Exit
        """);
    var choice = Input.ReadText("Choose: ");
    Console.Clear();

    switch (choice)
    {
        case "1": studentUI.ShowMenu(); break;
        case "2": courseUI.ShowMenu(); break;
        case "3": enrollmentUI.ShowMenu(); break;
        case "0": Console.WriteLine("Goodbye!"); return;
        default: Console.WriteLine("Invalid choice."); Input.Pause(); break;
    }
}
