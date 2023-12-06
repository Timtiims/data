using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class StudentBLLConnected
    {
        private DALConnected DALConnected;
        public StudentBLLConnected()
        {
            DALConnected = new DALConnected(HolmesglenDB.ConnectionString);
        }
        public List<Student> GetALl()
        {
            return DALConnected.StudentReadAll();
        }
    }
}
