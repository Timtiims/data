using HolmesglenStudentManagementSystem.BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolmesglenStudentManagementSystem.PresentationLayer.Export
{
    public class ExportPL : PLBase
    {
        public override void Run()
        {
            var export = new ExportBLL();
            export.ExportData();
            Console.WriteLine("Exported");
        }
    }
}
