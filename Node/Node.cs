using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Node
{
    public class Node
    {
        internal Element element;
        public Node next { get; set; }
        public Node prev { get; set; }

        public Node() { }
        public Node(Element el)
        {
            element = el;
        }
        public Node(string _name, double _average, bool _dancing)
        {
            element = new Element(_name, _average, _dancing);
        }
        public Node(Node other) : this(other.element)
        {
        }
    }
}
