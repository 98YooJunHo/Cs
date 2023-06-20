using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public class Parent
    {
        protected int number;
        protected string strValue;

        public virtual void Print_Infos()
        {
            number = 1;
            strValue = "This is Parent";
            Console.WriteLine("Parent Class -> number : {0}, strValue : {1}",
                number, strValue);
        }
    }
}
