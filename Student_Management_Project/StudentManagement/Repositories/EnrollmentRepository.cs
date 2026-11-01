using StudentManagement.Models;

namespace StudentManagement.Repositories;

public class EnrollmentRepository(string filePath)
{
    private readonly List<Enrollment> enrollments = File.ReadAllLines(filePath)
        .Where(line => line != "")
        .Select(line => line.Split('|'))
        .Select(parts => new Enrollment(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])))
        .ToList();

    public void Add(Enrollment enrollment)
    {
        enrollments.Add(enrollment);
        Save();
    }

    public List<Enrollment> GetAll() => enrollments;

    public Enrollment GetById(int id) => enrollments.FirstOrDefault(e => e.EnrollmentID == id);

    public void Update(Enrollment enrollment)
    {
        enrollments[enrollments.FindIndex(e => e.EnrollmentID == enrollment.EnrollmentID)] = enrollment;
        Save();
    }

    public void Delete(int id)
    {
        enrollments.RemoveAll(e => e.EnrollmentID == id);
        Save();
    }

    private void Save() =>
        File.WriteAllLines(filePath, enrollments.Select(e => $"{e.EnrollmentID}|{e.StudentID}|{e.CourseID}"));
}
