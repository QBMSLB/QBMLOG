using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QBM_LOGConsole
{
    class reviseDB_ZB
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
        private SqlDataAdapter sqlDataAdapter;
        private string sql;
      


        public reviseDB_ZB()
        {
            //SqlServer认证
            sqlConnection = new SqlConnection("server=MicroWin10-1040\\SQLEXPRESS;database=logdata;uid=sa;pwd=123456");
            //windows认真
            //sqlConnection = new SqlConnection("server=.;database=db20180708_laozhang;integrated security=true");

        }
        public void fillDB(DataSet db, string tableName)
        {
            sql = "select * from " + tableName;
            sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            sqlDataAdapter.Fill(db);

            SqlCommandBuilder sqlCommandBuilder1 = new SqlCommandBuilder(sqlDataAdapter);
            //以sqlDataAdapter1为参数来初始化SqlCommandBuilder实例

            db.Tables[0].Rows[0].Delete();
            //删除DataSet中删除数据表Customers中第一行数据

            Console.WriteLine(db.Tables[0].Rows[1][5].ToString());
            Console.WriteLine(db.Tables[0].TableName);

            
            db.Tables[0].Columns[0].AutoIncrement = true;//表明第一列也就是对应表中的ID列是自动递增的
            db.Tables[0].Columns[0].AutoIncrementStep = 1;//递增的增量为1

            sqlDataAdapter.Update(db, db.Tables[0].TableName);
            //调用Update方法，以DataSet中的数据更新从数据库
            db.Tables["Sheet1$"].AcceptChanges();

            sqlConnection.Close();
        }
        
    }
}
