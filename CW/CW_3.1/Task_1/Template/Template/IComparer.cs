using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    /// <summary>
    /// Interface for comparing lists
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IComparer<T>
    {
        bool IsGreater(List<T> a, List<T> b);
        bool IsEqual(List<T> a, List<T> b);
    }
}
