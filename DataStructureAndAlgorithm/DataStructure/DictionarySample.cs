
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DataStructure
{
    public class DictionarySample
    {
        public void TestDictionary()
        {
            //initiate Dictionary
            Dictionary<string, int> myDictionary = new Dictionary<string, int>()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            };

            // asssign new value to an item of Dictionary
            myDictionary["one"] = 11;

            // add more item : 2 ways of add 
            myDictionary.Add("four", 4);
            myDictionary["five"] = 5;

            // update one item
            myDictionary["four"] = 6;

            // print one item
            Console.WriteLine($"{myDictionary["four"]}");

            // try to get value , if it does not exist it will throw exeption
            if (myDictionary.TryGetValue("three", out int result))
            {
                Console.WriteLine($"result : {result} to try get value");
            }
            else
            {
                throw new Exception("Can't find value ");
            }

            // check if there is a key
            if (!myDictionary.ContainsKey("two") || !myDictionary.ContainsValue(2))
            {
                throw new Exception("Can't find this value / key ");
            }

            // enumarate all item in Dictionay
            foreach (var item in myDictionary)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }

            // delete one item
            myDictionary.Remove("two");
            foreach (var item in myDictionary)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }

            // remove all dictionary
            myDictionary.Clear();
            foreach (var item in myDictionary)
            {
                Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
            }
        }
    }
}
