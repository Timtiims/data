using HolmesglenStudentManagementSystem.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{
    public class DALDisconnected
    {
        private SQLiteConnection Connection;
        private SQLiteDataAdapter DataAdapter;
        private DataSet DBDataSet;
        private string DBQueryString = @"SELECT StudentID, FirstName, LastName, Email FROM Student;  
                                        SELECT SubjectId, Title FROM Subject; 
                                        SELECT EnrollmentID, StudentID_FK, SubjectID_FK FROM Enrollment;";
        
        public DALDisconnected(string connectionString)
        {
            Connection = new SQLiteConnection(connectionString);

            // create the data adapter
            DataAdapter = new SQLiteDataAdapter(DBQueryString, Connection);

            // populate the dataset
            DBDataSet = new DataSet();
            DataAdapter.Fill(DBDataSet);

            // give names to tables
            DBDataSet.Tables[0].TableName = "Student";
            DBDataSet.Tables[1].TableName = "Subject";
            DBDataSet.Tables[2].TableName = "Enrollment";
        }

        public List<Student> StudentReadAll()
        {
            var students = new List<Student>();
            foreach (DataRow row in DBDataSet.Tables["Student"].Rows)
            {
                var id = row["StudentID"].ToString();
                var firstName = row["FirstName"].ToString();
                var lastName = row["LastName"].ToString();
                var email = row["Email"].ToString();
                students.Add(new Student(id, firstName, lastName, email));
            }
            return students;
        }

        public Student Read(string id)
        {
            var studentTable = DBDataSet.Tables["Student"];
            foreach (DataRow row in studentTable.Rows)
            {
                if (String.Equals(row["StudentID"].ToString(), id))
                {
                    var student = new Student();
                    student.Id = row["StudentID"].ToString();
                    student.FirstName = row["LastName"].ToString();
                    student.LastName = row["LastName"].ToString();
                    student.Email = row["Email"].ToString();
                    
                    return student;
                }
            }

            return null;
        }

        public void StudentCreate(Student student)
        {
            var studentTable = DBDataSet.Tables["Student"];
            DataRow row = studentTable.NewRow();
            row["StudentID"] = student.Id;
            row["FirstName"] = student.FirstName;
            studentTable.Rows.Add(row);
            new SQLiteCommandBuilder(DataAdapter);
            DataAdapter.Update(studentTable);
            DBDataSet.AcceptChanges();
        }

        public void StudentDelete(string id)
        {
            var studentTable = DBDataSet.Tables["Student"];
            foreach (DataRow row in studentTable.Rows)
            {
                if (String.Equals(row["StudentID"].ToString(), id))
                {
                    row.Delete();
                    new SQLiteCommandBuilder(DataAdapter);
                    DataAdapter.Update(studentTable);
                    DBDataSet.AcceptChanges();
                    break;
                }
            }
        }

        public void StudentUpdate(Student student)
        {
            var studentTable = DBDataSet.Tables["Student"];
            foreach (DataRow row in studentTable.Rows)
            {
                if (String.Equals(row["StudentID"].ToString(), student.Id))
                {
                    // update
                    row["FirstName"] = student.FirstName;
                    row["LastName"] = student.LastName;
                    row["Email"] = student.Email;
                    new SQLiteCommandBuilder(DataAdapter);
                    DataAdapter.Update(studentTable);
                    DBDataSet.AcceptChanges();
                    break;
                }
            }

        }
    }
}
