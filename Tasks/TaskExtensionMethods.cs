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
            try
            {
                await t;
                completedCallback?.Invoke();
            }
            catch (Exception e)
            {
                errorCallback?.Invoke(e);
            }
        }
    }
}