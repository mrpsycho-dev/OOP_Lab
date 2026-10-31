using System.Collections.Generic;
using System.IO;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();
        private string filePath;

        public StudentRepository(string filePath)
        {
            this.filePath = filePath;
            LoadFromFile();
        }

        public void Add(Student student)
        {
            students.Add(student);
            SaveToFile();
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student GetById(int studentId)
        {
            foreach (Student student in students)
            {
                if (student.StudentID == studentId)
                {
                    return student;
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
                int id = int.Parse(parts[0]);
                students.Add(new Student(id, parts[1], parts[2]));
            }
        }

        private void SaveToFile()
        {
            List<string> lines = new List<string>();
            foreach (Student student in students)
            {
                lines.Add(student.StudentID + "|" + student.Name + "|" + student.Email);
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
