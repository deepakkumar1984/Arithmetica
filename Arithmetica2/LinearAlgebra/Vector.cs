using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Arithmetica.LinearAlgebra
{
    public abstract class Vector<T> : IList<T>, IFormattable
    {
        internal List<T> variable = new List<T>();

        internal bool IsDirty = false;

        public T this[int index] {
            get
            {
                return variable[index];
            }
            set
            {
                variable[index] = value;
                IsDirty = true;
            }
        }

        public int Count => variable.Count;

        public bool IsReadOnly => false;

        public long DimLength;

        internal ArithArray arithArray = null;

        public Vector(int dim_length)
        {
            DimLength = dim_length;
            IsDirty = true;
        }

        public void Add(T item)
        {
            variable.Add(item);
            IsDirty = true;
        }

        public void Clear()
        {
            variable.Clear();
            IsDirty = true;
        }

        public bool Contains(T item)
        {
            return variable.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            variable.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return variable.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return variable.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            variable.Insert(index, item);
            IsDirty = true;
        }

        public bool Remove(T item)
        {
            IsDirty = true;
            return variable.Remove(item);
        }

        public void RemoveAt(int index)
        {
            variable.RemoveAt(index);
            IsDirty = true;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return "Vector: " + (typeof(T).Name);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return variable.GetEnumerator();
        }

        public T[] Array
        {
            get
            {
                return variable.ToArray();
            }
        }

        public virtual ArithArray V
        {
            get
            {
                return arithArray;
            }
        }
    }
}
