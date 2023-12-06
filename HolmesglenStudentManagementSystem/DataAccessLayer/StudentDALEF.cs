using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.DataAccessLayer
{


    public class StudentDALEF
    {
        private AppDBContext db;

        public StudentDALEF(AppDBContext appDBContext)
        {
            this.db = appDBContext;
        }
        // Method: ReadAll
        public List<Student> ReadAll()
        {
            var students = db.Students.ToList();
            return students;
        }
        // Method: Read one by Id
        public Student Read(string id)
        {
            Student student = db.Students.Find(id);
            return student;
        }
        // Method: Create a student
        public bool Create(Student student)
        {
            if (db.Students.Find(student.Id) == null)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        // Method: Update a student by Id
        public bool Update(Student student)
        {
            var studentToUpdate = db.Students.Find(student.Id);
            if (studentToUpdate == null)
            {
                return false;
            }
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Email = student.Email;
            db.SaveChanges();
            return true;
        }
        // Method: Delete a student by Id
        public bool Delete(string id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return false;
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return true;
        }
    }

}
