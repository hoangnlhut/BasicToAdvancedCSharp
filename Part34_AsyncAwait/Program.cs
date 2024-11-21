using Part34_AsyncAwait.Basics;
using Part34_AsyncAwait.ThreadPoolSample;

namespace Part34_AsyncAwait
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region async await basic
            //await AsyncAwaitBasic.MainAsyncAwaitBaic();
            #endregion

            //await AsycnAwaitUnderThehood.MainUnderTheHood();

            ThreadPoolExample.MainThreadPoolExample();
        }
    }
}
