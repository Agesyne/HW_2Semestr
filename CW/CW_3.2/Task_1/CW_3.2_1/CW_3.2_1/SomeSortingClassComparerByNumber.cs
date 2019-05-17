using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class SomeSortingClassComparerByNumber : IComparer<SomeSortingClass>
    {
        public int Compare(SomeSortingClass a, SomeSortingClass b)
        {
            return String.Compare(a.Number, b.Number);
        }
    }
}
