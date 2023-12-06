using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class ReportBLL
    {
        private StudentBLL studentBLL;
        private EnrollmentBLL enrollmentBLL;

        public ReportBLL()
        {
            studentBLL = new StudentBLL();
            enrollmentBLL = new EnrollmentBLL();
        }

        public Report Create(string id)
        {
            var student = studentBLL.GetOne(id);
            var enrollment = enrollmentBLL.GetOneByStudentId(id);

            return new Report(student, enrollment);
        }
    }
}
