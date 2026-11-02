using StudentManagement.Models;
using StudentManagement.Repositories;

namespace StudentManagement.Services;

public class StudentService(StudentRepository studentRepository, EnrollmentRepository enrollmentRepository)
{
    public string AddStudent(Student student)
    {
        if (studentRepository.GetById(student.StudentID) is not null)
            return "Error: A student with this ID already exists.";

        studentRepository.Add(student);
        return "Success: Student added.";
    }

    public string UpdateStudent(Student student)
    {
        if (studentRepository.GetById(student.StudentID) is null)
            return "Error: Student not found.";

        studentRepository.Update(student);
        return "Success: Student updated.";
    }

    public string DeleteStudent(int studentId)
    {
        if (studentRepository.GetById(studentId) is null)
            return "Error: Student not found.";

        // enrollment repo used here.
        // to check if student is enrolled in any course before deleting
        if (enrollmentRepository.GetAll().Any(e => e.StudentID == studentId))
            return "Error: Cannot delete. This student is enrolled in a course. Cancel the enrollment first.";

        studentRepository.Delete(studentId);
        return "Success: Student deleted.";
    }

    public List<Student> GetAllStudents() => studentRepository.GetAll();

    public Student FindStudentById(int studentId) => studentRepository.GetById(studentId);


    // search filter
    public List<Student> SearchStudents(string name, int? idLow, int? idHigh, string email)
    {
        List<Student> allStudents = studentRepository.GetAll();

        List<Student> results = new List<Student>();

        foreach (Student student in allStudents)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (!student.Name.Contains(name.Trim(), StringComparison.OrdinalIgnoreCase))
                    continue;
            }

            if (idLow != null)
            {
                if (student.StudentID < idLow.Value)
                    continue;
            }

            if (idHigh != null)
            {
                if (student.StudentID > idHigh.Value)
                    continue;
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (!student.Email.Equals(email.Trim(), StringComparison.OrdinalIgnoreCase))
                    continue;
            }

            results.Add(student);
        }

        return results;
    }

}
