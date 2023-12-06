using HolmesglenStudentManagementSystem.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.BusinessLogicLayer
{
    public class ImportBLL
    {
        AppDAL appDAL;
        public ImportBLL()
        {
            appDAL = new AppDAL();
        }
        public void ImportData()
        {
            try
            {
                using (var connection = appDAL.Connection)
                {
                    ImportDAL importDAL = new ImportDAL(connection);
                    importDAL.ImportData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
            }
        }
    }
}
