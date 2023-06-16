using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230614.Properties
{
    public class ItemInfo
    {
        public string itemName;
        public int itemValue { get; private set; }  // property

        private int _itemPrice;
        public int ItemPrice
        {
            get
            {
                return _itemPrice;
            }

            set
            {
                _itemPrice = value;
            }
        }



        public void InitItem(string name, int value, int price)
        {
            itemName = name;
            itemValue = value;
            ItemPrice = price;
        }

        // 아이템 이름을 리턴해보겠음

        public string Get_ItemName()
        {
            return itemName;
        }           // Get_ItemName()

        public void Set_ItemName(string changedName)
        {
            itemName = changedName;
        }

    }
}
