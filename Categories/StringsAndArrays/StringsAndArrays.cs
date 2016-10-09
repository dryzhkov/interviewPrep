using System;
using System.Text;

namespace CodingInterviewPrep.SA
{
    public class StringsAndArrays
    {
        // determine if an input string has all unique characters
        // Ex: "abc", "aabbcc", "a", ""
        // Naive method: if valid string, iterate over string size of N for every character if, you find a same character return false
        //               This requires a nested for loop. Const space but run time is O(N^2) <--- NOT BCR
        // BCR for this is O(N) - because you have to inspect every character (N character)
        // Optimal algorithm: 
        //                    - Sort char array (string) ---- Runtime compl O(NlogN)
        //                    - Iterate over new sorted array and return false if you find a pair of same characters  ---- Runtime complex O(N)
        public static bool isUnique(char[] input) 
        {
            // validate inputß
            if (input == null || input.Length == 0) {
              return false;
            } else if (input.Length == 1) {
              return true;
            }
            // step 1: sort array, hopefully in O(NlogN)
            Array.Sort(input);

            //step 2: iterate
            for (int i = 0; i < input.Length - 2; i++) {
              if (input[i] == input[i + 1]) {
                return false;
              }
            }
            return true;
        }

        public static void Test_IsUnique() {
          Console.WriteLine("checking if strings are unique");
          Console.WriteLine("abc " + StringsAndArrays.isUnique("abc".ToCharArray()));
          Console.WriteLine("[emptystring] " + StringsAndArrays.isUnique("".ToCharArray()));
          Console.WriteLine("aabc " + StringsAndArrays.isUnique("aabc".ToCharArray()));
          Console.WriteLine("c " + StringsAndArrays.isUnique("c".ToCharArray()));
          Console.WriteLine("[null value] " + StringsAndArrays.isUnique(null));
        }

        // implement a method to create a simple compressed string using counts of characters,
        // if original string is shorter than the "compressed" one return original string 
        // characters can range [a-zA-Z]
        // Ex: aabcccdddd => a2b1c3d3, a => a, aab => aab
        // Approach 1: BCR O(N) because we clearly have to inspect every character of the string
        //           : Iterate over every char in a string and keep count until it changes,
        //           : use another string (or string builder) to append char and its count
        //           : Finally, compare sizes and return appropriate string.
        //           : Space is O(n), runtime is O(n)
        public static string SimpleCompress(string input) {
          if (input == null || input.Length <= 1) {
            return input;
          }
          
          StringBuilder compressedBuilder = new StringBuilder();
          char prev = ' ';
          int count = 0;
          for (int i = 0; i < input.Length; i++) {
            count++;
            if (i == 0) {
              prev = input[i];
            } else if (!prev.Equals(input[i]) || i == input.Length - 1) {
              prev = input[i];
              compressedBuilder.Append(prev);
              compressedBuilder.Append(count);
              count = 0;
            }
          }

          string compressedRes = compressedBuilder.ToString();

          return (input.Length > compressedRes.Length) ? compressedRes : input;
        }

        public static void SimpleCompress_Test() {
          Console.WriteLine("Starting simple compression test.");
          string[] testData = {"", "a", "aaAA", "aaabbbCCCabc", "ab", "XXXXXXXXXX"};

          foreach(string input in testData) {
            Console.WriteLine(String.Format("input: {0}, output: {1}", input, StringsAndArrays.SimpleCompress(input)));
          }
        }
    }
}