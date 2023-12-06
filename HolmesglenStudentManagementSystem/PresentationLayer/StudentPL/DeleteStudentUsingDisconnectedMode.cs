using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.StudentPL
{
    public class DeleteStudentUsingDisconnectedMode : PLBase
    {
        public override void Run()
        {
            Console.WriteLine("Deleting a student using disconnected mode");
            Console.Write("Student ID: ");
            var id = Console.ReadLine();

            var studentBLLDisconnected = new StudentBLLDisconnected();
            var result = studentBLLDisconnected.Delete(id);
            if (result == false)
            {
                Console.WriteLine($"Delete student unsuccessful");
            }
            else
            {
                Console.WriteLine($"Delete student successful");
            }
        }
    }
}
