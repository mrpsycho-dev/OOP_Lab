// ============================================================
// Program.cs : the "wiring" file.
// It CREATES every object once and CONNECTS them together.
// It contains no business logic and no student/course screens.
// ============================================================

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
            // STEP 1: Create the repositories (they hold the data).
            // Each one is created ONLY ONCE, so everyone shares the same lists.
            StudentRepository studentRepository = new StudentRepository();
            CourseRepository courseRepository = new CourseRepository();
            EnrollmentRepository enrollmentRepository = new EnrollmentRepository();

            // STEP 2: Create the services and give each one the repositories it needs.
            // Notice that studentRepository is given to TWO services, so both see the same students.
            StudentService studentService = new StudentService(studentRepository);
            CourseService courseService = new CourseService(courseRepository);
            EnrollmentService enrollmentService = new EnrollmentService(
                enrollmentRepository, studentRepository, courseRepository);

            // STEP 3: Create the UI classes and give each one its service.
            StudentUI studentUI = new StudentUI(studentService);
            CourseUI courseUI = new CourseUI(courseService);
            EnrollmentUI enrollmentUI = new EnrollmentUI(enrollmentService);

            // STEP 4: Show the main menu.
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("=== Student Management System ===");
                Console.WriteLine("1. Students");
                Console.WriteLine("2. Courses");
                Console.WriteLine("3. Enrollments");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

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
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
