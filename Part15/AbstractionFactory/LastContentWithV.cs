namespace Part15.AbstractionFactory
{
    public class LastContentWithV : IContentFromParams
    {
        public List<string> GetLastContent(FindWantedFile file)
        {
            List<string> result = new List<string>() { $"\n---------- {file.PathFile.ToUpper()}"};

            foreach (var item in file.ContentOriginal)
            {
                if (!item.Contains(file.SearchedString))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
