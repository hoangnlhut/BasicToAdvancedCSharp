namespace Part15.AbstractionFactory
{
    public class LastContentWithN : IContentFromParams
    {
        //hiện thị các dòng có xuất hiện từ khóa với định dạng sau
        //[index của dòng] nội dung dòng
        public List<string> GetLastContent(FindWantedFile file)
        {
            List<string> result = new List<string>() { $"\n---------- {file.PathFile.ToUpper()}" };

            for (int i = 0; i < file.ContentOriginal.Count; i++)
            {
                if (file.ContentOriginal[i].Contains(file.SearchedString))
                {
                    string newFormat = $"[{i+1}]{file.ContentOriginal[i]}";
                    result.Add(newFormat);
                }
            }

            return result;
        }
    }
}
