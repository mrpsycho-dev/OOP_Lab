// ============================================================
// LAYER   : UI
// PURPOSE : Talks to the person at the keyboard about courses.
//           It reads input and prints output. It makes NO decisions.
// USED BY : Program.cs (main menu calls ShowMenu)
// TALKS TO: CourseService, Course (Model)
// ============================================================

using System;
using System.Collections.Generic;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.UI
{
    public class CourseUI
    {
        private CourseService courseService;

        public CourseUI(CourseService courseService)
        {
            this.courseService = courseService;
        }

        public void ShowMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("--- Course Menu ---");
                Console.WriteLine("1. Add a course");
                Console.WriteLine("2. Show all courses");
                Console.WriteLine("0. Back to main menu");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddCourse();
                }
                else if (choice == "2")
                {
                    ShowAllCourses();
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

        private void AddCourse()
        {
            Console.Write("Enter course ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Error: ID must be a number.");
                return;
            }

            Console.Write("Enter course name: ");
            string name = Console.ReadLine();

            Console.Write("Enter credit hours: ");
            int creditHours;
            if (!int.TryParse(Console.ReadLine(), out creditHours))
            {
                Console.WriteLine("Error: Credit hours must be a number.");
                return;
            }

            Course course = new Course(id, name, creditHours);

            string message = courseService.AddCourse(course);
            Console.WriteLine(message);
        }

        private void ShowAllCourses()
        {
            List<Course> courses = courseService.GetAllCourses();

            if (courses.Count == 0)
            {
                Console.WriteLine("No courses yet.");
                return;
            }

            foreach (Course course in courses)
            {
                Console.WriteLine(course.CourseID + " | " + course.CourseName + " | " + course.CreditHours + " credit hours");
            }
        }
    }
}
