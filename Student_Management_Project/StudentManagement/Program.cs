using System;
using StudentManagement.Models;
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

            AddDummyData(studentService, courseService, enrollmentService);

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

        private static void AddDummyData(
            StudentService studentService,
            CourseService courseService,
            EnrollmentService enrollmentService)
        {
            studentService.AddStudent(new Student(1, "Ahmed Khan", "ahmed.khan@example.com"));
            studentService.AddStudent(new Student(2, "Fatima Zahra", "fatima.zahra@example.com"));
            studentService.AddStudent(new Student(3, "Ali Raza", "ali.raza@example.com"));
            studentService.AddStudent(new Student(4, "Ayesha Siddiqui", "ayesha.siddiqui@example.com"));
            studentService.AddStudent(new Student(5, "Hassan Mahmood", "hassan.mahmood@example.com"));
            studentService.AddStudent(new Student(6, "Zainab Malik", "zainab.malik@example.com"));
            studentService.AddStudent(new Student(7, "Usman Tariq", "usman.tariq@example.com"));
            studentService.AddStudent(new Student(8, "Hira Baig", "hira.baig@example.com"));
            studentService.AddStudent(new Student(9, "Bilal Ahmed", "bilal.ahmed@example.com"));
            studentService.AddStudent(new Student(10, "Sana Iqbal", "sana.iqbal@example.com"));

            courseService.AddCourse(new Course(101, "Programming Fundamentals", 3));
            courseService.AddCourse(new Course(102, "Object Oriented Programming", 3));
            courseService.AddCourse(new Course(103, "Data Structures", 4));
            courseService.AddCourse(new Course(104, "Database Systems", 3));
            courseService.AddCourse(new Course(105, "Pakistan Studies", 2));
            courseService.AddCourse(new Course(106, "Calculus", 3));
            courseService.AddCourse(new Course(107, "Islamiat", 2));

            enrollmentService.Enroll(1, 101);
            enrollmentService.Enroll(1, 102);
            enrollmentService.Enroll(1, 105);
            enrollmentService.Enroll(2, 101);
            enrollmentService.Enroll(2, 103);
            enrollmentService.Enroll(3, 102);
            enrollmentService.Enroll(3, 104);
            enrollmentService.Enroll(3, 106);
            enrollmentService.Enroll(4, 101);
            enrollmentService.Enroll(4, 104);
            enrollmentService.Enroll(4, 107);
            enrollmentService.Enroll(5, 103);
            enrollmentService.Enroll(5, 105);
            enrollmentService.Enroll(6, 102);
            enrollmentService.Enroll(6, 106);
            enrollmentService.Enroll(7, 101);
            enrollmentService.Enroll(7, 103);
            enrollmentService.Enroll(7, 104);
            enrollmentService.Enroll(8, 105);
            enrollmentService.Enroll(8, 107);
            enrollmentService.Enroll(9, 106);
            enrollmentService.Enroll(10, 102);
            enrollmentService.Enroll(10, 103);
        }
    }
}
