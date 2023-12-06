using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class EmailBLL
    {
        private StudentBLL StudentBLL;
        private SubjectBLL SubjectBLL;
        private EnrollmentBLL EnrollmentBLL;

        public EmailBLL()
        {
            StudentBLL = new StudentBLL();
            SubjectBLL = new SubjectBLL();
            EnrollmentBLL = new EnrollmentBLL();
        }

        public EmailModel Create(string id)
        {
            var student = StudentBLL.GetOne(id);
            var enrollment = EnrollmentBLL.GetOneByStudentId(id);
            var subject = SubjectBLL.GetOne(enrollment.SubjectID_FK);

            return new EmailModel(student, subject);
        }
    }
}
