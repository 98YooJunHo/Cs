using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230614_T
{
    public class Program
    {
        static void Main(string[] args)
        {
            int money = 10000;

            Random random = new Random();
            Items rustySword = new Items();
            rustySword.Init("녹슨 검", 350, 1);
            Items poo = new Items();
            poo.Init("똥", 1, 100);
            Items torch = new Items();
            torch.Init("횃불", 150, 12);
            Items bread = new Items();
            bread.Init("빵", 150, 16);
            Items bandage = new Items();
            bandage.Init("붕대", 200, 2);
            Items antidote = new Items();
            antidote.Init("해독제", 200, 2);
            Items opium = new Items();
            opium.Init("아편", 200, 2);
            Items shovel = new Items();
            shovel.Init("삽", 150, 3);
            Items key = new Items();
            key.Init("열쇠", 250, 3);
            Items fireWood = new Items();
            fireWood.Init("장작", 200, 1);

            Items rustySwordC = new Items();
            rustySwordC.Init("녹슨 검", 350, 1);
            Items pooC = new Items();
            pooC.Init("똥", 1, 100);
            Items torchC = new Items();
            torchC.Init("횃불", 150, 12);
            Items breadC = new Items();
            breadC.Init("빵", 150, 16);
            Items bandageC = new Items();
            bandageC.Init("붕대", 200, 2);
            Items antidoteC = new Items();
            antidoteC.Init("해독제", 200, 2);
            Items opiumC = new Items();
            opiumC.Init("아편", 200, 2);
            Items shovelC = new Items();
            shovelC.Init("삽", 150, 3);
            Items keyC = new Items();
            keyC.Init("열쇠", 250, 3);
            Items fireWoodC = new Items();
            fireWoodC.Init("장작", 200, 1);


            List<Items> shopList = new List<Items>();
            shopList.Add(rustySword);
            shopList.Add(poo);
            shopList.Add(torch);
            shopList.Add(bread);
            shopList.Add(bandage);
            shopList.Add(antidote);
            shopList.Add(opium);
            shopList.Add(shovel);
            shopList.Add(key);
            shopList.Add(fireWood);

            List<Items> shopListCopy = new List<Items>();
            shopListCopy.Add(rustySwordC);
            shopListCopy.Add(pooC);
            shopListCopy.Add(torchC);
            shopListCopy.Add(breadC);
            shopListCopy.Add(bandageC);
            shopListCopy.Add(antidoteC);
            shopListCopy.Add(opiumC);
            shopListCopy.Add(shovelC);
            shopListCopy.Add(keyC);
            shopListCopy.Add(fireWoodC);

            List<Items> myInventory = new List<Items>();

            Make_Shop(ref shopList, ref shopListCopy);

            //Print_check(ref shopList);
            //Console.WriteLine();
            //shopList[0].itemValue --;
            //shopListCopy[0].itemValue = 1;
            //Print_check(ref shopListCopy);
            //Console.WriteLine();
            //Print_check(ref shopList);
            //Console.WriteLine();

            //myInventory.Add(shopList[0]);

            //Print_check(ref myInventory);
            //Console.WriteLine();


            //Print_check(ref shopList);
            //Console.WriteLine();
            //shopListCopy[0].itemValue -= 1;
            //Print_check(ref shopListCopy);

            while (true)
            {
                //break;
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

                string inputStr;
                string eachStr;
                int input;
                int each;

                if (shopList.Count == 0)
                {
                    break;
                }

                Print_Shop(ref shopList);
                Print_Inventory(ref myInventory, money);
                Console.Write("구매하고자 하는 아이템을 선택하세요");
                inputStr = Console.ReadLine();
                int.TryParse(inputStr, out input);

                Console.Write("구매하고자 하는 갯수를 입력하세요");
                eachStr = Console.ReadLine();
                int.TryParse(eachStr, out each);

                if (3 < input || input < 1)
                {
                    continue;
                }

                Buy_Item(ref shopList, ref shopListCopy, ref myInventory, input, ref money, each);
                Sort_Inventory(ref myInventory, each);
                Make_Shop(ref shopList, ref shopListCopy);
            }

            void Print_check(ref List<Items> list)
            {
                for(int i = 0; i < list.Count-7; i++) 
                {
                    Console.WriteLine("{0} {1} {2}", list[i].itemName, list[i].itemPrice, list[i].itemValue);
                }
            }

            void Make_Shop(ref List<Items> items, ref List<Items> itemsEa)
            {
                for(int i = 0; i < items.Count; i++)
                {
                    int count = 0;
                    if (items[i].itemValue == 0)
                    {
                        count += 1;
                    }

                    if(count > (items.Count - 4))
                    {
                        return;
                    }
                }
                
                for (int i = 0; i < 10000; i++)
                {
                    int randomIdx = random.Next(0, items.Count - 1);
                    Items temp = new Items();
                    temp = items[randomIdx];
                    items[randomIdx] = items[randomIdx + 1];
                    items[randomIdx + 1] = temp;
                    
                    temp = itemsEa[randomIdx];
                    itemsEa[randomIdx] = itemsEa[randomIdx + 1];
                    itemsEa[randomIdx + 1] = temp;
                }
            }

            void Print_Shop(ref List<Items> shop)
            {
                if (shop.Count == 1)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine("{0}.아이템 이름 : {1}\n가격 : {2}, 수량 : {3}", (i + 1), shop[i].itemName, shop[i].itemPrice, shop[i].itemValue);
                    }
                }
                else if (shop.Count == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Console.WriteLine("{0}.아이템 이름 : {1}\n가격 : {2}, 수량 : {3}", (i + 1), shop[i].itemName, shop[i].itemPrice, shop[i].itemValue);
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("{0}.아이템 이름 : {1}\n가격 : {2}, 수량 : {3}", (i + 1), shop[i].itemName, shop[i].itemPrice, shop[i].itemValue);
                    }
                }
            }


            void Print_Inventory(ref List<Items> inventory, int coin)
            {
                Console.WriteLine("보유중인 금액 : {0}", coin);
                Console.Write("\n보유중인 아이템 : ");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.Write("{0} {1}개, ", inventory[i].itemName, inventory[i].itemValue);
                }
                Console.WriteLine();
            }

            void Buy_Item(ref List<Items> shop,ref List<Items> shopC, ref List<Items> inventory, int number, ref int coin, int each)
            {
                if (coin - (shop[number - 1].itemPrice * each) < 0 || shop[number - 1].itemValue < each || shop[number - 1].itemValue == 0)
                {   // 사려고자 하는 물건이
                    return;
                }


                //for (int i = 0; i < inventory.Count; i++)
                //{
                //    if (inventory[i].itemName == shop[number - 1].itemName)
                //    {
                //        inventory[i].itemValue += each;

                //        coin -= (shop[number - 1].itemPrice * each);
                //    }
                //    else 
                //    { 
                //        shopC[number - 1].itemValue = each;
                //        inventory.Add(shopC[number - 1]);
                //        shop[number - 1].itemValue -= each;

                //        coin -= (shop[number - 1].itemPrice * each);
                //    }
                //}

                //if (inventory.Count == 0)
                //{
                    shopC[number - 1].itemValue = each;
                    inventory.Add(shopC[number - 1]);
                    shop[number - 1].itemValue -= each;

                    coin -= (shop[number - 1].itemPrice * each);
                //}
            }

            void Sort_Inventory(ref List<Items> inven, int count)
            {
                if (inven.Count > 1)
                {
                    for (int y = 0; y < inven.Count; y++)
                    {
                        for (int x = y + 1; x < inven.Count; x++)
                        {
                            if (inven[y].itemName == inven[x].itemName)
                            {
                                inven[y].itemValue += (count-1);
                                inven.Remove(inven[x]);
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
