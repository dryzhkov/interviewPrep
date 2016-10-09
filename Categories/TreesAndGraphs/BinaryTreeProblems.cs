using System; 

namespace CodingInterviewPrep.TreesAndGraphs {
  public class BinaryTreeProblems {
    public static void Test_BinaryTreeInit() {
      Console.WriteLine("Setting up binary tree");
      int[] testData = { 1,2,3,4,5,6,7 };

      BinaryTree bTree = new BinaryTree(testData[0]);

      for(int i = 1; i < testData.Length; i++) {
        Console.WriteLine("Adding " + testData[i] + " to the tree");
        bTree.add(testData[i]);
      }

      Console.WriteLine("Pre order traversal");
      bTree.traverse(0);

      Console.WriteLine("In order traversal");
      bTree.traverse(1);

      Console.WriteLine("Post order traversal");
      bTree.traverse(2);
    }

    public BinaryTree CreateMinimalTree(int[] array) {
      int size = array.Length;
      BinaryTree tree = new BinaryTree();
      tree.root = CreateMinimalTreeHelper(array, 0, size - 1);
      return tree;
    }

    private BinaryTreeNode CreateMinimalTreeHelper(int[] array, int left, int right) {
      if (right < left) {
        return null;
      }
      int mid = (right + left) / 2;
      BinaryTreeNode node = new BinaryTreeNode(array[mid]);
      node.left = CreateMinimalTreeHelper(array, left, mid - 1);
      node.right = CreateMinimalTreeHelper(array, mid + 1, right);
      return node;
    }

    public static void Test_CreateMinimalTree() {
      Console.WriteLine("Creating minimal tree test");
      int[] testData = { 1,2,3,4,5,6,7 };
      BinaryTreeProblems btp = new BinaryTreeProblems();

      BinaryTree tree = btp.CreateMinimalTree(testData);

      Console.Write("Result in pre-order");
      tree.traverse(0);
    }
  }
}