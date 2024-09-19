﻿using Microsoft.Extensions.Configuration;

namespace Part17_ADO.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = builder.Build();

            Console.WriteLine("Data of Region table");
            Region region = new Region(configuration);
            //region.GetLogins();

            //region.Add("hoang");
            //region.Update(1, "Europe new new");
            //region.Delete(12);
            //region.All();
            region.CommitTransaction(8, 11, "viet new", "le hoang viet");
            region.RollbackTransaction(1007, 10, "viet1", "le hoang viet2222");
        }
    }
}
