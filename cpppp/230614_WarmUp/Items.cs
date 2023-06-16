using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _230614_WarmUp
{
    public class Items
    {
        public string itemName;
        public int itemPrice;

        public void Init(string name, int price)
        {
            itemName = name;
            itemPrice = price;
        }
    }
}
