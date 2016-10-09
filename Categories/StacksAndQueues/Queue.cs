using System;
namespace CodingInterviewPrep.StacksAndQueues {
  public class Queue<T> {
    private class QueueNode<T> {
      public T data;
      public QueueNode<T> next;

      public QueueNode(T data) {
        this.data = data;
        this.next = null;
      }
    }

    private QueueNode<T> first;
    private QueueNode<T> last;

    public void enqueue(T data) {
      QueueNode<T> newNode = new QueueNode<T>(data);

      if (isEmpty()) {
        first = newNode;
      } else {
        last.next = newNode;
      }
      last = newNode;
    }

    public T dequeue() {
      if (isEmpty()) {
        return default(T);
      }
      T data = first.data;
      first = first.next;
      
      if (isEmpty()) {
        last = first;
      }

      return data;
    }

    public T peek() {
      return !isEmpty() ? first.data : default(T);
    }

    public bool isEmpty() {
      return (first == null);
    }
  }
}