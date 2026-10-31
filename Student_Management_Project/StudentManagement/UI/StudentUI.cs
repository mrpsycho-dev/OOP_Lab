// ============================================================
// LAYER   : UI
// PURPOSE : Talks to the person at the keyboard about students.
//           It reads input and prints output. It makes NO decisions.
// USED BY : Program.cs (main menu calls ShowMenu)
// TALKS TO: StudentService, Student (Model)
// ============================================================

using System;
using System.Collections.Generic;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.UI
{
    public class StudentUI
    {
        // Received from Program.cs through the constructor.
        private StudentService studentService;

        public StudentUI(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("--- Student Menu ---");
                Console.WriteLine("1. Add a student");
                Console.WriteLine("2. Show all students");
                Console.WriteLine("0. Back to main menu");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddStudent();
                }
                else if (choice == "2")
                {
                    ShowAllStudents();
                }
                else if (choice == "0")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }

        private void AddStudent()
        {
            Console.Write("Enter student ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error: ID must be a number.");
                return;
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            // Step 2 of the flow: the UI creates the Model object...
            Student student = new Student(id, name, email);

            // Step 3: ...and hands it to the Service.
            string message = studentService.AddStudent(student);
            Console.WriteLine(message);
        }

        private void ShowAllStudents()
        {
            List<Student> students = studentService.GetAllStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("No students yet.");
                return;
            }

            foreach (Student student in students)
            {
                Console.WriteLine(student.StudentID + " | " + student.Name + " | " + student.Email);
            }
        }
    }
}
