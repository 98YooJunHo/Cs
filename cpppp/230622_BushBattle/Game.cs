using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _230622_BushBattle
{
    public class Game : Map
    {
        Random random = new Random();
        System.ConsoleKeyInfo playerInput;
        public void Play_Game()
        {
            Make_Map();
            while (true)
            {
                Print_Map();
                Print_Info();
                Move_Player();
            }
        }

        void Move_Player()
        {
            playerInput = Console.ReadKey();
            switch (playerInput.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        if (map[player_Y - 1, player_X] == NPC)
                        {
                            if (onQuest == 1)
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트는 한 번에 하나만 진행가능합니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                                            ");
                            }
                            else if (clearQuest == 5)
                            {

                            }
                            else
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트를 받았습니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                               ");
                                onQuest += 1;
                            }
                        }

                        if (map[player_Y - 1, player_X] == BUSH)
                        {
                            map[player_Y - 1, player_X] = map[player_Y, player_X];
                            map[player_Y, player_X] = ' ';
                            player_Y -= 1;
                            Set_Bush();
                            Battle();
                            break;
                        }

                        if (map[player_Y - 1, player_X] == GROUND)
                        {
                            char temp = map[player_Y - 1, player_X];
                            map[player_Y - 1, player_X] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_Y -= 1;
                            Set_Bush();
                            break;
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        if (map[player_Y + 1, player_X] == NPC)
                        {
                            if (onQuest == 1)
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트는 한 번에 하나만 진행가능합니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                                            ");
                            }
                            else if (clearQuest == 5)
                            {

                            }
                            else
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트를 받았습니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                               ");
                                onQuest += 1;
                            }
                        }

                        if (map[player_Y + 1, player_X] == BUSH)
                        {
                            map[player_Y + 1, player_X] = map[player_Y, player_X];
                            map[player_Y, player_X] = ' ';
                            player_Y += 1;
                            Set_Bush();
                            Battle();
                            break;
                        }

                        if (map[player_Y + 1, player_X] == GROUND)
                        {
                            char temp = map[player_Y + 1, player_X];
                            map[player_Y + 1, player_X] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_Y += 1;
                            Set_Bush();
                            break;
                        }
                        break;
                    }
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        if (map[player_Y, player_X - 1] == NPC)
                        {
                            if (onQuest == 1)
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트는 한 번에 하나만 진행가능합니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                                            ");
                            }
                            else if (clearQuest == 5)
                            {

                            }
                            else
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트를 받았습니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                               ");
                                onQuest += 1;
                            }
                        }
                        if (map[player_Y, player_X - 1] == BUSH)
                        {
                            map[player_Y, player_X - 1] = map[player_Y, player_X];
                            map[player_Y, player_X] = ' ';
                            player_X -= 1;
                            Set_Bush();
                            Battle();
                            break;
                        }

                        if (map[player_Y, player_X - 1] == GROUND)
                        {
                            char temp = map[player_Y, player_X - 1];
                            map[player_Y, player_X - 1] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_X -= 1;
                            Set_Bush();
                            break;
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        if (map[player_Y, player_X + 1] == NPC)
                        {
                            if (onQuest == 1)
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트는 한 번에 하나만 진행가능합니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                                            ");
                            }
                            else if (clearQuest == 5)
                            {

                            }
                            else
                            {
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("|      퀘스트를 받았습니다      |");
                                Thread.Sleep(900);
                                Console.SetCursorPosition(0, 19);
                                Console.WriteLine("                                               ");
                                onQuest += 1;
                            }
                        }

                        if (map[player_Y, player_X + 1] == BUSH)
                        {
                            map[player_Y, player_X + 1] = map[player_Y, player_X];
                            map[player_Y, player_X] = ' ';
                            player_X += 1;
                            Set_Bush();
                            break;
                        }

                        if (map[player_Y, player_X + 1] == GROUND)
                        {
                            char temp = map[player_Y, player_X + 1];
                            map[player_Y, player_X + 1] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_X += 1;
                            Set_Bush();
                            break;
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("올바른 방향키를 입력하세요");
                        Thread.Sleep(800);
                        Move_Player();
                        break;
                    }
            }
        }

        void Print_Map()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (map[y, x] == WALL)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == PLAYER)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == BUSH)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == NPC)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else
                        Console.Write("{0} ", map[y, x]);
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, MAP_SIZE_Y + 1);
            Console.Write("                                               ");
            Console.SetCursorPosition(0, MAP_SIZE_Y + 1);
            Console.Write("방향키로 이동, 현재 위치: ({0},{1})", player_Y, player_X);
        }

        void Print_Info()
        {
            Console.SetCursorPosition(0, 20);
            Console.Write("                                                                                     ");
            Console.SetCursorPosition(0, 20);
            if (onQuest > 0)
            {
                Console.Write("     |          퀘스트 진행중입니다          |");
            }
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("                                                                                                               ");
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("|체력:{0}/{1}|공격력:{2}|퀘스트 완료횟수:{3}|소지금:{4}|", playerHp, playerMHp, playerAtk, clearQuest, playerGold);
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("|총 전투횟수:{0}|", totalBattle);

        }

        void Clear_Battle()
        {
            for (int i = 0; i < 4; i ++)
            {
                Console.SetCursorPosition(MAP_SIZE_X * 2 + 1, i);
                Console.WriteLine("                                             ");
            }
        }

        void Battle()
        {
            int fightRate = random.Next(1, 101);

            if(fightRate <= 36)
            {
                Print_Map();
                Monster newMonster = new Monster();
                Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 0);
                for (int i = 0; i < 25; i++)
                {
                    Console.Write("!");
                    Thread.Sleep(50);
                }
                Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 1);
                Console.Write("    몬스터를 만났습니다!    ");
                Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 2);
                Console.Write("!!!!!!!!!!!!!!!!!!!!!!!!!");
                Thread.Sleep(1000);
                while (true)
                {
                    Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 0);
                    Console.Write("      몬스터의 공격      ");
                    Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 1);
                    Console.Write("        {0,2}의 피해         ", newMonster.monsterAtk);
                    playerHp -= newMonster.monsterAtk;
                    if(playerHp <= 0)
                    {
                        playerHp = 0;
                        Print_Info();
                        Console.SetCursorPosition(MAP_SIZE_X * 2 + 1, 2);
                        Console.Write("      내 체력 {0}/{1}      ", playerHp, playerMHp);
                        Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 3);
                        Console.Write("     적에게 당했습니다    ");
                        Thread.Sleep(1000);
                        Clear_Battle();
                        break;
                    }
                    Print_Info();
                    Console.SetCursorPosition(MAP_SIZE_X * 2 + 1, 2);
                    Console.Write("      내 체력 {0}/{1}      ", playerHp, playerMHp);
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 0);
                    Console.Write("        나의 공격        ");
                    Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 1);
                    Console.Write("        {0,2}의 피해         ", playerAtk);
                    Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 2);
                    newMonster.monsterHp -= playerAtk;
                    if(newMonster.monsterHp <= 0)
                    {
                        newMonster.monsterHp = 0;
                        Console.Write("     몬스터 체력 {0}/{1}     ", newMonster.monsterHp, newMonster.monsterMHp);
                        Console.SetCursorPosition(MAP_SIZE_X*2 + 1, 3);
                        Console.Write("     적을 처치했습니다    ");
                        Thread.Sleep(1000);
                        Clear_Battle();
                        battleCount += 1;
                        totalBattle += 1;
                        if(battleCount == 5)
                        {
                            battleCount = 0;
                            onQuest -= 1;
                            Console.SetCursorPosition(0, 20);
                            Console.Write("     |             퀘스트 클리어!             |");
                            Thread.Sleep(1000);
                            clearQuest += 1;
                            Print_Info();
                        }
                        break;
                    }
                    Console.Write("     몬스터 체력 {0}/{1}     ", newMonster.monsterHp, newMonster.monsterMHp);
                    Thread.Sleep(1000);
                }
            }
        }
    }

}
