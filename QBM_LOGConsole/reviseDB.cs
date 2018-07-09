using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QBM_LOGConsole
{
    class reviseDB
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
        private SqlDataAdapter sqlDataAdapter;
        private int intResult = -1;
        private String sql;


        public reviseDB()
        {
            //SqlServer认证
            sqlConnection = new SqlConnection("server=.;database=db20180708_laozhang;uid=sa;pwd=123456");
            //windows认真
            //sqlConnection = new SqlConnection("server=.;database=db20180708_laozhang;integrated security=true");

        }
        public void fillDB(DataSet db, string tableName)
        {
            sql = "select * from " + tableName;
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Update(db);
            sqlConnection.Close();
        }
        public void insertDB(string tableName)
        {
            sqlConnection.Open();
            sql = "insert into sheet1$ (title, ccontent, ifOK, importance, finishDate) values('t1', 'c1', 1, 90, '2018-07-09 08:53:00')";
            sqlCommand = new SqlCommand(sql, sqlConnection);
            intResult = sqlCommand.ExecuteNonQuery();
            if (intResult > 0)
            {
                Console.WriteLine("insertOK");
            }
            else
            {
                Console.WriteLine("insertNotOK");
            }
            //sqlCommand = null;
            sqlConnection.Close();
            //sqlConnection = null;
        }
    }
}
