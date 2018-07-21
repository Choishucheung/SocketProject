using MySql.Data.MySqlClient;
using System;

namespace MySQL数据库操作
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=localhost;port=3306;database=mytest;user=root;password=asd1235a;SslMode = none;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            //MySQL命令 语句 通道对象
            MySqlCommand comm = new MySqlCommand("select * from user where id = 1",conn);
            //执行查询 返回多条 0 条都可以  reader 流读取
            MySqlDataReader reader =  comm.ExecuteReader();
            if (reader.HasRows) {
                reader.Read();
                string username = reader.GetString("username");//传递索引
                string password = reader.GetString("password");
                Console.WriteLine(username + password);
                
            }

            reader.Close();
            conn.Close();
            Console.ReadKey();
        }
    }
}
