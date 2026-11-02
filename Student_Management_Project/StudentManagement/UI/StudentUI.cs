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
                5. Search student by 
                   Name (Partial), 
                   ID (Range), and 
                   Email (Exact Match)
                
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
                case "5": SearchStudent(); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
            Input.Pause();
        }
    }

    private void ShowAllStudents() => PrintStudents(studentService.GetAllStudents());


    private void PrintStudents(List<Student> students)
    {
        if (students.Count == 0)
            Console.WriteLine("No students found.");

        foreach (var student in students)
            Console.WriteLine($"{student.StudentID} | {student.Name} | {student.Email}");
    }

    private void AddStudent()
    {
        var student = new Student(
            Input.ReadInt("Enter student ID: "),
            Input.ReadText("Enter name: "),
            Input.ReadText("Enter email: "));

        Console.WriteLine(studentService.AddStudent(student));
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

    private void SearchStudent() 
    {
        ShowAllStudents();

        var name = Input.ReadText("\nEnter name of Student (Partial search): ");
        var idLow = Input.ReadInt("Enter lower Range of Student ID: ");
        var idHigh = Input.ReadInt("Enter higher Range of Student ID: ");
        var email  = Input.ReadText("Enter name of Student (Exact match): ");


        Console.WriteLine("\n--- Search results ---");
        PrintStudents(studentService.SearchStudents(name, idLow, idHigh, email));
    }
}
