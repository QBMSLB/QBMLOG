using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace QBM_LOGConsole
{
    public class adoLoadExcel_ZB
    {
        private OleDbConnection oleDbConnection;
        public adoLoadExcel_ZB(string path)
        {
            string connString = @"Provider = Microsoft.Jet.OLEDB.4.0; Extended Properties = Excel 8.0; Data Source = "+path;
            oleDbConnection = new OleDbConnection(connString);
            oleDbConnection.Open();
        }
        public DataSet conExcel()
        {
            string sql = "select * from [Sheet1$]";//和sqlserver查询语句几乎差不多，就是在表名上需要加上[表名$]
            OleDbDataAdapter da = new OleDbDataAdapter(sql, oleDbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;



        }

        public void closeDB()
        {
            oleDbConnection.Close();
        }
        
        

    }
    
    
}
