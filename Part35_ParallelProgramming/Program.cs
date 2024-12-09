using Part35_ParallelProgramming.AISampleCodeInParrallelForAndForEach;
using Part35_ParallelProgramming.TaskBasedAsyncProgramming;

namespace Part35_ParallelProgramming
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //How to: Iterate File Directories with the Parallel Class
            //await IterateFileDirectories.MainIterateFileDirectories();

            // Parallel.For Example In AI Claude
            //ParallelFor.MainParallelFor();

            // Parallel.ForEach Example In AI Claude
            //ParallelForEach.MainParallelForEach();

            //TaskBasedExample.MainTestTaskFactoryWithObjectInConstruction();
            //TaskBasedExample.MainThreadWithCulture();
            //TaskBasedExample.MainContinueWithInTask();
            //await TaskBasedExample.MainCancellationWithContinueWith();
            //await TaskBasedExample.MainCanCelATaskAndItChild();
            //TaskBasedExample.MainUnwrapANestedData();
            TaskBasedExample.MainPreventChildTaskToAttachToParent(args);
        }
    }
}
