using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Element
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
        public Element(Element other)
        {
            this.name = other.name;
            this.averageMark = other.averageMark;
            this.dancing = other.dancing;
        }
    }
}
