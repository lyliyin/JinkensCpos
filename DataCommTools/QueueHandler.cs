using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataCommTools
{
    /// <summary>
    /// 处理小型队列
    /// </summary>
    public class QueueHandler<T>
    {
        private static Queue<Dictionary<string, List<T>>> queue = new Queue<Dictionary<string, List<T>>>();
        //入队列
        public static void Enqueue(Dictionary<string, List<T>> dic)
        {
            queue.Enqueue(dic);
        }
        //设置后台多线程 
        public static void DoProcess()
        {
            Thread thread = new Thread(Dequeue);
            thread.Start();
            thread.IsBackground = true;
        }
        //处理队列信息
        private static void Dequeue()
        {
            while (true)
            {
                if (queue.Count > 0)
                {
                    Dictionary<string,List<T>> dic = queue.Dequeue();
                    //做业务处理
                }
                else
                {
                    Thread.Sleep(3000);
                }
            }
        }
    }
}
