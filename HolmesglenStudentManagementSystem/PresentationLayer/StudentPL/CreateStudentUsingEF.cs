using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class CreateStudentUsingEF : PLBase
    {
        public override void Run()
        {
            var student = new Student();
            Console.WriteLine("Creating a new student");
            Console.Write("Enter ID: ");
            student.Id = Console.ReadLine();
            Console.Write("Enter First Name: ");
            student.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            student.LastName = Console.ReadLine();
            Console.Write("Enter Email: ");
            student.Email = Console.ReadLine();

            var studentBLLEF = new StudentBLLEF();
            var result = studentBLLEF.CreateStudent(student);

            if (result == false)
            {
                Console.WriteLine($"Create new student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Create new student successful");
            }
        }
    }
}
