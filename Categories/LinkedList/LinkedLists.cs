using System;

namespace CodingInterviewPrep.LinkedList {
  public class LinkedListProblems {

      // for k > 0 (if k == 1 its the last node, if k == size - first node)
      public static ListNode kthToLast(ListNode head, int k) {
        if (head == null || k < 1) {
          return null;
        }

        ListNode slow = head;
        ListNode fast = head;

        for (int i = 1; i < k; i++) {
          if (fast.next == null) {
            return null;
          }

          fast = fast.next;
        }

        
        while (fast.next != null) {
          fast = fast.next;
          slow = slow.next;
        }

        return slow;
      }

      public static void kthToLast_Test() {
        Console.WriteLine("Setting up kth to last test.");
        int[] testData = {10, 20, 30};
        ListNode head = null;
        foreach(int data in testData) {
          if (head == null) {
            head = new ListNode(data);
          } else {
            head.Append(data);
          }
        }
        head.print();
        
        Console.WriteLine("Printing in reverse.");
        printInReverse(head);

        Console.WriteLine("Starting.");
        ListNode result = LinkedListProblems.kthToLast(head, 1);
        Console.WriteLine(String.Format("actual: {0}, expected: {1}", result.data, 30));
        ListNode result2 = LinkedListProblems.kthToLast(head, 2);
        Console.WriteLine(String.Format("actual: {0}, expected: {1}", result2.data, 20));
        ListNode result3 = LinkedListProblems.kthToLast(head, 3);
        Console.WriteLine(String.Format("actual: {0}, expected: {1}", result3.data, 10));
      }

      public static void printInReverse(ListNode head) {
        if (head == null) {
          Console.Write("Null list");
        }

        printListReveresedHelper(head);

        Console.WriteLine();
      }

      private static void printListReveresedHelper(ListNode cur) {
        if (cur == null) {
          return;
        }

        printListReveresedHelper(cur.next);
        if (cur.next != null) {
          Console.Write(" <- ");
        }
        Console.Write(cur.data);
      }

      public static bool isPalindrome(ListNode head) {
        // find out the size
        if (head == null || head.next == null) {
          return false;
        }

        int size = head.computeSize();

        return isPalindromeHelper(head, size, 0);
      }

      public static bool isPalindromeHelper(ListNode cur, int size, int position) {
        if (size / 2 == position) {

        } else {
          isPalindromeHelper(cur.next, size, 0);

          
        }
        return false;

      }
  }
}