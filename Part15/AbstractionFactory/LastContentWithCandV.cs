namespace Part15.AbstractionFactory
{
    public class LastContentWithCandV : IContentFromParams
    {
        //hiển thị số dòng không chứa từ khóa (có phân biệt hoa thường)
        public List<string> GetLastContent(FindWantedFile file)
        {
            int count = 0;
            foreach (var item in file.ContentOriginal)
            {
                if (!item.Contains(file.SearchedString))
                {
                    count++;
                }
            }

            return new List<string>() { $"\n---------- {file.PathFile.ToUpper()}: {count}" };  
        }
    }
}
