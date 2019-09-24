using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo1
{
    class Program
    {
        private static string connString = @"Data Source=192.168.7.222;Database=db_MyQQ;User ID=Sa;Pwd=123456;";
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
    static void Main(string[] args)
        {
            //
            Console.WriteLine(fibonacacii(20));

            Console.WriteLine(fibonacacii(40));

            Console.ReadLine();
        }
        public static int fibonacacii(int i)
        {
            if(i<0)
            {
                return 0;
            }
            else if (i>0 && i<=2)
            {
                return 1;
            }
            else
            {
                return fibonacacii(i - 1) + fibonacacii(i - 2);
            }
        }
    }
}
