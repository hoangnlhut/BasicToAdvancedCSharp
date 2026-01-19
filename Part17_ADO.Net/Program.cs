using Microsoft.Extensions.Configuration;

namespace Part17_ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDefaultValue();

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = builder.Build();

            Console.WriteLine("Data of Region table");
            //Region region = new Region(configuration);
            ////region.GetLogins();

            ////region.Add("hoang");
            ////region.Update(1, "Europe new new");
            ////region.Delete(12);
            ////region.All();
            //region.CommitTransaction(8, 11, "viet new", "le hoang viet");
            //region.RollbackTransaction(1007, 10, "viet1", "le hoang viet2222");
        }

        static void TestDefaultValue()
        {
            //non-nullable reference types
            Console.WriteLine("----- Non-nullable reference types -----");
            string hoang = default;
            int nguyen = default;
            Region region = default;
            Console.WriteLine($"string hoang: {hoang}");
            Console.WriteLine($"int nguyen: {nguyen}");
            Console.WriteLine($"Region region: {region}");

            Console.WriteLine("----------------------------------------");


            //nullable reference types
            Console.WriteLine("----- Nullable reference types -----");
            string? hoang1 = default;
            int? nguyen1 = default;
            Region? region1 = default;
            Console.WriteLine($"string hoang1: {hoang1}");
            Console.WriteLine($"int nguyen1: {nguyen1}");
            Console.WriteLine($"Region region1: {region1}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
