﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP服务器端
{
    class Message
    {
        private byte[] data = new byte[1024];
        private int beginCount = 0;

        public byte[] Data {
            get {
                return data;
            }
        }

        public int BeginCount {
            get {
                return beginCount;
            }
        }

        public int EndCount {
            get {
                return 1024 - beginCount;
            }
        }


        //public void addCount(int count){
        //    beginCount += count;
        //}
        /// <summary>
        /// 解析数据
        /// </summary>
        public void ReadMessage(int newDataAmount) {
            beginCount += newDataAmount;
            while (true)
            {
                if (beginCount < 4)
                {
                    break;
                }

                int count = BitConverter.ToInt32(data, 0);
                Console.Write("读取出来的数据数量为" + count);
                if ((beginCount - 4) >= count)
                {
                    string s = Encoding.UTF8.GetString(data, 4, count);
                    Console.WriteLine("解析数据" + s);
                    Array.Copy(data, count + 4, data, 0, beginCount - 4 - count);
                    beginCount = beginCount - 4 - count;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
