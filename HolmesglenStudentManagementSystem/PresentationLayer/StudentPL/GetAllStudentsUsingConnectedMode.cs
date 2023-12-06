using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class GetAllStudentsUsingConnectedMode : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Reading all student using connected mode");
            var studentBLLConnected = new StudentBLLConnected();
            var students = studentBLLConnected.GetALl();
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
