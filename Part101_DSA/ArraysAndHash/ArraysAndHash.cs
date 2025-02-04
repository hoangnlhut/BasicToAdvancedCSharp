using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part101_DSA.ArraysAndHash
{
    public class ArraysAndHash
    {
        #region 1. Contain Duplicate
        public class ContainDuplicate
        {

            public static bool Use2Loop(int[] nums) // not good solution
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] == nums[j]) return true;

                    }
                }
                return false;
            }

            public static bool SortAndLoop(int[] nums)
            {
                Array.Sort(nums);
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    if (nums[i] == nums[i + 1]) return true;
                }

                return false;
            }

            public static bool UsingHashSet(int[] nums)
            => new HashSet<int>(nums).Count < nums.Length;

            public static void MainContainDuplicated()
            {
                List<int[]> ints = new List<int[]>
                {
                    new int[] { 1, 2, 3, 1 },
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 1, 2, 3, 1, 1, 1, 2,2 ,3, 4 },
                };

                foreach (var item in ints)
                {
                    Console.WriteLine($"Use2Loop : {Use2Loop(item)}");
                    Console.WriteLine($"SortAndLoop : {SortAndLoop(item)}");
                    Console.WriteLine($"UsingHashSet : {UsingHashSet(item)}");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }

        public class ContainsNearbyDuplicate // 2. Contains Duplicate II
        {
            public static bool UseSlidingWindow(int[] nums, int k)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    int j = i + 1;
                    while (j < nums.Length && Math.Abs(i - j) <= k)
                    {
                        if (nums[i] == nums[j])
                        {
                            return true;
                        }
                        j++;
                    }
                }
                return false;
            }

            //Runtime  Memory
            //10  ms   71.38 MB
            //Beats
            //99.41%   21.77%
            public static bool UseDictionary(int[] nums, int k)
            {
                Dictionary<int, int> map = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (map.ContainsKey(nums[i]) && Math.Abs(map[nums[i]] - i) <= k)
                    {
                        return true;
                    }
                    map[nums[i]] = i;
                }
                return false;
            }

            public static bool UseHashSet(int[] nums, int k)
            {
                HashSet<int> set = new();
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (set.Contains(nums[i])) return true;
                    set.Add(nums[i]);
                    if (set.Count > k)
                    {
                        set.Remove(nums[i - k]);
                    }
                }
                return false;


            }


            public static void MainContainsNearbyDuplicate()
            {
                List<(int[], int)> ints = new List<(int[], int)>
                {
                    (new int[] { 1,2,3,1 }, 3),
                    (new int[] { 1,0,1,1 }, 1),
                    (new int[] {1,2,3,1,2,3}, 2),
                };

                var s = new HashSet<char>("racecar").ToArray();
                var t = new HashSet<char>("carrace").ToArray();

                Array.Sort(s);
                Array.Sort(t);

                var newS = new string(s);
                var newT = new string(t);

                var result = newS == newT;

                s = new HashSet<char>("jar").ToArray();
                t = new HashSet<char>("jam").ToArray();

                newS = new string(s);
                newT = new string(t);

                result = newS == newT;


                foreach (var item in ints)
                {
                    Console.WriteLine($"UseSlidingWindow : {UseSlidingWindow(item.Item1, item.Item2)}");
                    Console.WriteLine($"UseDictionary : {UseDictionary(item.Item1, item.Item2)}");
                    Console.WriteLine($"UseHashSet : {UseHashSet(item.Item1, item.Item2)}");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }


        public class TwoStringIsAnagram()
        {
            public static bool SortArray(string s, string t)
            {
                if (s.Length != t.Length) return false;
                var sArray = s.ToCharArray();
                var tArray = t.ToCharArray();
                Array.Sort(sArray);
                Array.Sort(tArray);
                return new string(sArray) == new string(tArray);
            }


            public static bool OnlyOneArrayBest(string s, string t)
            {
                if (s.Length != t.Length) return false;

                int[] result = new int[26];
                for (int i = 0; i < s.Length; i++)
                {
                    result[s[i] - 'a']++;
                    result[t[i] - 'a']--;
                }

                for (int i = 0; i < 26; i++)
                {
                    if (result[i] != 0) return false;
                }
                return true;
            }

            public static bool TwoArrayAndCalculateByCharacter(string s, string t)
            {
                if (s.Length != t.Length)
                    return false;

                int[] sFreq = new int[26];
                int[] tFreq = new int[26];

                foreach (char c in s)
                    sFreq[c - 'a']++;

                foreach (char c in t)
                    tFreq[c - 'a']++;

                for (int i = 0; i < 26; i++)
                {
                    if (sFreq[i] != tFreq[i])
                        return false;
                }
                return true;
            }

            public static bool TwoDictionary(string s, string t)
            {
                if (s.Length != t.Length)
                {
                    return false;
                }

                Dictionary<char, int> freqS = new();
                Dictionary<char, int> freqT = new();

                foreach (char c in s)
                {
                    if (freqS.ContainsKey(c))
                    {
                        freqS[c]++;
                    }
                    else
                    {
                        freqS.Add(c, 1);
                    }
                }
                foreach (char c in t)
                {
                    if (freqT.ContainsKey(c))
                    {
                        freqT[c]++;
                    }
                    else
                    {
                        freqT.Add(c, 1);
                    }
                }


                foreach (char key in freqS.Keys)
                {
                    if (freqT.ContainsKey(key))
                    {
                        if (freqS[key] != freqT[key])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                
                return true;
            }

            public static void MainTwoStringIsAnagram()
            {
                List<(string, string)> strings = new List<(string, string)>
                {
                    ("anagram", "nagaram"),
                    ("rat", "car"),
                    ("jar", "jam"),
                };
                foreach (var item in strings)
                {
                    Console.WriteLine($"SortArray : {SortArray(item.Item1, item.Item2)}"); 
                    Console.WriteLine($"TwoArrayAndCalculateByCharacter : {TwoArrayAndCalculateByCharacter(item.Item1, item.Item2)}");
                    Console.WriteLine($"TwoDictionary : {TwoDictionary(item.Item1, item.Item2)}");
                    Console.WriteLine($"OnlyOneArrayBest : {OnlyOneArrayBest(item.Item1, item.Item2)}");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            #endregion
        }
    }
}
