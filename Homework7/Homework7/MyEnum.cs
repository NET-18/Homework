using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    internal class MyEnum : IEnumerator
    {
        private MyClass[] myObjects; 
        private int position = -1;

        public MyEnum(MyClass[] myObjects) 
        {
            this.myObjects = myObjects;
        }

        public bool MoveNext()
        {
            position++;
            return (position < myObjects.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public MyClass Current
        {
            get
            {
                try
                {
                    return myObjects[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
    }
}
