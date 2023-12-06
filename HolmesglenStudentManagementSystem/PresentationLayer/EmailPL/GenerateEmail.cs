using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.EmailPL
{
    public class GenerateEmail : PLBase
    {
        public override void Run()
        {
            var emailBLL = new EmailBLL();
            Console.Write("Enter student ID: ");
            var id = Console.ReadLine();
            var email = emailBLL.Create(id);

            if (email == null || email.Student == null || email.Subject == null)
            {
                Console.WriteLine("Error when generate email");
            }
            else
            {
                var emailContent = $@"
                                    Dear {email.Student.FirstName},

                                    You have been enrollment in the following subject
                                    {email.Subject.Title}
                                    {email.Subject.SubjectId}

                                    Please login to your account and confirm the above enrolments.

                                    Regards,
                                    CAIT Department";

                Console.WriteLine(emailContent);
            }
        }
    }
}
