using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincetonAlgorithmsInCShar
{
    class LeftLeaningRedBlackTree
    {
        private Node root;
        private const bool RED = true;
        private const bool BLACK = false;

        public class Node
        {
            internal int key, value;
            internal Node left, right;
            internal bool color;

            public Node(int key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public void Put(int key, int value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node x, int key, int value)
        {
            if (x == null)
                return new Node(key, value);

            if (x.key > key)
                x.left = Put(x.left, key, value);
            else if (x.key < key)
                x.right = Put(x.right, key, value);
            else
                x.value = value;

            return x;
        }

        public int? Get(int key)
        {
            Node x = root;
            while (x != null)
            {
                if (x.key > key)
                    x = x.left;
                else if (x.key < key)
                    x = x.right;
                else
                    return x.value;
            }
            return null;
        }

        public IEnumerable<int> keys()
        {
            Queue<int> q = new Queue<int>();
            InorderTravaseral(root, q);
            return q.ToArray();
        }

        private void InorderTravaseral(Node x, Queue<int> q)
        {
            if (x == null) return;
            InorderTravaseral(x.left, q);
            q.Enqueue(x.key);
            InorderTravaseral(x.right, q);
        }

        public void Delete(int key)
        {
            root = Delete(root, key);
        }

        private Node Delete(Node x, int key)
        {
            if (x == null) return null;

            if (x.key > key) x.left = Delete(x.left, key);
            else if (x.key < key) x.right = Delete(x.right, key);
            else
            {
                if (x.left == null) return x.right;
                if (x.right == null) return x.left;

                Node t = x;
                x = Min(t.right);
                DeleteMin(t.right);
                x.right = t.right;
                x.left = t.left;
            }
            return x;
        }

        private Node DeleteMin(Node x)
        {
            if (x.left == null) return x.right;
            x.left = DeleteMin(x.left);
            return x;
        }

        private Node Min(Node node)
        {
            Node x = node;
            while (x.left != null)
            {
                x = x.left;
            }
            return x;
        }

        private bool isRed(Node x)
        {
            if (x == null) return false;
            return x.color == RED;
        }

        private Node RotateLeft(Node x)
        {
            Node h = x.right;
            h.left = x;
            x.right = h.left;
            x.color = h.color;
            h.color = RED;
            return h;
        }

        private Node RotateRight(Node x)
        {
            Node h = x.left;
            h.right = x;
            x.left = h.right;
            h.color = x.color;
            x.color = RED;
            return h;
        }

        private void ColorFlip(Node x)
        {
            x.color = RED;
            x.left.color = BLACK;
            x.right.color = BLACK;
        }
    }
}
