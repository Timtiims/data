using HolmesglenStudentManagementSystem.PresentationLayer;
using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using HolmesglenStudentManagementSystem.PresentationLayer.StudentPL;
using HolmesglenStudentManagementSystem.PresentationLayer.SubjectPL;
using HolmesglenStudentManagementSystem.PresentationLayer.EnrollmentPL;
using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using HolmesglenStudentManagementSystem.Models;
using System.Runtime.Intrinsics.X86;
using HolmesglenStudentManagementSystem.PresentationLayer.ReportPL;
using HolmesglenStudentManagementSystem.PresentationLayer.EmailPL;
using HolmesglenStudentManagementSystem.PresentationLayer.Import;
using HolmesglenStudentManagementSystem.PresentationLayer.Export;

namespace HolmesglenStudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //(new ImportData().Run());
            bool continueRunning = true;

            while (continueRunning)
            {
                DisplayMenu();

                // Get user input
                string userInput = Console.ReadLine();

                // Process user choice
                switch (userInput)
                {
                    case "1":
                        ManageStudents();
                        break;
                    case "2":
                        ManageSubjects();
                        break;
                    case "3":
                        ManageEnrollments();
                        break;
                    case "4":
                        UseConnectedMode();
                        break;
                    case "5":
                        UseDisconnectedMode();
                        break;
                    case "6":
                        GenerateReport();
                        break;
                    case "7":
                        GeneratEmail();
                        break;
                    case "8":
                        Import();
                        break;
                    case "9":
                        Export();
                        break;
                    case "0":
                        continueRunning = false;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Manage Students");
            Console.WriteLine("2. Manage Subjects");
            Console.WriteLine("3. Manage Enrollments");
            Console.WriteLine("4. Use Connected mode");
            Console.WriteLine("5. Use Disconnected mode");
            Console.WriteLine("6. Generate Report");
            Console.WriteLine("7. Generate Email");
            Console.WriteLine("8. Import");
            Console.WriteLine("9. Export");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
        }

        

        static void UseConnectedMode()
        {
            new GetAllStudentsUsingConnectedMode().Run();
        }

        static void UseDisconnectedMode()
        {
            new GetAllStudentsUsingDisconnectedMode().Run();
            new GetOneStudentUsingDisconnectedMode().Run();
            new CreateStudentUsingDisconnectedMode().Run();
            new UpdateStudentUsingDisconnectedMode().Run();
            new DeleteStudentUsingDisconnectedMode().Run();
        }

        static void GenerateReport()
        {
            new GenerateReport().Run();
        }

        static void GeneratEmail()
        {
            new GenerateEmail().Run();
        }

        static void Import()
        {
            new ImportPL().Run();
        }

        static void Export()
        {
            new ExportPL().Run();
        }

        static void ManageStudents()
        {
            Console.WriteLine("=== Student Management ===");
            new GetAllStudents().Run();
            new GetOneStudent().Run();
            new CreateStudent().Run();
            new UpdateStudent().Run();
            new DeleteStudent().Run();
        }

        static void ManageSubjects()
        {
            Console.WriteLine("=== Subject Management ===");
            (new GetAllSubject()).Run();
            (new GetOneSubject()).Run();
            (new CreateSubject()).Run();
            (new UpdateSubject()).Run();
            (new DeleteSubject()).Run();
            Console.WriteLine();
        }

        static void ManageEnrollments()
        {
            Console.WriteLine("=== Enrollment Management ===");
            (new GetAllEnrollment()).Run();
            (new CreateEnrollment()).Run();
            (new UpdateEnrollment()).Run();
            (new DeleteEnrollment()).Run();
            (new GetOneEnrollment()).Run();
        }
    }
}

