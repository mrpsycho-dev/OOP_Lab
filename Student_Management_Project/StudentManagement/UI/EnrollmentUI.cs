using System;
using System.Collections.Generic;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.UI
{
    public class EnrollmentUI
    {
        private EnrollmentService enrollmentService;

        public EnrollmentUI(EnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Enrollment Menu ---");
                Console.WriteLine("1. Enroll a student in a course");
                Console.WriteLine("2. Show all enrollments");
                Console.WriteLine("0. Back to main menu");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                {
                    EnrollStudent();
                }
                else if (choice == "2")
                {
                    ShowAllEnrollments();
                }
                else if (choice == "0")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }

                if (running)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey(true);
                }
            }
        }

        private void EnrollStudent()
        {
            Console.Write("Enter student ID: ");
            int studentId;
            if (!int.TryParse(Console.ReadLine(), out studentId))
            {
                Console.WriteLine("Error: ID must be a number.");
                return;
            }

            Console.Write("Enter course ID: ");
            int courseId;
            if (!int.TryParse(Console.ReadLine(), out courseId))
            {
                Console.WriteLine("Error: ID must be a number.");
                return;
            }

            string message = enrollmentService.Enroll(studentId, courseId);
            Console.WriteLine(message);
        }

        private void ShowAllEnrollments()
        {
            List<Enrollment> enrollments = enrollmentService.GetAllEnrollments();

            if (enrollments.Count == 0)
            {
                Console.WriteLine("No enrollments yet.");
                return;
            }

            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine("Enrollment " + enrollment.EnrollmentID
                    + " | Student " + enrollment.StudentID
                    + " | Course " + enrollment.CourseID);
            }
        }
    }
}
