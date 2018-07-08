using System;
using System.Text;
using System.Linq;


namespace TCP客户端
{
    class Message
    {//静态工具类
        public static byte[] getBeytes(string data) {

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            int Length = dataBytes.Length;
            byte[] lengthBytes = BitConverter.GetBytes(Length);
            byte[] newBytes = lengthBytes.Concat(dataBytes).ToArray();
            return newBytes;
        }
    }
}
