using System.Collections;

namespace HomeWorkCollections;

public class MyList<T> : IEnumerable<T>
{
    private int _size = 0;
    private int _capacity = 0;
    private T[] _data;
    
    public int Capacity { get => this._capacity; }
    
    public int Count { get => this._size; }

    public MyList()
    {
        _data = new T[_capacity];
    }

    public MyList(T[] data)
    {
        this._size = data.Length;
        int power = 0, buffer = _size;
        var flag = false;
        
        while (buffer / 2 != 0)
        {
            if (!flag)
            {
                flag = buffer % 2 == 1;
            }

            power++;
            buffer /= 2;
        }

        this._capacity = flag ? (int)Math.Pow(2, power + 1) : (int)Math.Pow(2, power);
        
        this._data = new T[_capacity];
        Clone(this._data, data);
    }

    public MyList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException("Capacity must be non-negative number", nameof(capacity));
        }
        
        this._capacity = capacity;
        this._data = new T[capacity];
    }

    public void Add(T value)
    {
        if (this._capacity == 0)
        {
            this._capacity = 4;
            this._data = new T[_capacity];
        }
        else if (this._size == this._capacity)
        {
            this._capacity *= 2;
            var buffer = this._data;
            this._data = new T[this._capacity];

            Clone(this._data, buffer);
        }

        _size++;
        this._data[_size - 1] = value;
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this._size)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            return this._data[index];
        }
        set
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value),"Value is null.");
            }
            
            if (value is not T)
            {
                throw new ArgumentException("Invalid type.");
            }

            this._data[index] = value;
        }
    }

    public void Clear()
    {
        this._size = 0;
        this._data = new T[this._capacity];
    }

    public bool Remove(T value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value), "Value cannot be null.");
        }
        
        var result = false;
        var index = 0;
        for (var i = 0; i < this._size; i++)
        {
            if (this._data[i].Equals(value))
            {
                result = true;
                index = i;
                break;
            }
        }

        if (!result)
        {
            return result;
        }

        for (var i = index; i < this._size - 1; i++)
        {
            (this._data[i], this._data[i + 1]) = (this._data[i + 1], this._data[i]);
        }

        _size--;

        return result;
    }

    private static void Clone(T[] data1, T[] data2)
    {
        for (var i = 0; i < data2.Length; i++)
        {
            data1[i] = data2[i];
        }
    }

    public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(_data[0.. _size]);
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    private class MyEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] data;
        private int index = -1;

        public T Current
        {
            get
            {
                if (index == -1 || index >= data.Length)
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                return data[index];
            }
        }
        object IEnumerator.Current => Current;

        public MyEnumerator(T[] data)
        {
            this.data = data;
        }

        public bool MoveNext()
        {
            index++;
            return index < data.Length;
        }

        public void Reset()
        {
            this.index = -1;
        }
        
        public void Dispose()
        {
            Console.WriteLine("I don't know who is he...");
        }
    }
}