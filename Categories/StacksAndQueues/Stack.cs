using System;

namespace CodingInterviewPrep.StacksAndQueues {
  public class Stack<T> {
    private class StackNode<T> {
      public StackNode<T> next;
      public T data;

      public StackNode(T data) {
        this.data = data;
        this.next = null;
      }
    }

    private StackNode<T> top;

    public void push(T data) {
      StackNode<T> newNode = new StackNode<T>(data);
      newNode.next = top;
      top = newNode;
    }

    public T pop() {
      if (top == null) {
        return default(T);
      }

      T data = top.data;
      top = top.next;
      return data;
    }

    public T peek() {
      return (top != null) ? top.data : default(T);
    }

    public bool isEmpty() {
      return top == null;
    }

    public void print() {
      if (this.isEmpty()) {
        Console.WriteLine("Empty Stack");
        return;
      }

      Stack<T> temp = new Stack<T>();
      while (!this.isEmpty()) {
        T cur = this.pop();
        Console.Write(cur);
        temp.push(cur);

        if (top != null) {
          Console.Write(" -> ");
        }
      }

      while (!temp.isEmpty()) {
        this.push(temp.pop());
      }

      Console.WriteLine();
    }
  }
}