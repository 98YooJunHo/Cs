using _230614.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace _230614
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        void Des003()
        {
            ItemType_JH itemType;

            itemType = ItemType_JH.POTION;

            Console.WriteLine("Enum Type은 무엇이라고 출력이 될까?? ->{0}", itemType);



            switch (itemType)
            {
                case ItemType_JH.POTION:
                    Console.WriteLine("이 아이템의 타입은 포션입니다.");
                    break;

                case ItemType_JH.GOLD:
                    Console.WriteLine("이 아이템의 타입은 골드입니다.");
                    break;

                case ItemType_JH.WEAPON:
                    Console.WriteLine("이 아이템의 타입은 무기입니다.");
                    break;

                case ItemType_JH.ARMOR:
                    Console.WriteLine("이 아이템의 타입은 방어구입니다.");
                    break;
                default:
                    Console.WriteLine("이 아이템의 타입은 정의되지 않았습니다");
                    break;
            }
        }

        public static void Des001(string[] args)
        {
            //Am940 print = new Am940();
            //print.Print_Message();

            //Am940.staticMessage = "이거 가능?";
            //Console.WriteLine("{0}", Am940.staticMessage);

            

            List<int> numbers = new List<int>();
            Console.WriteLine("내 리스트의 크기는 몇이니? - > {0}", numbers.Count);

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i + 1);
            }

            foreach (int i in numbers)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("내 리스트의 크기는 몇이니? - > {0}", numbers.Count);


            for (int i = numbers.Count - 1; i > -1; i--)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine("내가 지우려는 데이터 - > {0}", numbers[i]);
                    numbers.Remove(i + 1);
                }
            }

            foreach (int i in numbers)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("내 리스트의 크기는 몇이니? - > {0}", numbers.Count);
        }

        void Des002()
        {
            Dictionary<string, int> myInventory = new Dictionary<string, int>();
            myInventory.Add("빨간 포션", 5);
            myInventory.Add("골드", 500);
            myInventory.Add("몰락한 왕의 검", 1);

            ItemInfo redPotion = new ItemInfo();
            redPotion.InitItem("빨간 포션", 5, 50);
            ItemInfo sword = new ItemInfo();
            sword.InitItem("몰락한 왕의 검", 1, 2950);
            ItemInfo gold = new ItemInfo();
            gold.InitItem("골드", 500, 1);

            //Dictionary<string, ItemInfo> myInventory2 = new Dictionary<string, ItemInfo>();
            //myInventory2.Add("몰락한 왕의 검", sword);
            //myInventory2.Add("빨간 포션", redPotion);
            //myInventory2.Add("골드", gold);

            //foreach(var item in myInventory2)
            //{
            //    Console.WriteLine("아이템 이름: {0}, 아이템 갯수: {1}, 아이템 가격: {2}", 
            //        item.Value.itemName, item.Value.itemValue, item.Value.itemPrice);
            //}

            foreach (KeyValuePair<string, int> item in myInventory)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("아이템 이름: {0}, 아이템 갯수: {1}",
                        item.Key, item.Value);
                }
            }



            //Console.WriteLine("아이템 갯수: {0}", myInventory["빨간 포션"]);

            Stack<int> stackNumbers = new Stack<int>();
            stackNumbers.Push(1);
            stackNumbers.Pop();
        }
    }
}
