using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class GetAllStudentsUsingEF : PLBase
    {
        public override void Run()
        {
            StudentBLLEF studentBLLEF = new StudentBLLEF();
            Console.WriteLine("Reading all student using Entity Framework");
            
            var students = studentBLLEF.GetAllStudents();
            if (students.Count == 0)
            {
                Console.WriteLine("table is empty");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.Id}\t{student.FirstName}\t{student.LastName}\t{student.Email}");
                }
            }
        }
    }
}
