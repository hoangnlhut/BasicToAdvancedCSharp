namespace Part26Configurations
{
    public sealed class TransientFaultHandlingOptions
    {
        public bool Enabled { get; set; }
        public TimeSpan AutoRetryDelay { get; set; }
    }
}