using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLib
{
    public class DoubleLinkedList : IEnumerable
    {
        private Node head;//first element
        private Node tail;//last element

        public DoubleLinkedList()
        {
            tail = head;
            Length = 0;
        }
        public DoubleLinkedList(DoubleLinkedList other)
            : this()
        {
            head = other.head;
            tail = other.tail;
            Length = other.Length;
        }

        public int Length { get; protected set; }

        public IEnumerator GetEnumerator()
        {
            return new DoubleLinkedListEnumerator(this);
        }
        /// <summary>
        /// Adds node to the end of the list
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_average"></param>
        /// <param name="_dancing"></param>
        public void Add(string _name, double _average, bool _dancing)
        {
            Add(Length, new Node(_name, _average, _dancing));
        }
        /// <summary>
        /// Adds node to the specified position
        /// </summary>
        /// <param name="index"></param>
        /// <param name="_name"></param>
        /// <param name="_average"></param>
        /// <param name="_dancing"></param>
        public void Add(int index, string _name, double _average, bool _dancing)
        {
            Add(index, new Node(_name, _average, _dancing));
        }
        /// <summary>
        /// Adds node to the specified position
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newNode"></param>
        internal void Add(int index, Node newNode)
        {
            if (Length < index)
                throw new IndexOutOfRangeException("Index is out of range");

            if (Length == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else if (index == 0)
            {
                var curr = head;
                head = newNode;
                curr.prev = head;
                head.next = curr;
                head.prev = null;
            }
            else if (index == Length)
            {
                tail.next = newNode;
                var oldElem = tail;
                tail = newNode;
                tail.prev = oldElem;
            }
            else
            {
                var left = GetNode(index - 1);
                var right = left.next;
                left.next = newNode;
                newNode.prev = left;
                right.prev = newNode;
                newNode.next = right;
            }
            Length++;
        }
        /// <summary>
        /// Adds node to the 0 position
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_average"></param>
        /// <param name="_dancing"></param>
        public void AddFirst(string _name, double _average, bool _dancing)
        {
            Add(0, _name, _average, _dancing);
        }
        /// <summary>
        /// Adds node to the 0 position
        /// </summary>
        /// <param name="node"></param>
        internal void AddFirst(Node node)
        {
            Add(0, node);
        }

        public void Del(int index)
        {
            if (Length <= index)
                throw new IndexOutOfRangeException("Index is out of range");
            var n = GetNode(index);

            var left = n.prev;
            var rigt = n.next;
            if (left != null)
                left.next = rigt;
            if (rigt != null)
                rigt.prev = left;

            Length--;
            if (Length == 0)
                head = tail = null;
        }

        public DoubleLinkedList NewList()
        {
            var res = new DoubleLinkedList();
            var odd = new List<Element>();
            var even = new List<Element>();
            for (int i = 0; i < Length; i++)
            {
                if (i % 2 == 0)
                    even.Add(this[i]);
                else
                    odd.Add(this[i]);
            }
            for (int i = 0; i < even.Count; i++)
            {
                if (i <= odd.Count - 1)
                    res.Add(odd[i].name, odd[i].averageMark, odd[i].dancing);
                res.Add(even[i].name, even[i].averageMark, even[i].dancing);
            }
            return res;
        }

        internal Node GetNode(int numInList)
        {
            if (Length == 0)
                return new Node("", 0.0, false);
            else if (numInList < 0 || numInList >= Length)
                throw new IndexOutOfRangeException("Index is out of range");
            else
            {
                var current = head;
                for (int i = 0; i < numInList; i++)
                    current = current.next;
                return current;
            }
        }

        /// <summary>
        /// example of indexer
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Element this[int index]
        {
            get
            {
                return GetNode(index).element;
            }
            set
            {
                var s = GetNode(index);
                s.element = value;
            }
        }

        public DoubleLinkedList Search()//returns list of all students with average mark 5 who is practicing dancing
        {
            var d = new DoubleLinkedList();

            int i = 0;
            if (Length != 0)
            {
                foreach (Element item in this)
                {
                    if (item.averageMark == 5 && item.dancing)
                    {
                        d.Add(i, item.name, item.averageMark, item.dancing);
                        i++;
                    }
                }
            }
            else
                throw new Exception("Your list is empty");
            return d;
        }
    }
}
