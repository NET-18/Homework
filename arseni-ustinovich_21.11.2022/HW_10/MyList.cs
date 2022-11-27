using System;
using System.Collections;
using System.Drawing;

namespace HW_10
{
    internal class MyList<T> : IList<T>
    {
        private T[] _data;
        private int _size;
        private int _capacity;
        private int _addCapacity = 1;

        public int Count => _size;

        public bool IsReadOnly => false;

        public T this[int index] 
        {
            get 
            { 
                if (index < 0 || index >= _size)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                
                return _data[index];
            }
            set 
            {
                if (index < 0 || index >= _size)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                
                _data[index] = value;    
            } 
        }
        public MyList()
        {
            _data = new T[0];
        }

        public MyList(int size)
        {
            _size = size;
            _capacity = size;
            _data= new T[size];
        }

        public MyList(T[] data)
        {
            _data = data;
            _size = data.Length;
            _capacity = data.Length;
        }

        public void Add(T item)
        {
            if (_size == _capacity)
            {
                IncreaseList(1);
            }

            _data[_size++] = item;
        }
        
        public void Add(T[] items)
        {
            int extraSize = items.Length;

            if (_size + extraSize > _capacity)
            {
                IncreaseList(extraSize);
            }

            Array.Copy(items, 0, _data, _size, extraSize);
            _size += extraSize;
        }

        public void Insert(int index, T item)
        {
            if (_size == _capacity)
            {
                IncreaseList(1);
            }

            Array.Copy(_data, index, _data, index + 1, _size - index);
            _data[index] = item;
            _size++;

        }
       
        public void Insert(int index, T[] items)
        {
            int extraSize = items.Length;
            if (_size + extraSize > _capacity)
            {
                IncreaseList(extraSize);
            }

            Array.Copy(_data, index, _data, index + extraSize, _size - index);
            Array.Copy(items, 0, _data, index, extraSize);
            _size += extraSize;

        }

        public void RemoveAt(int index)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                Array.Copy(_data, index + 1, _data, index, _size - index - 1);
                _size--;
            }
        }

        public void Clear()
        {
            Array.Clear(_data, 0, _capacity);
            _size = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        private void IncreaseList(int extraSize)
        {
            
            while (_addCapacity < extraSize)
            {
                _addCapacity *= 2;
            }
            
            _capacity = _size + _addCapacity;
            
            T[] data = new T[_capacity];
            Array.Copy(_data, 0, data, 0, _size);
            _data = data;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_data, item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(_data, _size);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        private class MyEnumerator : IEnumerator
        {
            private readonly T[] _data;
            private readonly int _size;
            private int index = -1;

            public MyEnumerator(T[] data, int size)
            {
                _data = data;
                _size = size;
            }

            public T Current
            {
                get
                {
                    if (index == -1 || index >= _size)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return _data[index];
                }
            }

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                if (index < _size - 1)
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
        }
    }
}
