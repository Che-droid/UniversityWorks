using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLib
{
    [DebuggerDisplay("{name}")]
    public class Element//information about student
    {
        public string name;
        public double averageMark;
        public bool dancing;

        public Element() { }
        public Element(string _name, double _average, bool _dancing)
        {
            name = _name;
            averageMark = _average;
            dancing = _dancing;
        }
        public Element(Element other)//copy constructor
        {
            this.name = other.name;
            this.averageMark = other.averageMark;
            this.dancing = other.dancing;
        }
    }

    [DebuggerDisplay("{element.name}")]
    internal class Node
    {
        internal Element element;
        public Node next;
        public Node prev;

        public Node() { }
        public Node(Element el)
        {
            element = el;
        }
        public Node(string _name, double _average, bool _dancing)
        {
            element = new Element(_name, _average, _dancing);
        }
        public Node(Node other) : this(other.element)//copy constructor
        {
        }
    }
}
