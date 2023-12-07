using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class EmailDAL
    {
        private SQLiteConnection Connection;
        public EmailDAL()
        {
            Connection = new SQLiteConnection(HolmesglenDB.ConnectionString);
        }

        public EmailModel GetEmail(string id)
        {
            var email = new EmailModel();
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email, SubjectID, Title
                FROM Student join Enrollment on Student.StudentID = Enrollment.StudentID_FK
                join Subject on Enrollment.SubjectID_FK = Subject.SubjectID
                WHERE StudentId = @studentId
            ";
            command.Parameters.AddWithValue("@studentId", id);

            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var student = new Student();
                var subject = new Subject();
                student.Id = reader.GetString(0);
                student.FirstName = reader.GetString(1);
                student.LastName = reader.GetString(2);
                student.Email = reader.GetString(3);

                subject.SubjectId = reader.GetString(4);
                subject.Title = reader.GetString(5);
                
                email.Student = student;
                email.Subject = subject;
            }

            Connection.Close();

            return email;
        }
    }
}
