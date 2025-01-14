using Part36_ParallelLINQ_ParallelProgramming.CustomPartitionersForPLINQAndTPL;
using Part36_ParallelLINQ_ParallelProgramming.PLinqDataSample;

internal class Program
{
    private static void Main(string[] args)
    {
        //SimplePLinqQuery.MainSimplePLinqQuery();

        #region Control Ordering in a PLINQ Query
        //ControlOrderinginaPLINQQuery.Example1();
        //ControlOrderinginaPLINQQuery.SimpleOrdering();
        //ControlOrderinginaPLINQQuery.OrderedThenUnordered();    
        #endregion

        //SequenceDemo.SequentialDemo();

        //HandleException.PLINQExceptions_1();
        //HandleException.PLINQExceptions_2();

        //CancelAQuery.MainCancelAQuery_1();
        //CancelAQuery.MainancelAQuery_2();

        //CustomAggregateFunction.MainCustomAggregateFunction();

        //MergeOption.MainMergeOptionNotBuffer();
        //MergeOption.MainMergeOptionAutoBuffer();
        //MergeOption.MainMergeOptionFullyBuffer();

        //IterateFileDirectories.FileIterationOne(@"E:\Hoang_Corner\EBOOKS");
        //Console.WriteLine();
        //Console.WriteLine();
        //IterateFileDirectories.FileIterationTwo(@"E:\Hoang_Corner\EBOOKS");

        //UsingStopWatchToMeasureQueryPerformance.MainUsingStopWatchToMeasureQueryPerformance();

        //How to: Implement Dynamic Partitions
        //ConsumerClass.MainConsumerClass();

        //How to: Implement a Partitioner for Static Partitioning
        //StaticPartitioningConsumer.MainStaticPartitioningConsumer();

        Part36_ParallelLINQ_ParallelProgramming.Test hoang = new Part36_ParallelLINQ_ParallelProgramming.MyClass("hoang");
        hoang.Print();

    }
}