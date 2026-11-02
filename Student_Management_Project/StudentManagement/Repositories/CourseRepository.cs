using StudentManagement.Models;

namespace StudentManagement.Repositories;

public class CourseRepository(string filePath)
{
    private readonly List<Course> courses = File.ReadAllLines(filePath)
        .Where(line => line != "")
        .Select(line => line.Split('|'))
        .Select(parts => new Course(int.Parse(parts[0]), parts[1], int.Parse(parts[2])))
        .ToList();
    
    public void Add(Course course)
    {
        courses.Add(course);
        Save();
    }

    public List<Course> GetAll() => courses;

    public Course GetById(int id) => courses.FirstOrDefault(c => c.CourseID == id);

    public void Update(Course course)
    {
        courses[courses.FindIndex(c => c.CourseID == course.CourseID)] = course;
        Save();
    }

    public void Delete(int id)
    {
        courses.RemoveAll(c => c.CourseID == id);
        Save();
    }


    // courses.select means the List is converted to string,
    // and the string is written to the file
    private void Save() =>
        File.WriteAllLines(filePath, courses.Select(c => $"{c.CourseID}|{c.CourseName}|{c.CreditHours}"));
}
