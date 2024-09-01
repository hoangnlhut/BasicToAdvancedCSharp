namespace Part15.AbstractionFactory
{
    public class LastContentWithI : IContentFromParams
    {
        //hiện thị tất cả các dòng có từ khóa cần tìm KHÔNG PHÂN BIỆT HOA THƯỜNG
        public List<string> GetLastContent(FileToFind file)
        {
            List<string> result = new List<string>() { $"\n---------- {file.PathFile.ToUpper()}" };

            foreach (var item in file.ContentOriginal)
            {
                if (item.Contains(file.SearchedString, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
