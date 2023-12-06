using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.ReportPL
{
    public class GenerateReport : PLBase
    {
        public override void Run()
        {
            var reportBLL = new ReportBLL();
            Console.Write("Enter a student ID: ");
            var id = Console.ReadLine();
            var report = reportBLL.Create(id);
            if(report == null || report.Student == null || report.Enrollment == null)
            {
                Console.WriteLine("Error when generate report");
            }
            else
            {
                Console.WriteLine("Student ID | FirstName | LastName | Email | EnrollmentID | Subject ID");
                Console.WriteLine($"{report.Student.Id} | {report.Student.FirstName} | {report.Student.LastName} | {report.Student.Email} | {report.Enrollment.EnrollmentID} | {report.Enrollment.SubjectID_FK}");
            }
        }
    }
}
