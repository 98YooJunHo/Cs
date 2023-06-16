using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230614_T
{
    public class Items
    {
        public string itemName;
        public int itemPrice;
        public int itemValue;

        public void Init(string name, int price, int value)
        {
            itemName = name;
            itemPrice = price;
            itemValue = value;
        }
    }
}
