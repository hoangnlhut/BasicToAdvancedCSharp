namespace Part26Configurations
{
    public sealed class NestedSettings
    {
        public required string Message { get; set; } = null!;
        public SupportedVersions SupportedVersions { get; set; }
    }
}