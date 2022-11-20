using System.Collections;

namespace ConsoleApp4
{
    internal class MyCollection : IEnumerable<int>
    {
        private int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        public IEnumerator<int> GetEnumerator() 
            => new MyEnumerator(data);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class MyEnumerator : IEnumerator<int>
        {
            private readonly int[] data;
            private int index = -1;

            public object Current
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

            object IEnumerator.Current => this.Current;

            public MyEnumerator(int[] data)
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
