// ============================================================
// LAYER   : Model
// PURPOSE : Holds the data of ONE student. Nothing else.
// USED BY : StudentUI creates it, StudentService passes it on,
//           StudentRepository stores it.
// ============================================================

namespace StudentManagement.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // The constructor lets us fill in all the data when we create the object.
        public Student(int studentId, string name, string email)
        {
            StudentID = studentId;
            Name = name;
            Email = email;
        }
    }
}
