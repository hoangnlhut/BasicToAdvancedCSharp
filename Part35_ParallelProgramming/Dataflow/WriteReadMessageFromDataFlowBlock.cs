using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Part35_ParallelProgramming.Dataflow
{
    //reference: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-messages-to-and-read-messages-from-a-dataflow-block
    public class WriteReadMessageFromDataFlowBlock
    {
        static async Task AsyncSendReceive(BufferBlock<int> bufferBlock)
        {
            // Post more messages to the block asynchronously.
            for (int i = 0; i < 3; i++)
            {
                await bufferBlock.SendAsync(i);
                Console.WriteLine($"Send Async succeed : {i}");
            }

            // Asynchronously receive the messages back from the block.
            for (int i = 0; i < 3; i++)
            {
                var output = await bufferBlock.ReceiveAsync();
                Console.WriteLine($"Receive Async succeed : {output}");

            }

            // Output:
            //   0
            //   1
            //   2
        }

        public static async Task MainWriteReadMessageFromDataFlowBlock()
        {
            var bufferBlock = new BufferBlock<int>();

            #region Synchronous way
            // Post several messages to the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Posting {i}");
                bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Receiving {i}");
                Console.WriteLine(bufferBlock.Receive());
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // Output:
            //   0
            //   1
            //   2
            

            // Post more messages to the block.
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Posting {i}");
                bufferBlock.Post(i);
            }

            // Receive the messages back from the block.
            while (bufferBlock.TryReceive(out int value))
            {
                Console.WriteLine($"Try Receiving {value}");
                Console.WriteLine(value);
            }

            // Output:
            //   0
            //   1
            //   2
            #endregion

            #region Write to and read from the message block concurrently.
            var post01 = Task.Run(() =>
            {
                bufferBlock.Post(0);
                bufferBlock.Post(1);
            });
            var receive = Task.Run(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(bufferBlock.Receive());
                }
            });
            var post2 = Task.Run(() =>
            {
                bufferBlock.Post(2);
            });

            await Task.WhenAll(post01, receive, post2);

            // Output:
            //   0
            //   1
            //   2
            #endregion

            // Demonstrate asynchronous dataflow operations.
            await AsyncSendReceive(bufferBlock);
        }
    }
}
