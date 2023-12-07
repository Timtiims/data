using HolmesglenStudentManagementSystem.DataAccessLayer;
using HolmesglenStudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class ReportBLL
    {
        private ReportDAL ReportDAL;

        public ReportBLL()
        {
            ReportDAL = new ReportDAL();
        }

        public Report Create(string id)
        {
            return ReportDAL.GetReport(id);
        }
    }
}
