using System;
using CodingInterviewPrep.StacksAndQueues;
namespace CodingInterviewPrep.DPandRec {
  public class DynamicProgramming {
    
    //Prob: Given n steps return a count of how many diferent ways there are to climp the steps if you can take 1 , 2 or 3 steps at a time.
    //Example: 
    //        1 - step: = [1]
    //        2 - step: = [1,1], [2]
    //        3 - steps = [1,1,1], [2,1], [1,2], [3]
    //        4 - steps = [1,1,1,1], [2,1,1], [1,1,2], [2,2], [1,2,1], [3,1], [1,3]
    //        
    //        countSteps(n) = countSteps(n-1) + countSteps(n-2) + countSteps(n-3)
    public static int TripleStep(int  n) {
      return countSteps(n);
    }

    public static int TripleStepWithDP(int  n) {
      int[] memo = new int[n+1];
      for (int i = 0; i <= n; i ++) {
        memo[i] = -1;
      }
      return countStepsOptimized(n, memo);
    }

    // Run-time of O(3^N) isnt great, O(3^N) additional space
    private static int countSteps(int n) {
      // base case:
      if (n < 0) {
        return 0;
      } else if (n == 0) {
        return 1;
      } else {
        // recursive case:
        return countSteps(n-1) + countSteps(n-2) + countSteps(n-3);
      }
    }
    
    // What do we want to optimize? Memory or CPU?
    // Run-time: O(N) - Memory: O(N)
    private static int countStepsOptimized(int n, int[] cache) {
      // base case:
      if (n < 0) {
        return 0;
      } else if (n == 0) {
        return 1;
      } else {
        // recursive case:
        if (cache[n] == -1) {
          cache[n] = countStepsOptimized(n-1, cache) + countStepsOptimized(n-2, cache) + countStepsOptimized(n-3, cache);
        } 
        return cache[n];
      }
    }

    // Run-time O(n), memory O(1)
    public static int TripleStepSmart(int n) {
      int result = 0;
      int a = 1;
      int b = 1;
      int c = 2;
      
      if (n == 0 || n == 1) {
        return a;
      } else if (n == 2) {
        return c;
      } else {
        for (int i = 3; i <= n; i++) {
          result = a + b + c;
          a = b;
          b = c; 
          c = result;
        }
        return result;
      }
    }

    public static void Test_TripleStep() {
      int[] testInput = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      int[] expectedResults = { 1, 1, 2, 4, 7, 13, 24, 44, 81, 149, 274 };
      Console.WriteLine("Starting triple step test with naive algorithm");

      for(int i = 0; i < testInput.Length; i++) {
        Console.WriteLine("# of steps: " + testInput[i] + ", Expected: " + expectedResults[i] + ", Actual: " + TripleStep(testInput[i]));
      }

      Console.WriteLine("Starting triple step test with an optimized aplogrithm (using DP)");

      for(int i = 0; i < testInput.Length; i++) {
        Console.WriteLine("# of steps: " + testInput[i] + ", Expected: " + expectedResults[i] + ", Actual: " + TripleStepWithDP(testInput[i]));
      }

      Console.WriteLine("Starting triple step test with an optimized aplogrithm (Smart way)");

      for(int i = 0; i < testInput.Length; i++) {
        Console.WriteLine("# of steps: " + testInput[i] + ", Expected: " + expectedResults[i] + ", Actual: " + TripleStepSmart(testInput[i]));
      }
    }


    public static void Test_TowerOfHanoi() {
      Stack<int> s1 = new Stack<int>();
      Stack<int> s2 = new Stack<int>();
      Stack<int> s3 = new Stack<int>();
      
      //s1.push(5);
      //s1.push(4);
      s1.push(3);
      s1.push(2);
      s1.push(1);
      Console.WriteLine("+++ Original s1 +++");
      s1.print();
      Console.WriteLine("=== Starting Tower of Hanoi ===");
      SolveTowerOfHanoi(s1, s2, s3);
      Console.WriteLine("=== s1 ===");
      s1.print();
      Console.WriteLine("=== s2 ===");
      s2.print();
    }

    public static void SolveTowerOfHanoi(Stack<int> s1, Stack<int> s2, Stack<int> s3) {
      int numMoves = 0;
      while (!s1.isEmpty() || !s2.isEmpty()) {
        numMoves++;
        int n3 = s3.peek();
        int n2 = s2.peek();
        int n1 = s1.peek();
        Console.WriteLine("Move # " + numMoves + " ||| n1: " + n1 + ", n2: " + n2 + ", n3: " + n3);
        if (n1 < n3 || n3 == 0) {
          Console.WriteLine("Case #1");
          s1.pop();
          s3.push(n1);
        } else if (n2 < n3 && n2 != 0) {
          Console.WriteLine("Case #2");
          s2.pop();
          s3.push(n2);
        } else if (n1 < n2 || n2 == 0) {
          Console.WriteLine("Case #3");
          s1.pop();
          s2.push(n1);
        } else {
          Console.WriteLine("Case #4");
          s3.pop();
          s2.push(n3);
        }
        
      }

      Console.WriteLine("=== Solved (in " + numMoves + " moves) ====");
      s3.print();
    }
  }
}