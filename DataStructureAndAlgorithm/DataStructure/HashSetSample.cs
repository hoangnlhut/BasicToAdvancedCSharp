using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DataStructure
{
    public class HashSetSample
    {
        public void Test()
        {
            //create Set even numbers
            HashSet<int> evenNumbers = new HashSet<int>();
            for (int i = 0; i < 5; i++)
            {
                evenNumbers.Add(i * 2);
            }

            evenNumbers.Add(40);

            //create Set odd numbers
            HashSet<int> oddNumbers = new HashSet<int>();
            for (int i = 0; i < 5; i++)
            {
                oddNumbers.Add(i * 2 + 1);
            }
            oddNumbers.Add(41);

            // create new Hash Set from existed Set
            HashSet<int> newHash = new HashSet<int>(evenNumbers);

            //delete one item in HashSet
            newHash.Remove(2);

            // check if one item is existed
            if (newHash.Contains(4))
            {
                Console.WriteLine("4 is existed in sets");
            }

            newHash.Add(40);
            //Display all item
            DisplayAllItem(newHash);

            newHash.IntersectWith(oddNumbers);
            //Display all item
            DisplayAllItem(newHash);


            HashSet<int> newHashUnion = new HashSet<int>(evenNumbers);
            newHashUnion.UnionWith(oddNumbers);
            DisplayAllItem(newHashUnion);

            HashSet<int> newHashExcept = new HashSet<int>(evenNumbers);
            newHashExcept.ExceptWith(oddNumbers);
            DisplayAllItem(newHashExcept);

        }

        private void DisplayAllItem(HashSet<int> newHash)
        {
            Console.WriteLine($"Print all {newHash.Count} item in sets");
            foreach (var item in newHash)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------");
        }
    }
}
