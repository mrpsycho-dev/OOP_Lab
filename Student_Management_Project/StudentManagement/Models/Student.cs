namespace StudentManagement.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Student(int studentId, string name, string email)
        {
            StudentID = studentId;
            Name = name;
            Email = email;
        }
    }
}
