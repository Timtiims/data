using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    public class EmailModel
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; }

        public EmailModel()
        {
            
        }

        public EmailModel(Student student, Subject subject)
        {
            Student = student;
            Subject = subject;
        }
    }
}
