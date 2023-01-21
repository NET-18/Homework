using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork21._11._2022
{
    internal class MyList<T> : IEnumerable<T>, IComparable
    {
        public T[] data;
        public int capasity;
        public int size;

        public MyList()
        {
            capasity = 0;
            size = 0;
            data = new T[capasity];
        }
        public MyList(T[] data)
        {
            this.data = data;
            this.size = data.Length;
            this.capasity = size;

        }


        public void Add(T item)
        {
            if (capasity == size)
            {
                var resized = new T[capasity * 2];
                for (int i = 0; i < size; i++)
                {
                    resized[i] = data[i];
                }
                data = resized;
                capasity *= 2;

            }
            if (capasity < size)
            {
                throw new ArgumentException();
            }
            if (capasity > size)
            {
                data[size++] = item;
            }
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
            => new MyEnumerator<T>(data);

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        internal class MyEnumerator<T> : IEnumerator<T>
        {
            public T[] data;
            public int index = -1;
            public MyEnumerator(T[] data)
            {
                this.data = data;
            }
            object IEnumerator.Current => Current;
            public T Current
            {
                get
                {
                    if (index == -1 || index >= data.Length)
                    {
                        throw new ArgumentException();
                    }

                    return data[index];
                }
            }
            public bool MoveNext()
            {
                if (index < data.Length -1)
                {
                    index++;
                    return true;
                }

                return false;
            }

            public void Reset() => index = -1;
           
            public void Dispose()
            {
                
            } 
        }
    }
}
