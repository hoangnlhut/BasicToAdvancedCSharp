namespace Part15.Decoration
{
    public class ConsoleFindComponent : IProcessorFindComponent
    {
        public IEnumerable<string?> Save(List<string> content)
        {
            foreach (var item in content)
            {
                Console.WriteLine(item);
            }
            return new List<string> { };
        }
    }
}
