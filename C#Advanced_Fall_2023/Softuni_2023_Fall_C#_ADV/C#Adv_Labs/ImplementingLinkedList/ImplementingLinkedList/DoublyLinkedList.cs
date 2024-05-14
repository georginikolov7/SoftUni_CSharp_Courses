using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                Value = value;
            }

            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

        }
        private ListNode head;
        private ListNode tail;
        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                this.head = this.tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }
            this.Count++;
        }
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                this.tail = this.head = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }
        public void RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            // 1 2
            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PreviousNode = null;
            }
            else
            {
                this.tail = null;
            }
            this.Count--;

        }
        public void RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            this.tail = this.tail.PreviousNode;
            if (this.tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }
            Count--;
        }
        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[this.Count];
            var currentNode = this.head;
            int counter = 0;
            while (currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.NextNode;
                counter++;
            }
            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
