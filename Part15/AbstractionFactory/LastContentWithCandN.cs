namespace Part15.AbstractionFactory
{
    public class LastContentWithCandN : IContentFromParams
    {
        public List<string> GetLastContent(FindWantedFile file)
        {
            int count = 0;
            foreach (var item in file.ContentOriginal)
            {
                if (item.Contains(file.SearchedString))
                {
                    count++;
                }
            }

            return new List<string>() { $"\n---------- {file.PathFile.ToUpper()}: {count}" };
        }
    }
}
