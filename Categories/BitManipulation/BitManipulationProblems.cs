using System;
namespace CodingInterviewPrep.BitManipulation {
  public class BitManipulationProblems {
    public static void Test_GetBit () {
      Tuple<int, int, bool>[] testData = {
        new Tuple<int, int, bool>(5, 1, false),
        new Tuple<int, int, bool>(5, 2, true),
        new Tuple<int, int, bool>(5, 0, true),
        new Tuple<int, int, bool>(15, 3, true),
      };
      Console.WriteLine("Starting GetBit Test");
      foreach (var data in testData) {
        Console.WriteLine("Num: " + data.Item1 + " Position: " + data.Item2 + " Expected: " + data.Item3 + " Actual: " + BitUtility.getBit(data.Item1, data.Item2));
      }
    }

    public static void Test_SetBit () {
      Tuple<int, int, int>[] testData = {
        new Tuple<int, int, int>(5, 0, 5),
        new Tuple<int, int, int>(5, 1, 7),
        new Tuple<int, int, int>(0, 3, 8),
        new Tuple<int, int, int>(1, 10, 1025),
      };
      Console.WriteLine("Starting SetBit Test");
      foreach (var data in testData) {
        Console.WriteLine(
          "Num: " + data.Item1 + 
          " Position: " + data.Item2 + 
          " Expected: " + data.Item3 + 
          " Actual: " + BitUtility.setBit(data.Item1, data.Item2));
      }
    }
  }
}