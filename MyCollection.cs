using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ConsoleApp4
{
    internal class MyList<T> : IEnumerable<T>
    {
        private T[] data;
        private int size;
        private int capacity=1;

        public int Capacity { get => this.capacity; }
        public int Size { get => this.size; }

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
                int i = 0;
                foreach (T item in data)
                {
                    bufferData[i++] = item;
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
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(data);
        }
        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        private class MyEnumerator<T> : System.Collections.Generic.IEnumerator<T>
        {
            private readonly T[] data;
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

            object System.Collections.IEnumerator.Current => this.Current;

            T System.Collections.Generic.IEnumerator<T>.Current => this.Current;

            public MyEnumerator(T[] data)
            {
                this.data = data;
            }
            public bool MoveNext()
            {
                if (index < data.Length - 1)
                {
                    index++;
                    return true;
                }
                return false;
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
