namespace Part15.Decoration
{
    public class FakeForTestingComponent : IProcessorFindComponent
    {
        public IEnumerable<string> Save(List<string> content)
        {
            return content;
        }
    }
}
