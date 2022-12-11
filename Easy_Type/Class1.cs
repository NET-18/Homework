using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Pub
    {

        //Свойство OnChange содержит список всех callback-методов подписчиков 
        public event Action OnChange = delegate { };

        public void Raise()
        {
            //Вызов OnChange
            OnChange();
        }

    }
}
