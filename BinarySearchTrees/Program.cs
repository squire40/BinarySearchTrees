using System;
class Node
{
    public Node left, right;
    public int data;
    public Node(int data)
    {
        this.data = data;
        left = right = null;
    }
}
class Solution {
    static int _height;
    static int getHeight(Node root)
    {
        //Write your code here
        Node node = null;
        do
        {
            node = CrawlTreeRecursive(node, _height);
        } while (node != null);
        return _height;
    }
    static Node CrawlTreeRecursive(Node node, int height)
    {
        if (node == null)
        {
            return null;
        }
        if (node.left != null || node.right != null)
        {
            if (height <= _height)
            {
                _height++;
                return CrawlTreeRecursive(node.left ?? node.right ?? null, _height);
            }
        }
        return node;
    }
    static Node insert(Node root, int data)
    {
        if (root == null)
        {
            return new Node(data);
        }
        else
        {
            Node cur;
            if (data <= root.data)
            {
                cur = insert(root.left, data);
                root.left = cur;
            }
            else
            {
                cur = insert(root.right, data);
                root.right = cur;
            }
            return root;
        }
    }
    static void Main(String[] args)
    {
        Node root = null;
        int T = Int32.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            int data = Int32.Parse(Console.ReadLine());
            root = insert(root, data);
        }
        int height = getHeight(root);
        Console.WriteLine(height);

    }
}