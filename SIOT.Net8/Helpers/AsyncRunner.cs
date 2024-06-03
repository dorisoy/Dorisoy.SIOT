using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIOT.Helpers
{
    public class AsyncRunner
    {
        public static void Run(Task task, Action<Task> onError = null)
        {
            if (onError == null)
            {
                task.ContinueWith((task1, o) => { }, TaskContinuationOptions.OnlyOnFaulted);
            }
            else
            {
                task.ContinueWith(onError, TaskContinuationOptions.OnlyOnFaulted);
            }
        }
    }
}
