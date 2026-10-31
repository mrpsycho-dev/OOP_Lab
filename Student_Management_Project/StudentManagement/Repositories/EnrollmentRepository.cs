// ============================================================
// LAYER   : Repository
// PURPOSE : The ONLY place where Enrollment objects are stored and fetched.
// USED BY : EnrollmentService
// TALKS TO: Enrollment (Model)
// ============================================================

using System.Collections.Generic;
using StudentManagement.Models;

namespace StudentManagement.Repositories
{
    public class EnrollmentRepository
    {
        private List<Enrollment> enrollments = new List<Enrollment>();

        public void Add(Enrollment enrollment)
        {
            enrollments.Add(enrollment);
        }

        public List<Enrollment> GetAll()
        {
            return enrollments;
        }

        // Returns the enrollment with this ID, or null if there is none.
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
    }
}
