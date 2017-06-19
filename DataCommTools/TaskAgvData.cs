using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataCommTools
{
    public class TaskAgvData
    {
        public void HandlerData<T>(List<T> dataSource, Action<object> action, int taskCount = 5, int PageSize = 100)
        {
            int PageCount = dataSource.Count % PageSize == 0 ? dataSource.Count / PageSize : dataSource.Count / PageSize + 1;
            List<Task> taskLst = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();
            for (int i = 0; i < PageCount; i++)
            {
                var data = dataSource.Skip(PageSize * i).Take(PageSize);
                Task taskfactory = taskFactory.StartNew(action, data);
                taskLst.Add(taskfactory);
                if (i > taskCount)
                {
                    taskLst = taskLst.Where(m => !m.IsCanceled && !m.IsCompleted && !m.IsFaulted).ToList();
                    Task.WaitAny(taskLst.ToArray());
                }
            }
        }

        public void Test()
        {
            Action<object> action = t => CallBack(t);
            HandlerData<string>(new List<string>(), action);
        }

        public void CallBack(object obj)
        {

        }
    }
}
