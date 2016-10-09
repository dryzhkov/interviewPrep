using System;
namespace CodingInterviewPrep.StacksAndQueues {
  public class SQProblems {
    // Given a stack such that smallest elements are at the top, 
    // BCR = O()
    // 
    public static void SortStack(Stack<Int32> stack) {
      Stack<int> tempStack = new Stack<int>();
      while (!stack.isEmpty()) {
        int temp = stack.pop();
        
        while (!tempStack.isEmpty() && temp < tempStack.peek()) {
          stack.push(tempStack.pop());
        }
        tempStack.push(temp);
      }

      // copy elements back into stack 1
      while (!tempStack.isEmpty()) {
        stack.push(tempStack.pop());
      }
    }

    public static void SortStack_Test() {
      int[] testData = { 10, 7, 12, 5, 33, 1, 15, 100, 57, 77, 80, 19 };
      Stack<Int32> stack = new Stack<Int32>();
      foreach(int i in testData) {
        stack.push(i);
      }

      Console.WriteLine("Initial stack");
      stack.print();
      Console.WriteLine("Calling sort");
      SortStack(stack);
      Console.WriteLine("Stack after sorting");
      stack.print();
    }
  }
}