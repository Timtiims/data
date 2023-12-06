using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class Report
    {
        public Student Student { get; set; }
        public Enrollment Enrollment { get; set; }

        public Report()
        {
            
        }

        public Report(Student student, Enrollment enrollment)
        {
            Student = student;
            Enrollment = enrollment;
        }
    }
}
