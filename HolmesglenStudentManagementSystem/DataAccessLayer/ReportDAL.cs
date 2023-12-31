﻿using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class ReportDAL
    {
        private SQLiteConnection Connection;
        public ReportDAL()
        {
            Connection = new SQLiteConnection(HolmesglenDB.ConnectionString);
        }

        public Report GetReport(string id)
        {
            Report report = new Report();
            Connection.Open();
            // build the query command
            var command = Connection.CreateCommand();
            command.CommandText = @"
                SELECT StudentID, FirstName, LastName, Email, cast(EnrollmentID as text), StudentID_FK, SubjectID_FK
                FROM Student join Enrollment on Student.StudentID = Enrollment.StudentID_FK
                WHERE StudentId = @studentId
            ";
            command.Parameters.AddWithValue("@studentId", id);

            var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var student = new Student();
                var enrollment = new Enrollment();
                student.Id = reader.GetString(0);
                student.FirstName = reader.GetString(1);
                student.LastName = reader.GetString(2);
                student.Email = reader.GetString(3);

                enrollment.EnrollmentID = reader.GetString(4);
                enrollment.SubjectID_FK = reader.GetString(5);
                enrollment.SubjectID_FK = reader.GetString(6);
                
                report.Student = student;
                report.Enrollment = enrollment;
            }

            Connection.Close();

            return report;
        }
    }
}
