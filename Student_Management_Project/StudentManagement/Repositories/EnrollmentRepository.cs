using System.Collections.Generic;
using System.IO;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class EnrollmentRepository
    {
        private List<Enrollment> enrollments = new List<Enrollment>();
        private string filePath;

        public EnrollmentRepository(string filePath)
        {
            this.filePath = filePath;
            LoadFromFile();
        }

        public void Add(Enrollment enrollment)
        {
            enrollments.Add(enrollment);
            SaveToFile();
        }

        public List<Enrollment> GetAll()
        {
            return enrollments;
        }

        public Enrollment GetById(int enrollmentId)
        {
            foreach (Enrollment enrollment in enrollments)
            {
                if (enrollment.EnrollmentID == enrollmentId)
                {
                    return enrollment;
                }
            }
            return null;
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line.Trim() == "")
                {
                    continue;
                }

                string[] parts = line.Split('|');
                int enrollmentId = int.Parse(parts[0]);
                int studentId = int.Parse(parts[1]);
                int courseId = int.Parse(parts[2]);
                enrollments.Add(new Enrollment(enrollmentId, studentId, courseId));
            }
        }

        private void SaveToFile()
        {
            List<string> lines = new List<string>();
            foreach (Enrollment enrollment in enrollments)
            {
                lines.Add(enrollment.EnrollmentID + "|" + enrollment.StudentID + "|" + enrollment.CourseID);
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
