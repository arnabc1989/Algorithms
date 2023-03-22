using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BinaryTree
{
    internal class Program
    {
        public class Node
        {
            public Node left;
            public Node right;
            public int data;
        };
        static Node newNode(int key)
        {
            Node node = new Node();
            node.left = node.right = null;
            node.data = key;
            return node;
        }

        static ArrayList list = new ArrayList();
        static void printNodesOneChild(Node root)
        {
            if (root == null)
                return;

            if (root.left != null && root.right == null ||
                root.left == null && root.right != null)
            {
                list.Add(root.data);
            }

            // Traversing the left child
            printNodesOneChild(root.left);

            // Traversing the right child
            printNodesOneChild(root.right);
        }

        static void printSingles(Node node)
        {
            // Base case 
            if (node == null)
                return;
            Queue<Node> q1 = new Queue<Node>();
            q1.Enqueue(node);
            int flag = 0;
            List<int> v = new List<int>();

            // While q1 is not empty
            while (q1.Count != 0)
            {
                Node temp = q1.Peek();
                q1.Dequeue();

                if (temp.left != null &&
                   temp.right == null)
                {
                    flag = 1;
                    v.Add(temp.left.data);
                }

                if (temp.left == null &&
                   temp.right != null)
                {
                    flag = 1;
                    v.Add(temp.right.data);
                }

                if (temp.left != null)
                {
                    q1.Enqueue(temp.left);
                }


                if (temp.right != null)
                {
                    q1.Enqueue(temp.right);
                }
            }
            v.Sort();


            for (int i = 0; i < v.Count; i++)
            {
                Console.Write("No sibling: " + v[i] + " ");
                
            }

            if (v.Count == 0)
            {
                Console.Write("-1");
            }

        }

        public static void Dfs(Node root, Dictionary<int, int> unmap, int depth)
        {
            if (root == null)
            {
                return;
            }

            // Increment the count of nodes at depth in map
            if (unmap.ContainsKey(depth))
            {
                unmap[depth]++;
            }
            else
            {
                unmap.Add(depth, 1);
            }

            Dfs(root.left, unmap, depth + 1);
            Dfs(root.right, unmap, depth + 1);
        }

        public static int MaxNodeLevel(Node root)
        {
            Dictionary<int, int> unmap = new Dictionary<int, int>();
            Dfs(root, unmap, 0);
            int maxx = int.MinValue;
            int result = 0;

            foreach (int i in unmap.Keys)
            {
                if (unmap[i] > maxx)
                {
                    result = i;
                    maxx = unmap[i];
                }
                else if (unmap[i] == maxx)
                {
                    result = Math.Min(result, i);
                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            Node root = newNode(1);
            root.left = newNode(2);
            root.right = newNode(3);
            root.left.left = newNode(4);
            root.right.left = newNode(6);
            root.left.right = newNode(5);
            root.right.right = newNode(7);
            root.left.left.left = newNode(8);
            root.left.left.right = newNode(9);
            root.left.right.right = newNode(10);
            root.right.right.left = newNode(11);
            root.left.left.right.left = newNode(12);
            root.left.left.right.right = newNode(13);
            root.right.right.left.left = newNode(14);

            printNodesOneChild(root);

            printSingles(root);
            
            Console.WriteLine("Level having maximum number of Nodes: " + MaxNodeLevel(root));

            if (list.Count == 0)
                Console.WriteLine(-1);
            else
            {
                foreach (int value in list)
                {
                    Console.WriteLine(value);
                }
            }

        }
    }

}
