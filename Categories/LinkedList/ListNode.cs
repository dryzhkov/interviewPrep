using System;
namespace CodingInterviewPrep.LinkedList {
  public class ListNode {
    public ListNode next;
    public int data;

    public ListNode(int data) {
      this.data = data;
      this.next = null;
    }

    public void Append(int data) {
      ListNode newLast = new ListNode(data);

      ListNode cur = this;
      while (cur.next != null) {
        cur = cur.next;
      }

      cur.next = newLast;
    }

    public void print() {
      ListNode cur = this;
      while (cur != null) {
        Console.Write(cur.data);
        if (cur.next != null) {
          Console.Write(" -> ");
        }
        cur = cur.next;
      }
      Console.WriteLine();
    }

    public int computeSize() {
      int size = 1;
      ListNode cur = this;
      while (cur.next != null) {
        cur = cur.next;
        size++;
      }
      return size;
    }
  }
}