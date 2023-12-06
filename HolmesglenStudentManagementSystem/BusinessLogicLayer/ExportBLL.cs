using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class ExportBLL
    {
        AppDAL appDAL;
        public ExportBLL()
        {
            appDAL = new AppDAL();
        }
        public void ExportData()
        {
            try
            {
                using (var connection = appDAL.Connection)
                {
                    ExportDAL exportDAL = new ExportDAL(connection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
            }
        }
    }
}
