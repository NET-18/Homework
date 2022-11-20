using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_Seventh_App
{
    internal class MyList : IEnumerable
    {
        private int[] data = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

        public IEnumerator GetEnumerator() => new MyEnumirator(data);

        private class MyEnumirator : IEnumerator
        {
            private readonly int[] data;
            private int index = -1;

            public object Current
            {
                get
                {
                    if(index == -1 || index >= data.Length)
                    {
                        throw new ArgumentException();
                    }

                    return data[index];
                }     
            }

            public MyEnumirator(int[] data)
            {
                this.data = data;
            }


            public bool MoveNext()
            {
                if(index < data.Length-1)
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
                index= -1;
            }
        }
    }
}
