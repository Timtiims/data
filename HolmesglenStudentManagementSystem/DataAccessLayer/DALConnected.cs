using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class DALConnected
    {
        private SQLiteConnection Connection;
        public DALConnected(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);
        }

        public List<Student> StudentReadAll()
        {
            var students = new List<Student>();
            Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Student";

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var studentId = reader.GetString(0);
                var studentFirstName = reader.GetString(1);
                var studentLastName = reader.GetString(2);
                var studentEmail = reader.GetString(3);
                students.Add(new Student(studentId, studentFirstName, studentLastName, studentEmail));
            }
            Connection.Close();

            return students;
        }
        public void StudentCreate(Student student)
        {
            if(Connection.State != ConnectionState.Open)
                Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = "insert into Student values($studentId, $firstName, $lastName, $email)";
            command.Parameters.AddWithValue("$studentId", student.Id);
            command.Parameters.AddWithValue("$firstName", student.FirstName);
            command.Parameters.AddWithValue("$lastName", student.LastName);
            command.Parameters.AddWithValue("$email", student.Email);

            command.ExecuteNonQuery();
            Connection.Close();
        }

        public void StudentDelete(string id)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = "delete from Student where StudentId = $id";
            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();
            Connection.Close();
        }

        public void StudentUpdate(Student student)
        {
            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            var command = Connection.CreateCommand();
            command.CommandText = "update Student set FirstName = $firstName, LastName = $lastName, Email = $email where StudentId = $studentId";
            command.Parameters.AddWithValue("$studentId", student.Id);
            command.Parameters.AddWithValue("$firstName", student.FirstName);
            command.Parameters.AddWithValue("$lastName", student.LastName);
            command.Parameters.AddWithValue("$email", student.Email);

            command.ExecuteNonQuery();
            Connection.Close();

        }
    }
}
