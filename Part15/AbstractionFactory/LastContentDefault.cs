namespace Part15.AbstractionFactory
{
    public class LastContentDefault : IContentFromParams
    {
        //trả về danh sách các dòng có từ khóa trong file
        public List<string> GetLastContent(FileToFind file)
        {
            List<string> result = new List<string>() {  $"\n---------- {file.PathFile.ToUpper()}" };

            foreach (var item in file.ContentOriginal)
            {
                if (item.Contains(file.SearchedString))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
