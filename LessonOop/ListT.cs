using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LessonOop
{
    internal class ListT<T>
    {
        private Node root; // Первая нода
        private Node end;  // Последняя нода
        private int size;
        public int Size { get { return size; } }

        public ListT()
        {
            root = null;
            size = 0;
        }

        public void Add(T value)
        {
            if (root == null)
            {
                root = new Node(value);
                end = root;
                size++;
                return;
            }
            end.next = new Node(value);
            end = end.next;
            size++;
        }

        public void RemoveAt(int index)
        {
            if (index! < size || index < 0)
                throw new IndexOutOfRangeException();
            if (index == 0)
            {
                root = root.next;
                size--;
                return;
            }
            Node current = root;
            if (index == size - 1)
            {
                for (int i = 0; i < size - 1; i++)
                    current = current.next;
                current.next = null;
                end = current;
                return;
            }
            current = root;
            for (int i = 0; i < index - 1; i++)
                current = current.next;
            current.next = current.next.next;
            size--;
        }

        public bool Remove(T value)
        {
            Node current = root;
            if (root.value.Equals(value))
            {
                root = root.next;
                size--;
                return true;
            }
            while (current.next != null)
            {
                if (current.next.value.Equals(value))
                {
                    if (current.next == end)
                    {
                        current.next = null;
                        end = current;
                    }
                    else
                        current.next = current.next.next;
                    size--;
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public void RemoveAll(T value)
        {
            while (root.value.Equals(value))
            {
                root = root.next;
                size--;
            }
            Node current = root;
            while (current.next != null)
            {
                if (current.next.value.Equals(value))
                {
                    if (current.next == end)
                        end = current;
                    current.next = current.next.next;
                    size--;
                }
                else
                    current = current.next;
            }
        }

        public void Clear()
        {
            root = null;
            size = 0;
        }

        public void Print()
        {
            Node current = root;
            while (current != null)
            {
                Console.Write($"{current.value} ");
                current = current.next;
            }
            Console.WriteLine($"  Size = {size}");
        }

        private class Node
        {
            public T value;
            public Node next;
            public Node()
            {
                next = null;
            }
            public Node(T value)
            {
                this.value = value;
            }
            public Node(T value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }
    }

}