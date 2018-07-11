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
            sqlConnection.Open();
            //windows认证
            //sqlConnection = new SqlConnection("server=.;database=db20180708_laozhang;integrated security=true");

        }        
        public  void UpdateTable(DataSet db, string tableName,reviseClass reviseData)
        {            
            sql = "select * from " + tableName;
            DataTable dt = null;       
            try
            {
                
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = new SqlCommand(sql, sqlConnection);
                SqlCommandBuilder cb = new SqlCommandBuilder(sda);//自动生成相应的命令，这句很重要
                
                sda.Fill(db);
                dt = db.Tables[0];
                DataRow dr = dt.NewRow();

                //for (int i = 0; i < reviseData.getHashtable().Count; i++)
                //{
                //    dr[reviseData.getKeys()[i]] = reviseData.getValues()[i];
                //    dt.Rows.Add(dr);
                //}
                              
                dr["均深"] = 9999.0f;               
                dt.Rows.Add(dr);

                sda.Update(dt);//对表的更新提交到数据库
                               //DataRow[] drs = dt.Select(null, null, DataViewRowState.Added);//或者搜索之后再更新
                               //sda.Update(drs);

                dt.AcceptChanges();
            }
            catch (SqlException ex)
            { }
            finally
            {
                sqlConnection.Close();
            }
        }


    }
}
