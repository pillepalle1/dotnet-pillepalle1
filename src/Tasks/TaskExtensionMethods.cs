using System;
using System.Threading.Tasks;

namespace pillepalle1.Tasks
{
    public static class TaskExtensionMethods
    {
        /// <summary>
        /// A handy extension method that awaits a task and wraps it in a try-catch block. This facilitates detecting crashes
        /// of fire-and-forget Tasks.
        /// </summary>
        public async static Task WrapTryCatch(this Task t, Action<Exception> errorCallback = null, Action completedCallback = null)
        {
            await t.WrapTryCatch<Exception>(errorCallback, completedCallback);
        }

        /// <summary>
        /// Extension method that awaits a task and catches a specific Exception.
        /// </summary>
        public async static Task WrapTryCatch<TException>(this Task task, Action<TException> errorCallback = null, Action completedCallback = null)
            where TException : Exception
        {
            try
            {
                await task;
                completedCallback?.Invoke();
            }
            catch (TException e)
            {
                errorCallback?.Invoke(e);
            }
        }
    }
}