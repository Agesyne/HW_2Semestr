using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericSet
{
    /// <summary>
    /// GenericSet class
    /// </summary>
    public class GenericSet<T> : ISet<T>
    {
        /// <summary>
        /// Internal structure element
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Parent of the Node
            /// </summary>
            public Node Parent { get; set; }

            /// <summary>
            /// Left son of the Node
            /// </summary>
            public Node Left { get; set; }

            /// <summary>
            /// Right son of the Node
            /// </summary>
            public Node Right { get; set; }

            /// <summary>
            /// Value of the Node
            /// </summary>
            public T Value { get; set; }

            /// <summary>
            /// Consructor
            /// </summary>
            public Node(T value, Node parent = null, Node left = null, Node right = null)
            {
                Value = value;
                Parent = parent;
                Left = left;
                Right = right;
            }

        }

        /// <summary>
        /// The comparer for T type elements
        /// </summary>
        private IComparer<T> comparer = null;

        /// <summary>
        /// The root of the tree
        /// </summary>
        private Node root = null;

        /// <summary>
        /// Amount of element in set
        /// </summary>
        public int Count { get; protected set; } = 0;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comparer">The comparer for the T type elements</param>
        public GenericSet(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }


        /// <summary>
        /// Is the ADS read only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Get n'th element by index
        /// </summary>
        /// <param name="index">The index of element</param>
        /// <returns>The value of the element</returns>
        public T this[int index]
        {
            get
            {
                Node result = null;
                int position = 0;
                FindNthElement(ref position, index, ref result);
                return result.Value;
            }
        }

        /// <summary>
        /// Find Node by its value
        /// </summary>
        /// <param name="value">The searching value</param>
        private Node FindPlace(T value)
        {
            Node prev = null;
            var current = root;

            while (current != null)
            {
                if (comparer.Compare(value, current.Value) == 0)
                {
                    return current;
                }
                else
                {
                    prev = current;
                    if (comparer.Compare(value, current.Value) == 1)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
            }

            return prev;
        }


        /// <summary>
        /// Check if the value is in set
        /// </summary>
        /// <param name="value">The checking value</param>
        public bool Contains(T value)
        {
            var current = FindPlace(value);
            return (current != null && comparer.Compare(value, current.Value) == 0) ?  true :  false;
        }

        /// <summary>
        /// Add value to set and return true if it's successfully done
        /// </summary>
        /// <param name="value">The adding value</param>
        public bool Add(T value)
        {
            var current = FindPlace(value);
            if (current == null)
            {
                root = new Node(value, current);
                ++Count;
                return true;
            }

            if (comparer.Compare(value, current.Value) == 0)
            {
                return false;
            }
            else
            {
                if (comparer.Compare(value, current.Value) == 1)
                {
                    current.Right = new Node(value, current);
                }
                else
                {
                    current.Left = new Node(value, current);
                }
                ++Count;
                return true;
            }
        }

        /// <summary>
        /// Add value to set
        /// </summary>
        /// <param name="value">The adding value</param>
        void ICollection<T>.Add(T value)
        {
            var current = FindPlace(value);
            if (current == null)
            {
                root = new Node(value, current);
                ++Count;
                return;
            }

            if (comparer.Compare(value, current.Value) == 1)
            {
                current.Right = new Node(value, current);
                ++Count;
            }
            else if(comparer.Compare(value, current.Value) == -1)
            {
                current.Left = new Node(value, current);
                ++Count;
            }
        }


        /// <summary>
        /// Remove value from set and return true if it's successfully done
        /// </summary>
        /// <param name="value">The removing value</param>
        public bool Remove(T value)
        {
            var current = FindPlace(value);
            if (current != null && comparer.Compare(value, current.Value) == 0)
            {
                if (current.Left == null && current.Right == null)
                {
                    if (current == root)
                    {
                        root = null;
                    }
                    else
                    {
                        if (current.Parent.Left == current)
                        {
                            current.Parent.Left = null;
                        }
                        else
                        {
                            current.Parent.Right = null;
                        }
                    }
                }
                else if (current.Left != null && current.Right == null || current.Left == null && current.Right != null)
                {
                    var subtree = current.Left ?? current.Right;
                    subtree.Parent = current.Parent;
                    if (current == root)
                    {
                        root = subtree;
                    }
                    else
                    {
                        if (current.Parent.Left == current)
                        {
                            current.Parent.Left = subtree;
                        }
                        else
                        {
                            current.Parent.Right = subtree;
                        }
                    }
                }
                else if (current.Left != null && current.Right != null)
                {
                    var successor = current.Right;
                    while (successor.Left != null)
                    {
                        successor = successor.Left;
                    }

                    current.Value = successor.Value;
                    if (successor.Right != null)
                    {
                        successor.Right.Parent = successor.Parent;
                    }
                    successor.Parent.Right = successor.Right;
                }
                --Count;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove all values from set
        /// </summary>
        public void Clear()
        {
            Count = 0;
            root = null;
        }

        /// <summary>
        /// Go throw all set and fill given array in predefined order
        /// </summary>
        /// <param name="current">The current Node</param>
        /// <param name="array">The filling array</param>
        /// <param name="currentIndex">The current filling index in array</param>
        private void GoAround(Node current, T[] array, ref int currentIndex)
        {
            if (current.Left != null)
            {
                GoAround(current.Left, array, ref currentIndex);
            }

            array[currentIndex] = current.Value;
            ++currentIndex;

            if (current.Right != null)
            {
                GoAround(current.Right, array, ref currentIndex);
            }
        }

        /// <summary>
        /// Copy set to array by predefined order
        /// </summary>
        /// <param name="array">The filling array</param>
        /// <param name="startIndex">The index filling to be started</param>
        public void CopyTo(T[] array, int startIndex = 0)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length < startIndex + Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            GoAround(root, array, ref startIndex);
        }


        /// <summary>
        /// Get Node by its index
        /// </summary>
        /// <param name="position">Current set position</param>
        /// <param name="findingPosition">Finding position in set</param>
        /// <param name="result">The searching Node</param>
        /// <param name="current">Current set Node</param>
        private void FindNthElement(ref int position, int findingPosition, ref Node result, Node current = null)
        {
            if (current == null)
            {
                current = root;
            }
            
            if (current.Left != null)
            {
                FindNthElement(ref position, findingPosition, ref result, current.Left);
            }
            

            if (position > findingPosition)
            {
                return;
            }
            else if (position == findingPosition)
            {
                result = current;
            }
            ++position;


            if (current.Right != null)
            {
                FindNthElement(ref position, findingPosition, ref result, current.Right);
            }
        }

        /// <summary>
        /// Add all missing element from other set
        /// </summary>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var i in other)
            {
                if (!Contains(i))
                {
                    Add(i);
                }
            }
        }

        /// <summary>
        /// Remove all element that are off other set
        /// </summary>
        public void IntersectWith(IEnumerable<T> other)
        {
            var setValues = new T[Count];
            CopyTo(setValues);
            foreach (var i in setValues)
            {
                if (!other.Contains(i))
                {
                    Remove(i);
                }
            }
        }

        /// <summary>
        /// Remove all both set consisting element
        /// </summary>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var i in other)
            {
                if (Contains(i))
                {
                    Remove(i);
                }
            }
        }

        /// <summary>
        /// Add missing elements and remove both consting ones
        /// </summary>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            var setValues = new T[Count];
            CopyTo(setValues);

            var tempSet = new GenericSet<T>(comparer);
            foreach (var i in setValues)
            {
                if (other.Contains(i))
                {
                    Remove(i);
                    tempSet.Add(i);
                }
            }

            foreach (var i in other)
            {
                if (!Contains(i) && !tempSet.Contains(i))
                {
                    Add(i);
                }
            }
        }


        /// <summary>
        /// Is the set subset of other set
        /// </summary>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            foreach (var i in this)
            {
                if (!other.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Is the set superset of other set
        /// </summary>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            foreach (var i in other)
            {
                if (!Contains(i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Is the set proper superset of other set
        /// </summary>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return IsSupersetOf(other) && Count > other.Count();
        }

        /// <summary>
        /// Is the set proper subset of other set
        /// </summary>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return IsSubsetOf(other) && Count < other.Count();
        }


        /// <summary>
        /// Do sets have any same values
        /// </summary>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (Count < other.Count())
            {
                foreach (var i in this)
                {
                    if (other.Contains(i))
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var i in other)
                {
                    if (Contains(i))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Check if sets are equal
        /// </summary>
        public bool SetEquals(IEnumerable<T> other)
        {
            foreach (var i in this)
            {
                if (!other.Contains(i))
                {
                    return false;
                }
            }
            return Count == other.Count();
        }


        /// <summary>
        /// Let use foreach with the ADS
        /// </summary>
        public IEnumerator<T> GetEnumerator() => new GenericSetIEnumerator<T>(this);

        /// <summary>
        /// Let use foreach with the ADS
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => new GenericSetIEnumerator<T>(this);

    }
}
