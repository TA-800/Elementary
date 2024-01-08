using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary.MVVM.Models
{
    public class Element
    {
        public string Name { get; }
        public string Symbol { get; }
        public int AtomicNumber { get; }
        public double AtomicMass { get; }

        public Element(string name, string symbol, int atomicNumber, double atomicMass)
        {
            Name = name;
            Symbol = symbol;
            AtomicNumber = atomicNumber;
            AtomicMass = atomicMass;
        }
    }
}
