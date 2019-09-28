using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MyQQ
{
    class DataOperator
    {
        //数据库连接字符串
        private static string connString = "Data Source=.;Database=MyQQ;User ID=sa;Pwd=123456;";
        //数据库连接对象
        public static SqlConnection connection = new SqlConnection(connString);
        //执行sql语句方法

        public int ExecSql(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);//指定也好执行的sql语句
            if (connection.State == ConnectionState.Closed)//判断当前数据库是否处于关闭状态
            {
                connection.Open();//打开数据库连接
            }
            int num = Convert.ToInt32(command.ExecuteScalar());//执行查询
            connection.Close();//结束关闭数据库连接
            return num;//返回结果中的第一行第一列
        }

        public int ExecSQLResult(string sql)
        {
            SqlCommand command = new SqlCommand(sql, connection);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            int result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public DataSet GetDataSet(string sql)
        {
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            return ds;
        }
    }

}
