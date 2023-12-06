using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Globalization;
using HolmesglenStudentManagementSystem.Models;


namespace HolmesglenStudentManagementSystem.DataAccessLayer

{
    public class ExportDAL
    {
        private SqliteConnection Connection;
        string csvFilePath2 = @"Student2.csv";

        public ExportDAL(SqliteConnection connection)
        {
            Connection = connection;
            connection.Open();

            try
            {
                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM Student";

                using (var reader = selectCommand.ExecuteReader())
                using (var csvWriter = new CsvWriter(new StreamWriter(csvFilePath2), CultureInfo.InvariantCulture))
                {
                    // Write CSV header
                    csvWriter.WriteHeader<Student>();
                    csvWriter.NextRecord();

                    // Write data to CSV
                    while (reader.Read())
                    {
                        var record = new Export
                        {
                            StudentID = reader["StudentID"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                        };

                        csvWriter.WriteRecord(record);
                        csvWriter.NextRecord();
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}