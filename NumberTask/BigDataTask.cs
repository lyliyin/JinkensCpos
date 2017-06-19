using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NumberTask
{
    /// <summary>
    /// 大数据线程 {可以将数据平分给每一个线程}
    /// </summary>
    public static class BigDataTask
    {
        /// <summary>
        /// 处理多线程数据的平分
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lstData">数据源</param>
        /// <param name="fun">委托处理函数</param>
        /// <param name="taskCount">需要开启的线程数量</param>
        /// <param name="PageSize">每个线程需要处理数据量 默认为100 条数据</param>
        public static void TaskStartNew<T>(List<T> lstData, Action<object> fun, int taskCount = 5, int PageSize = 100)
        {
            List<Task> lstTask = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();
            int count = lstData.Count;
            int totalPage = count % PageSize == 0 ? count / PageSize : count / PageSize + 1;
            for (int i = 0; i <= totalPage; i++)
            {
                List<T> data = lstData.Skip(PageSize * (i)).Take(PageSize).ToList();
                if (data.Count() > 0)
                {
                    Task task = taskFactory.StartNew(fun, data);
                    lstTask.Add(task);
                    if (i > taskCount)
                    {
                        lstTask = lstTask.Where(m => !m.IsCanceled && !m.IsCompleted && !m.IsFaulted).ToList();
                        Task.WaitAny(lstTask.ToArray());
                    }
                }
            }
            Task.WaitAll(lstTask.ToArray());
        }

        public static void ThreadStart()
        {
            ThreadStart start = new ThreadStart(() =>
              {
                  TestThreadStart("xiaoyinzi");
              });
            Thread thread = new Thread(start);
            thread.Start(); //开启线程
        }

        public static void TestThreadStart(string Name)
        {

        }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }


        public List<Category> Initial()
        {
            return new List<Category>()
            {
                new Category() { Id=1, Name="电子产品", Code="ZK1001" },
                new Category() { Id=2, Name="手机", Code="ZK1002" },
                 new Category() { Id=3, Name="数码产品",  Code="ZK1003" },
                 new Category() { Id=3, Name="服装设计",  Code="ZK1004" },
                 new Category() { Id=3, Name="男装",  Code="ZK1005" },
                 new Category() { Id=3, Name="女装",  Code="ZK1006" },
                 new Category() { Id=3, Name="童装",  Code="ZK1007" }
            };
        }
    }
}
