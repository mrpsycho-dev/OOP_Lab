using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.UI;

public class StudentUI(StudentService studentService)
{
    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("""
                --- Student Menu ---
                1. Add a student
                2. Show all students
                3. Update a student
                4. Delete a student
                0. Back to main menu
                """);
            var choice = Input.ReadText("Choose: ");
            Console.Clear();

            switch (choice)
            {
                case "1": AddStudent(); break;
                case "2": ShowAllStudents(); break;
                case "3": UpdateStudent(); break;
                case "4": DeleteStudent(); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
            Input.Pause();
        }
    }

    private void AddStudent()
    {
        var student = new Student(
            Input.ReadInt("Enter student ID: "),
            Input.ReadText("Enter name: "),
            Input.ReadText("Enter email: "));

        Console.WriteLine(studentService.AddStudent(student));
    }

    private void ShowAllStudents()
    {
        var students = studentService.GetAllStudents();
        if (students.Count == 0)
            Console.WriteLine("No students yet.");

        foreach (var student in students)
            Console.WriteLine($"{student.StudentID} | {student.Name} | {student.Email}");
    }

    private void UpdateStudent()
    {
        ShowAllStudents();
        var student = new Student(
            Input.ReadInt("\nEnter ID of the student to update: "),
            Input.ReadText("Enter new name: "),
            Input.ReadText("Enter new email: "));

        Console.WriteLine(studentService.UpdateStudent(student));
    }

    private void DeleteStudent()
    {
        ShowAllStudents();
        var id = Input.ReadInt("\nEnter ID of the student to delete: ");

        Console.WriteLine(Input.Confirm("Are you sure?") ? studentService.DeleteStudent(id) : "Delete cancelled.");
    }
}
