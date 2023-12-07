using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class StudentBLLEF
    {
        private DataAccessLayer.StudentDALEF studentDAL;

        public StudentBLLEF(AppDBContext appDBContext)
        {
            this.studentDAL = new DataAccessLayer.StudentDALEF(appDBContext);
        }

        // Business Logic: Get all students
        public List<Student> GetAllStudents()
        {
            return studentDAL.ReadAll();
        }

        // Business Logic: Get student by ID
        public Student GetStudentById(string studentId)
        {
            return studentDAL.Read(studentId);
        }

        // Business Logic: Create a new student
        public bool CreateStudent(Student student)
        {
            // Add additional business logic validation if needed
            return studentDAL.Create(student);
        }

        // Business Logic: Update student information
        public bool UpdateStudent(Student student)
        {
            // Add additional business logic validation if needed
            return studentDAL.Update(student);
        }

        // Business Logic: Delete student by ID
        public bool DeleteStudent(string studentId)
        {
            // Add additional business logic validation if needed
            return studentDAL.Delete(studentId);
        }
    }
}