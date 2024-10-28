namespace Part30Thread.SynchronizationThreads
{
    public class BlockingQueue<T>
    {
        private readonly List<T> _queue = [];
        public bool IsOutOfQueue => _queue.Count <= 0 ? true : false;

        private readonly EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);

        public void EnQueue(T item)
        {
            _queue.Add(item);
            ewh.Set();
        }

        public T DeQueue()
        {
            //Console.WriteLine("Before Dequeue Wait One");
            ewh.WaitOne();
            //Console.WriteLine("After Dequeue Wait One");

            var item = _queue.First();
            _queue.RemoveAt(0);

            //Console.WriteLine("Dequeue successfully");

            // if set Manually in ewh, you have to use this instruction
            // if  set autoreset in ewh field, you can comment it due to automatically reset it.
            //ewh.Reset();

            return item;
        }
    }    

}
