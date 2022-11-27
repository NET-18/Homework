using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace ConsoleApp4
{
    internal class MyList <T> : IEnumerable<T>
    {
        private T[] data;
        private T[] datax;
        private int capacity = 1;
        private int size;

        public int Capacity { get => capacity; }
        public int Size { get; }

        public MyList()
        {
            data = new T[capacity];
        }

        public MyList(T[] data)
        {
            this.data = data;
            size = data.Length;
            capacity = size;
        }

        public void Add(T x)
        {
            if (capacity == size)
            {
                capacity *= 2;
                T[] bufferData = new T[capacity];
                for (int i = 0; i < size; i++)
                {
                    bufferData[i] = data[i];
                }
                bufferData[size++] = x;
                data = bufferData;
            }
            else if (capacity < size)
            {
                throw new ArgumentException();
            }
            else
            {
                data[size++] = x;
            }
            datax = new T[size];
            for (int i = 0; i < size; i++)
            {
                datax[i] = data[i];
            }
        }
        public void Clear()
        {
            size = 0;
            T[]bufferData = new T[capacity];
            data = bufferData;
            datax = new T[size];
            for (int i = 0; i < size; i++)
            {
                datax[i] = data[i];
            }
        }

        public void Remove(T i)
        {
           
        }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(datax);
       
        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private class MyEnumerator<T> : System.Collections.Generic.IEnumerator<T>
        {
            private readonly T [] data;
            private int index = -1;
          
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

            object System.Collections.IEnumerator.Current => Current;

            T System.Collections.Generic.IEnumerator<T>.Current => Current;

            public MyEnumerator(T[] data)
            {
                this.data = data;
            }

            public bool MoveNext()
            {
                if (index < data.Length-1)
                {
                    index++;
                    return true;
                }
                else
                { 
                    return false;
                }
            }

            public void Reset()
            {
                index = -1;
            }

            public void Dispose()
            {

            }
        }
    }
}
