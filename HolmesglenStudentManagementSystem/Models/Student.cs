using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.Models
{
    [Table("Student")]
    public class Student
    {
        [Column("StudentID")]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Student()
        {
            Id = "";
            FirstName = "";
            LastName = "";
            Email = "";
        }

        public Student(string id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public Student(string id, string name)
        {
            Id = id;
            FirstName = name;
        }
    }
}
