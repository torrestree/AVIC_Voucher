using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Client.Helpers
{
    /// <summary>
    /// DHelper
    /// </summary>
    public static partial class DHelper
    {
        /// <summary>
        /// 在系统主线程交互
        /// </summary>
        /// <param name="dispatcher_execution"></param>
        /// <returns></returns>
        public static DispatcherOperation InvokeOnMain(Action dispatcher_execution)
        {
            return Application.Current.Dispatcher.BeginInvoke(dispatcher_execution);
        }

        /// <summary>
        /// 启动任务
        /// </summary>
        /// <param name="task_execution"></param>
        /// <returns></returns>
        public static Task StartTask(Action task_execution)
        {
            return Task.Factory.StartNew(task_execution);
        }
        /// <summary>
        /// 启动任务
        /// </summary>
        /// <param name="task_execution"></param>
        /// <param name="cts"></param>
        /// <returns></returns>
        public static Task StartTask(Action task_execution, CancellationTokenSource cts)
        {
            return Task.Factory.StartNew(task_execution, cts.Token);
        }
        /// <summary>
        /// 启动任务
        /// </summary>
        /// <param name="task_execution"></param>
        /// <returns></returns>
        public static Task<object> StartTask(Func<object> task_execution)
        {
            return Task.Factory.StartNew(task_execution);
        }
        /// <summary>
        /// 启动任务
        /// </summary>
        /// <param name="task_execution"></param>
        /// <param name="cts"></param>
        /// <returns></returns>
        public static Task<object> StartTask(Func<object> task_execution, CancellationTokenSource cts)
        {
            return Task.Factory.StartNew(task_execution, cts.Token);
        }
    }
}
