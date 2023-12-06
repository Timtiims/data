using CsvHelper;
using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class ImportDAL


    {
        private SqliteConnection Connection;
        string csvFilePath = @"C:\Users\Student\Desktop\Student.csv";


        public ImportDAL(SqliteConnection connection)
        {
            string connectionString = @"Data Source=C:\Users\Student\Desktop\HolmesglenInstitude.db";

            connection.ConnectionString = connectionString;
            Connection = connection;


            // read data from csv and insert into the data base
            Connection.Open();
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Import>();
                foreach (var record in records)
                {
                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = @"INSERT INTO Student (StudentID, FirstName, LastName, Email) 
                                                     VALUES ($studentid, $firstname, $lastname, $email)";

                    insertCommand.Parameters.AddWithValue("$studentid", record.StudentID);
                    insertCommand.Parameters.AddWithValue("$firstname", record.FirstName);
                    insertCommand.Parameters.AddWithValue("$lastname", record.LastName);
                    insertCommand.Parameters.AddWithValue("email", record.Email);

                    insertCommand.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Data saved");
            Connection.Close();




        }
    }
}
