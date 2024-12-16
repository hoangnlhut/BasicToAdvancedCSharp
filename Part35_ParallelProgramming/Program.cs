using Part35_ParallelProgramming.AISampleCodeInParrallelForAndForEach;
using Part35_ParallelProgramming.Dataflow;
using Part35_ParallelProgramming.TaskBasedAsyncProgramming;

namespace Part35_ParallelProgramming
{
    internal class Program
    {
        public static  void Main(string[] args)
        {
            #region Data Parallelism 
            //How to: Iterate File Directories with the Parallel Class
            //await IterateFileDirectories.MainIterateFileDirectories();

            // Parallel.For Example In AI Claude
            //ParallelFor.MainParallelFor();

            // Parallel.ForEach Example In AI Claude
            //ParallelForEach.MainParallelForEach();
            #endregion

            #region Parallel Programming: task-based TPL
            //TaskBasedExample.MainTestTaskFactoryWithObjectInConstruction();
            //TaskBasedExample.MainThreadWithCulture();
            //TaskBasedExample.MainContinueWithInTask();
            //await TaskBasedExample.MainCancellationWithContinueWith();
            //await TaskBasedExample.MainCanCelATaskAndItChild();
            //TaskBasedExample.MainUnwrapANestedData();
            //TaskBasedExample.MainPreventChildTaskToAttachToParent(args);
            #endregion

            #region Data Flow TPL model
            //await WriteReadMessageFromDataFlowBlock.MainWriteReadMessageFromDataFlowBlock();
            //await ProducerConsumerDataFlowPattern.MainProducerConsumerDataFlowPattern()
            //PerformActionWhenDataflowBlockReceivesData.MainPerformActionWhenDataflowBlockReceivesData();
            //ADataFlowPipeline.MainADataFlowPipeline();
            CustomDataBlockType.MainCustomDataBlockType();
            #endregion

        }
}
}
