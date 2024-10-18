namespace Part29_Reflection.Basics
{
    public class DemoEventArgs : EventArgs
    {
        public string Message { get; }
        public DemoEventArgs(string message)
        {
            Message = message;
        }
    }
}
