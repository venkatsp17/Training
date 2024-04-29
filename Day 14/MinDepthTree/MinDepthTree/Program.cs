using System;

namespace MinDepthTree
{
    //Class Tree Node
    public class Node
    {
        int value;
        public Node leftNode;
        public Node rightNode;
        public Node(int x) => value = x;
    }
    public class Program
    {
        //Function to Minimum Depth
        int FindMinimumDepth(Node root)
        {
            if (root == null) return 0;

            if (root.leftNode == null && root.rightNode == null)
            {
                return 1;
            }

            int depth = Int32.MaxValue;
            if (root.leftNode != null)
            {
                depth = Math.Min(depth, FindMinimumDepth(root.leftNode));
            }
            if (root.rightNode != null)
            {
                depth = Math.Min(depth, FindMinimumDepth(root.rightNode));
            }

            return depth + 1;
        }

        //Function to Create Tree
        static Node CreateTree(int[] numbers, int index)
        {
            if (index >= numbers.Length || numbers[index] == -1)
            {
                return null;
            }

            Node node = new Node(numbers[index]);
            node.leftNode = CreateTree(numbers, 2 * index + 1);
            node.rightNode = CreateTree(numbers, 2 * index + 2);

            return node;
        }

        //Main Function
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5}; 
            Node root = CreateTree(numbers, 0);

            Program program = new Program();
            Console.WriteLine("The Min Depth of Tree is: " + program.FindMinimumDepth(root));
        }

       
    }
}
