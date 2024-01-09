using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary.MVVM.Models
{
    public class Element
    {
        // Make sure the names of the properties match the names of the JSON keys (case-insensitive)
        public string Name { get; }
        public string Symbol { get; }
        public int Number { get; }
        public double Atomic_Mass { get; }
        public int Group { get; }
        public int Period { get; }
        public string Block { get; }
        public string Electron_Configuration { get; }
        public string Category { get; }
        public string Summary { get;  }

        public Element(string name, string symbol, int number, double atomic_mass, int group, int period, string block, string electron_configuration, string category, string summary)
        {
            Name = name;
            Symbol = symbol;
            Number = number;
            Atomic_Mass = atomic_mass;
            Group = group;
            Period = period;
            Block = block;
            Electron_Configuration = electron_configuration;
            Category = category;
            Summary = summary;
        }


    }
}
