using System;
using System.Text;


namespace 数据转换成字节数
{
    class Program
    {
        static void Main(string[] args)
        {
            //Byte[] Data = Encoding.UTF8.GetBytes("a");
            int count = 100000;
            Byte[] Data = BitConverter.GetBytes(count);
            foreach (byte d in Data) {
                Console.Write(d+",");
            }
            Console.ReadKey();
        }
    }
}
