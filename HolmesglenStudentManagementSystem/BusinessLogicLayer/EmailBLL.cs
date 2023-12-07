using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class EmailBLL
    {
        private EmailDAL EmailDAL;

        public EmailBLL()
        {
            EmailDAL = new EmailDAL();
        }

        public EmailModel Create(string id)
        {
            
            return EmailDAL.GetEmail(id);
        }
    }
}
