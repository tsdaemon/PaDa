using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PaDa.Lib.Helpers
{
    public static class ThreadPoolHelper
    {
        public static int MAX_TASKS_COUNT = 64;
        public static void SpawnAndWait(IEnumerable<Action> actions)
        {
            var list = actions.Take(MAX_TASKS_COUNT).ToArray();
            var spawn = 0;
            do
            {
                var handles = new ManualResetEvent[list.Length];
                for (var i = 0; i < list.Length; i++)
                {
                    handles[i] = new ManualResetEvent(false);
                    var currentAction = list[i];
                    var currentHandle = handles[i];
                    Action wrappedAction = () =>
                    {
                        try
                        {
                            currentAction?.Invoke();
                        }
                        finally
                        {
                            currentHandle.Set();
                        }
                    };
                    ThreadPool.QueueUserWorkItem(x => wrappedAction());
                }
                WaitHandle.WaitAll(handles);
                spawn++;
                list = actions.Skip(MAX_TASKS_COUNT * spawn).Take(MAX_TASKS_COUNT).ToArray();
            } while (list.Length > 0);
        }
    }
}
