using StudentManagement.Models;

namespace StudentManagement.Repositories;

public class StudentRepository(string filePath)
{
    private readonly List<Student> students = File.ReadAllLines(filePath)
        .Where(line => line != "")
        .Select(line => line.Split('|'))
        .Select(parts => new Student(int.Parse(parts[0]), parts[1], parts[2]))
        .ToList();

    public void Add(Student student)
    {
        students.Add(student);
        Save();
    }

    public List<Student> GetAll() => students;

    public Student GetById(int id) => students.FirstOrDefault(s => s.StudentID == id);

    public void Update(Student student)
    {
        students[students.FindIndex(s => s.StudentID == student.StudentID)] = student;
        Save();
    }

    public void Delete(int id)
    {
        students.RemoveAll(s => s.StudentID == id);
        Save();
    }

    private void Save() =>
        File.WriteAllLines(filePath, students.Select(s => $"{s.StudentID}|{s.Name}|{s.Email}"));
}
