namespace Part30Thread
{
    internal partial class Program
    {
        public class ThreadInputModel {

            public string Name { get; set; }
            public string Address { get; set; }
            public CancellationToken Cts { get; set; }
        }

    }
}
