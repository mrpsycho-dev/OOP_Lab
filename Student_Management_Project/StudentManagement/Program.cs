using System;
using StudentManagement.Repositories;
using StudentManagement.Services;
using StudentManagement.UI;

namespace StudentManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentRepository studentRepository = new StudentRepository();
            CourseRepository courseRepository = new CourseRepository();
            EnrollmentRepository enrollmentRepository = new EnrollmentRepository();

            StudentService studentService = new StudentService(studentRepository);
            CourseService courseService = new CourseService(courseRepository);
            EnrollmentService enrollmentService = new EnrollmentService(
                enrollmentRepository, studentRepository, courseRepository);

            StudentUI studentUI = new StudentUI(studentService);
            CourseUI courseUI = new CourseUI(courseService);
            EnrollmentUI enrollmentUI = new EnrollmentUI(enrollmentService);

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Student Management System ===");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Courses");
                Console.WriteLine("3. Enrollments");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                {
                    studentUI.ShowMenu();
                }
                else if (choice == "2")
                {
                    courseUI.ShowMenu();
                }
                else if (choice == "3")
                {
                    enrollmentUI.ShowMenu();
                }
                else if (choice == "0")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
