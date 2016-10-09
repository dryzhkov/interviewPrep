using System;
using CodingInterviewPrep.StacksAndQueues;

namespace CodingInterviewPrep.TreesAndGraphs {
  public class BinaryTreeNode {
    public int data;
    public BinaryTreeNode left;
    public BinaryTreeNode right;

    public BinaryTreeNode(int data): this(data, null, null) {}

    public BinaryTreeNode(int data, BinaryTreeNode left, BinaryTreeNode right) {
      this.data = data;
      this.left = left;
      this.right = right;
    }
  }

  public class BinaryTree {
    public BinaryTreeNode root;

    public BinaryTree() {  
    }

    public BinaryTree(int data) {
      this.root = new BinaryTreeNode(data);
      this.root.data = data;
    }

    public void add(int data) {
      if (this.root == null) {
        this.root = new BinaryTreeNode(data);
        return;
      }

      Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();
      queue.enqueue(this.root);

      while(!queue.isEmpty()) {
        BinaryTreeNode node = queue.dequeue();

        if (node.left == null) {
          node.left = new BinaryTreeNode(data);
          return;
        } else if (node.right == null) {
          node.right = new BinaryTreeNode(data);
          return;
        } else {
          queue.enqueue(node.left);
          queue.enqueue(node.right);
        }
      }
    }

    public void traverse(int order) {
      switch (order) {
        case 1:
          this.inOrderTraversal(this.root);
          break;
        case 2:
          this.postOrderTraversal(this.root);
          break;
        default:
          this.preOrderTraversal(this.root);
          break;
      }
      Console.WriteLine();
    }

    private void preOrderTraversal(BinaryTreeNode node) {
      if (node != null) {
        Console.Write(node.data + " -> ");
        preOrderTraversal(node.left);
        preOrderTraversal(node.right);
      }
    }

    private void inOrderTraversal(BinaryTreeNode node) {
      if (node != null) {
        inOrderTraversal(node.left);
        Console.Write(node.data + " -> ");
        inOrderTraversal(node.right);
      }
    }
    private void postOrderTraversal(BinaryTreeNode node) {
      if (node != null) {
        postOrderTraversal(node.left);
        postOrderTraversal(node.right);
        Console.Write(node.data + " -> ");
      }
    }

    public BinaryTreeNode DFS(BinaryTreeNode cur, BinaryTreeNode target) {
      if (cur == null) {
        return null;
      }

      if (cur.data == target.data) {
        return cur;
      }

      BinaryTreeNode leftRes = DFS(cur.left, target);
      BinaryTreeNode rightRes = DFS(cur.right, target);

      if (leftRes != null) {
        return leftRes;
      } else if (rightRes != null) {
        return rightRes;
      } else {
        return null;
      }
    }

    public bool isValidBST(BinaryTreeNode root) {
      bool isValid = true;
      isValidSubTree(root, ref isValid);
      return isValid;
    }

    public void isValidSubTree(BinaryTreeNode node, ref bool valid) {
      if (node == null) {
        return;
      }

      if (node.left != null && node.left.data > node.data) {
        valid = false;
      } else if (node.right != null && node.right.data <= node.data) {
        valid = false;
      } else {
        isValidSubTree(node.left, ref valid);
        isValidSubTree(node.right, ref valid);
      }
    }
  }
}