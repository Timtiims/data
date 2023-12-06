using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.Import
{
    public class ImportPL : PLBase
    {
        public override void Run()
        {
            var import = new ImportBLL();
            import.ImportData();
            Console.WriteLine("Imported");
        }
    }
}
