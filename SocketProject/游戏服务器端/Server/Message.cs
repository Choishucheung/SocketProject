using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Server
{
    class Message
    {
        private byte[] data = new byte[1024];
        private int beginIndex = 0;

        public byte[] Data
        {
            get
            {
                return data;
            }
        }

        public int BeginIndex
        {
            get
            {
                return beginIndex;
            }
        }

        public int EndIndex
        {
            get
            {
                return 1024 - beginIndex;
            }
        }
        /// <summary>
        /// 解析数据
        /// </summary>
        public void ReadMessage(int newDataAmount)
        {
            beginIndex += newDataAmount;
            while (true)
            {
                if (beginIndex < 4)
                {
                    break;
                }

                int count = BitConverter.ToInt32(data, 0);
                Console.Write("读取出来的数据数量为" + count);
                if ((beginIndex - 4) >= count)
                {
                    string s = Encoding.UTF8.GetString(data, 4, count);
                    Console.WriteLine("解析数据" + s);
                    Array.Copy(data, count + 4, data, 0, beginIndex - 4 - count);
                    beginIndex = beginIndex - 4 - count;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
