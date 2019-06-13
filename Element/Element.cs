using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element
{
    public class Element
    {
        public string name { get; set; }
        public double averageMark { get; set; }
        public bool dancing { get; set; }

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
