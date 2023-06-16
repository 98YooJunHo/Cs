using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230614_WarmUp
{
    public class Program
    {
        static void Main(string[] args)
        {
            int money = 1000;

            Random random = new Random();
            Items rustySword = new Items();
            rustySword.Init("녹슨 검", 350);
            Items poo = new Items();
            poo.Init("똥", 1);
            Items torch = new Items();
            torch.Init("횃불", 150);
            Items bread = new Items();
            bread.Init("빵", 150);
            Items bandage = new Items();
            bandage.Init("붕대", 200);
            Items antidote = new Items();
            antidote.Init("해독제", 200);
            Items opium = new Items();
            opium.Init("아편", 200);
            Items shovel = new Items();
            shovel.Init("삽", 150);
            Items key = new Items();
            key.Init("열쇠", 250);
            Items fireWood = new Items();
            fireWood.Init("장작", 200);

            List<Items> itemList = new List<Items>();
            itemList.Add(rustySword);
            itemList.Add(poo);
            itemList.Add(torch);
            itemList.Add(bread);
            itemList.Add(bandage);
            itemList.Add(antidote);
            itemList.Add(opium);
            itemList.Add(shovel);
            itemList.Add(key);
            itemList.Add(fireWood);
            //Print_totalItem();

            List<Items> myInventory = new List<Items>();
            Make_Shop(ref itemList);
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.WriteLine("                                                        ");
                Console.SetCursorPosition(0, 0);

                int input = 0;

                if (itemList.Count == 0)
                {
                    break;
                }

                Print_Shop(ref itemList);
                Print_Inventory(ref myInventory, money);
                Console.Write("구매하고자 하는 아이템을 선택하세요");
                int.TryParse(Console.ReadLine(), out input);

                if(3 < input || input < 1)
                {
                    continue;
                }

                Buy_Item(ref itemList, ref myInventory, input, ref money);
                Make_Shop(ref itemList);
            }
         

            void Make_Shop(ref List<Items> items)
            {
                if(items.Count < 4)
                {
                    return;
                }
                for(int i = 0; i < 10000; i++)
                {
                    int randomIdx = random.Next(0, items.Count-1);
                    Items temp = new Items();
                    temp = items[randomIdx];
                    items[randomIdx] = items[randomIdx + 1];
                    items[randomIdx + 1] = temp;


                }
            }

            void Print_Shop(ref List<Items> shop)
            {
                if (shop.Count == 1)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine("{0}.아이템 이름 : {1}\n가격 : {2}", (i + 1), shop[i].itemName, shop[i].itemPrice);
                    }
                }
                else if (shop.Count == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine("{0}.아이템 이름 : {1}\n가격 : {2}", (i + 1), shop[i].itemName, shop[i].itemPrice);
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("{0}.아이템 이름 : {1}\n가격 : {2}", (i + 1), shop[i].itemName, shop[i].itemPrice);
                    }
                }
            }


            void Print_Inventory(ref List<Items> inventory, int coin)
            {
                Console.WriteLine("보유중인 금액 : {0}",coin);
                Console.Write("\n보유중인 아이템 : ");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.Write("{0}, ", inventory[i].itemName);
                }
                Console.WriteLine();
            }

            void Buy_Item(ref List<Items> shop, ref List<Items> inventory, int number, ref int coin)
            {
                if(coin - itemList[number - 1].itemPrice < 0)
                {
                    return;
                }
                coin -= itemList[number-1].itemPrice;
                inventory.Add(itemList[number-1]);
                shop.Remove(itemList[number-1]);
            }
        }
    }
}
