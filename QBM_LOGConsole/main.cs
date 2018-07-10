using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBM_LOGConsole
{//
    class main
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\Administrator\\Desktop\\logData.xls";
            adoLoadExcel_ZB loadA = new adoLoadExcel_ZB(path);
            loadA.closeDB();
            Console.WriteLine("point1");

            reviseDB_ZB reviseA = new reviseDB_ZB();
            reviseA.fillDB(loadA.conExcel(), "Sheet1$");
            Console.WriteLine("point2");


            SVM_ZB x = new SVM_ZB();
            x.linnerSVM(loadA.conExcel());
            Console.WriteLine("point3");
        }
    }
}
