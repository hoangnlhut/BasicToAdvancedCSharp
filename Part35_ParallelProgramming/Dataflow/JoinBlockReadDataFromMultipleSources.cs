using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Part35_ParallelProgramming.Dataflow
{
    public class JoinBlockReadDataFromMultipleSources
    {
        //Reference: https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-use-joinblock-to-read-data-from-multiple-sources

        // Represents a resource. A derived class might represent
        // a limited resource such as a memory, network, or I/O
        // device.
        abstract class Resource
        {
        }

        // Represents a memory resource. For brevity, the details of
        // this class are omitted.
        class MemoryResource : Resource
        { 
            //public static int Count { get; set; } = 1;
            public string Name { get; set; }
        }

        // Represents a network resource. For brevity, the details of
        // this class are omitted.
        class NetworkResource : Resource
        {
            //public static int Count { get; set; } = 1;
            public string Name { get; set; }
        }

        // Represents a file resource. For brevity, the details of
        // this class are omitted.
        class FileResource : Resource
        {
            //public static int Count { get; set; } = 1;
            public string Name { get; set; }
        }

        public static Random NumberRandom = new Random();
        public static void MainJoinBlockReadDataFromMultipleSources()
        {
            // Create three BufferBlock<T> objects. Each object holds a different
            // type of resource.
            var networkResources = new BufferBlock<NetworkResource>();
            var fileResources = new BufferBlock<FileResource>();
            var memoryResources = new BufferBlock<MemoryResource>();

            // Create two non-greedy JoinBlock<T1, T2> objects.
            // The first join works with network and memory resources;
            // the second pool works with file and memory resources.

            var joinNetworkAndMemoryResources =
               new JoinBlock<NetworkResource, MemoryResource>(
                  new GroupingDataflowBlockOptions
                  {
                      Greedy = false
                  }
                  );

            var joinFileAndMemoryResources =
               new JoinBlock<FileResource, MemoryResource>(
                   new GroupingDataflowBlockOptions
                   {
                       Greedy = false
                   }
                  );

            // Create two ActionBlock<T> objects.
            // The first block acts on a network resource and a memory resource.
            // The second block acts on a file resource and a memory resource.

            var networkMemoryAction =
               new ActionBlock<Tuple<NetworkResource, MemoryResource>>(
                  data =>
                  {
                      Console.WriteLine("------------------------------------------------");
                      Console.WriteLine();

                      Console.WriteLine(data.Item1.Name);    
                      Console.WriteLine(data.Item2.Name);    
                      // Perform some action on the resources.

                      // Print a message.
                      Console.WriteLine("Network worker: using resources...");

                      // Simulate a lengthy operation that uses the resources.
                      Thread.Sleep(new Random().Next(500, 2000));

                      // Print a message.
                      Console.WriteLine("Network worker: finished using resources...");

                      // Release the resources back to their respective pools.
                      var numberForSave = NumberRandom.Next().ToString();

                      data.Item1.Name += numberForSave.ToString();
                      data.Item2.Name += numberForSave.ToString();


                      Console.WriteLine($"RandomNumber is {numberForSave}");
                      Console.WriteLine($"data.NetworkResource.Name in networkMemoryAction: {data.Item1.Name}");
                      Console.WriteLine($"data.MemoryResource.Name in networkMemoryAction: {data.Item2.Name}");

                      networkResources.Post(data.Item1);
                      memoryResources.Post(data.Item2);

                      Console.WriteLine();
                      Console.WriteLine("------------------------------------------------");
                  });

            var fileMemoryAction =
               new ActionBlock<Tuple<FileResource, MemoryResource>>(
                  data =>
                  {
                      Console.WriteLine("------------------------------------------------");
                      Console.WriteLine();

                      Console.WriteLine(data.Item1.Name);
                      Console.WriteLine(data.Item2.Name);

                      // Perform some action on the resources.

                      // Print a message.
                      Console.WriteLine("File worker: using resources...");

                      // Simulate a lengthy operation that uses the resources.
                      Thread.Sleep(new Random().Next(500, 2000));

                      // Print a message.
                      Console.WriteLine("File worker: finished using resources...");

                      var numberForSave = NumberRandom.Next().ToString();

                      data.Item1.Name += numberForSave.ToString();
                      data.Item2.Name += numberForSave.ToString();

                      Console.WriteLine($"RandomNumber is {numberForSave}");
                      Console.WriteLine($"data.FileResource.Name in fileMemoryAction: {data.Item1.Name}");
                      Console.WriteLine($"data.MemoryResource.Name in fileMemoryAction: {data.Item2.Name}");


                      // Release the resources back to their respective pools.
                      fileResources.Post(data.Item1);
                      memoryResources.Post(data.Item2);

                      Console.WriteLine();
                      Console.WriteLine("------------------------------------------------");

                  });

            // Link the resource pools to the JoinBlock<T1, T2> objects.
            // Because these join blocks operate in non-greedy mode, they do not
            // take the resource from a pool until all resources are available from
            // all pools.

            networkResources.LinkTo(joinNetworkAndMemoryResources.Target1);
            memoryResources.LinkTo(joinNetworkAndMemoryResources.Target2);

            fileResources.LinkTo(joinFileAndMemoryResources.Target1);
            memoryResources.LinkTo(joinFileAndMemoryResources.Target2);

            // Link the JoinBlock<T1, T2> objects to the ActionBlock<T> objects.

            joinNetworkAndMemoryResources.LinkTo(networkMemoryAction);
            joinFileAndMemoryResources.LinkTo(fileMemoryAction);

            // Populate the resource pools. In this example, network and
            // file resources are more abundant than memory resources.

            networkResources.Post(new NetworkResource() { Name = "network out1"});
            networkResources.Post(new NetworkResource() { Name = "network out2" });
            networkResources.Post(new NetworkResource() { Name = "network out3" });

            memoryResources.Post(new MemoryResource() { Name = "memory out1" });

            fileResources.Post(new FileResource() { Name = "file out1" });
            fileResources.Post(new FileResource() { Name = "file out2" });
            fileResources.Post(new FileResource() { Name = "file out3" });

            // Allow data to flow through the network for several seconds.
            Thread.Sleep(20000);
        }
    }
}
