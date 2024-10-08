namespace Part26Configurations
{
    public sealed partial class Settings
    {
        public required int KeyOne { get; set; }
        public required bool KeyTwo { get; set; }
        public required NestedSettings KeyThree { get; set; } = null!;
        public string[] IPAddressRange { get; set; }

        public TransientFaultHandlingOptions TransientFaultHandlingOptions { get; set; }
    }
}