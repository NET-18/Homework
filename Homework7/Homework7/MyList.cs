using System;
using System.Collections;

namespace Homework7
{
    internal class MyList : IEnumerable
    {
        private MyClass[] myObjects;
        private int? capacity;

        public MyList(MyClass[] myArray)
        {
            myObjects = new MyClass[myArray.Length];

            for (int i = 0; i < myArray.Length; i++)
            {
                myObjects[i] = myArray[i];
            }
        }

        public MyClass[] MyObjects
        {
            get
            {
                return myObjects;
            }
            set
            {
                myObjects = value;
            }
        }

        public int Size
        {
            get
            {
                if (myObjects != null)
                {
                    return myObjects.Length;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Capacity
        {
            get
            {
                if (capacity == null)
                {
                    if (myObjects != null)
                    {
                        return myObjects.Length;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return capacity.Value;
                }

            }
            set
            {
                capacity = value;
                Array.Resize(ref myObjects, capacity.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public MyEnum GetEnumerator()
        {
            return new MyEnum(myObjects);
        }
    }
}
