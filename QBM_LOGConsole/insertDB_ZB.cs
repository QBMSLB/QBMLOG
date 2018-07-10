using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace QBM_LOGConsole
{
    class insertDB_ZB
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private int intResult = -1;
        private String sql;

        public insertDB_ZB()
        {
            //SqlServer认证
            sqlConnection = new SqlConnection("server=MicroWin10-1040\\SQLEXPRESS;database=logdata;uid=sa;pwd=123456");
            //windows认真
            //sqlConnection = new SqlConnection("server=.;database=db20180708_laozhang;integrated security=true");

        }
        
        public void add(string tableName)
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

    class constructDB
    {
        private ArrayList arraylist;
        public constructDB(DataSet db)
        {
            for (int i = 0; i < db.Tables[0].Columns.Count; i++)
            {
                arraylist[i] = db.Tables[0].Columns[i].ToString();
            }
           
        }
        public string[] toArray ()
        {
            string[] columnName=new string[arraylist.Count];
            for (int i = 0; i < arraylist.Count; i++)
            {
                columnName[i] = arraylist[i].ToString();
            }
            return columnName;
        }

    }
}
