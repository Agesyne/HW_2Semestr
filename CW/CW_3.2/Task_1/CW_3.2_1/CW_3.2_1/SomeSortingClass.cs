using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SomeSortingClass
    {
        public int Size { get; }
        public string Name { get; }
        public string Number { get; }

        public SomeSortingClass(int size, string name, string number)
        {
            Size = size;
            Name = name;
            Number = number;
        }

        public override string ToString()
        {
            return $"({Size}; {Name}; {Number})";
        }
    }
}
