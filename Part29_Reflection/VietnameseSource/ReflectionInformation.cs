namespace Part29_Reflection.VietnameseSource
{
    public class ReflectionInformation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Content { get; set; }

        public ReflectionInformation(int id)
        {
            Id = id;
        }

        public ReflectionInformation(string name, string content)
        {
            Name = name;
            Content = content;
        }

        public void Write()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("Name: " + Name);
        }

        public void Write(string name)
        {
            Console.WriteLine("Name: " + name);
        }
    }
}
