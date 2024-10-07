using Part25Attributes.Attributes;
using System.Reflection.Metadata;

namespace Part25Attributes
{
    [Developer("Joan Smith", "1")]
    public class Program
    {
        static void Main(string[] args)
        {
            // This generates a compile-time warning.
            int i = ObseleteClass.Add(2, 2);

            GetAttributes(typeof(Program));


        }

        private static void GetAttributes(Type type)
        {
            DeveloperAttribute developerAttribute = (DeveloperAttribute) Attribute.GetCustomAttribute(type, typeof(DeveloperAttribute));

            if (developerAttribute is null)
            {
                Console.WriteLine("Developer Attribute is null");
            }
            else
            {
                Console.WriteLine("The name Attribute is {0}", developerAttribute.Name);
                Console.WriteLine("The Level Attribute is {0}", developerAttribute.Level);
            }
        }

        public class ObseleteClass
        {
            [Obsolete("Will be removed in next version")]
            public static int Add(int a, int b) => a + b;
        }
    }
}
