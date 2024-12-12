using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Part35_ParallelProgramming.Dataflow
{
    public class ProducerConsumerDataFlowPattern
    {
        //reference: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-implement-a-producer-consumer-dataflow-pattern

        #region using ITargetBlock and ISourceBlock
        static void Produce(ITargetBlock<byte[]> target)
        {
            var rand = new Random();

            for (int i = 0; i < 100; ++i)
            {
                var buffer = new byte[1024];
                rand.NextBytes(buffer);
                target.Post(buffer);
            }

            target.Complete();
        }

        static async Task<int> ConsumeAsync(ISourceBlock<byte[]> source)
        {
            int bytesProcessed = 0;

            while (await source.OutputAvailableAsync())
            {
                byte[] data = await source.ReceiveAsync();
                bytesProcessed += data.Length;
            }

            return bytesProcessed;
        }
        #endregion


        #region using TranformBlock
        static void ProduceTransform(TransformBlock<byte[], int> target)
        {
            var rand = new Random();

            for (int i = 0; i < 100; ++i)
            {
                var buffer = new byte[1024];
                rand.NextBytes(buffer);
                target.Post(buffer);
            }

        }

        static async Task<int> ReceiveTransform(TransformBlock<byte[], int> source)
        {
            int bytesProcessed = 0; 
            for (int i = 0; i < 100; ++i)
            {
                bytesProcessed += await source.ReceiveAsync();
            }
            return bytesProcessed;
        }
        #endregion



        public static async Task MainProducerConsumerDataFlowPattern()
        {
            #region using BufferBlock
            Console.WriteLine("Using BufferBlock");
            var buffer = new BufferBlock<byte[]>();
            var consumerTask = ConsumeAsync(buffer);
            Produce(buffer);

            var bytesProcessed = await consumerTask;

            Console.WriteLine($"Processed BufferBlock: {bytesProcessed:#,#} bytes.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region Using TransformBlock
            Console.WriteLine("Using TransformBlock");
            var transform = new TransformBlock<byte[], int>(source => source.Length);
            ProduceTransform(transform);
            Console.WriteLine($"Processed TransformBlock { await ReceiveTransform(transform):#,#} bytes.");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            #endregion
        }
    }
}
