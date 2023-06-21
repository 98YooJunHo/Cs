using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230620_Quest
{
    public class GameHard
    {
        System.ConsoleKeyInfo playerInput;
        const int MAP_SIZE = 7;
        char[,] map = new char[MAP_SIZE, MAP_SIZE];
        int verticalCount = 0;
        int horizonCount = 0;
        int playerY = 3;
        int playerX = 3;

        public void Play_Game()
        {
            Make_Map();
            while (true)
            {
                Print_Map();
                Move_Player();
                Set_Map();
                Clear();
            }
        }

        void Clear()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("                                                                                          ");
            }
            Console.SetCursorPosition(0, 0);
        }
        void Make_Map()
        {
            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if (y == 0 || x == 0 || y == 6 || x == 6)
                    {
                        map[y, x] = '#';
                    }
                    else
                    {
                        map[y, x] = ' ';
                    }

                    if ((y == 3 && x == 0) || (y == 0 && x == 3) || (y == 3 && x == 6) || (y == 6 && x == 3))
                    {
                        map[y, x] = '♨';
                    }

                    if (y == playerY && x == playerX)
                    {
                        map[y, x] = '●';
                    }
                }
            }
        }

        void Set_Map()
        {
            if (verticalCount == 0 && horizonCount == 0)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    for (int x = 0; x < MAP_SIZE; x++)
                    {
                        if (y == 0 || x == 0 || y == 6 || x == 6)
                        {
                            map[y, x] = '#';
                        }
                        else
                        {
                            map[y, x] = ' ';
                        }

                        if ((y == 3 && x == 0) || (y == 0 && x == 3) || (y == 3 && x == 6) || (y == 6 && x == 3))
                        {
                            map[y, x] = '♨';
                        }

                        if (y == playerY && x == playerX)
                        {
                            map[y, x] = '●';
                        }
                    }
                }
            }
            if (verticalCount == 1 && horizonCount == 0)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    for (int x = 0; x < MAP_SIZE; x++)
                    {
                        if (y == 0 || x == 0 || y == 6 || x == 6)
                        {
                            map[y, x] = '#';
                        }
                        else
                        {
                            map[y, x] = ' ';
                        }

                        if (y == 0 && x == 3)
                        {
                            map[y, x] = '♨';
                        }

                        if (y == playerY && x == playerX)
                        {
                            map[y, x] = '●';
                        }
                    }
                }
            }
            if (verticalCount == -1 && horizonCount == 0)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    for (int x = 0; x < MAP_SIZE; x++)
                    {
                        if (y == 0 || x == 0 || y == 6 || x == 6)
                        {
                            map[y, x] = '#';
                        }
                        else
                        {
                            map[y, x] = ' ';
                        }

                        if (y == 6 && x == 3)
                        {
                            map[y, x] = '♨';
                        }

                        if (y == playerY && x == playerX)
                        {
                            map[y, x] = '●';
                        }
                    }
                }
            }
            if (verticalCount == 0 && horizonCount == 1)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    for (int x = 0; x < MAP_SIZE; x++)
                    {
                        if (y == 0 || x == 0 || y == 6 || x == 6)
                        {
                            map[y, x] = '#';
                        }
                        else
                        {
                            map[y, x] = ' ';
                        }

                        if (y == 3 && x == 0)
                        {
                            map[y, x] = '♨';
                        }

                        if (y == playerY && x == playerX)
                        {
                            map[y, x] = '●';
                        }
                    }
                }
            }
            if (verticalCount == 0 && horizonCount == -1)
            {
                for (int y = 0; y < MAP_SIZE; y++)
                {
                    for (int x = 0; x < MAP_SIZE; x++)
                    {
                        if (y == 0 || x == 0 || y == 6 || x == 6)
                        {
                            map[y, x] = '#';
                        }
                        else
                        {
                            map[y, x] = ' ';
                        }

                        if (y == 3 && x == 6)
                        {
                            map[y, x] = '♨';
                        }

                        if (y == playerY && x == playerX)
                        {
                            map[y, x] = '●';
                        }
                    }
                }
            }
        }

        void Print_Map()
        {
            for (int y = 0; y < MAP_SIZE; y++)
            {
                for (int x = 0; x < MAP_SIZE; x++)
                {
                    if (map[y, x] == '●')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0} ", map[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }

        public void Move_Player()
        {
            Console.SetCursorPosition(0, 8);
            Console.Write("위 w, 왼쪽 a, 아래 s, 오른쪽 d : ");
            playerInput = Console.ReadKey();

            if (playerInput.KeyChar == 'w') // 위로 이동
            {
                if (map[playerY - 1, playerX] == '#')
                {
                    return;
                }
                else if (map[playerY - 1, playerX] == '♨')
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = ' ';
                    map[MAP_SIZE - 2, playerX] = temp;
                    playerY = MAP_SIZE - 2;
                    verticalCount -= 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY - 1, playerX];
                    map[playerY - 1, playerX] = temp;
                    playerY -= 1;
                }
            }
            else if (playerInput.KeyChar == 's') // 아래로 이동
            {
                if (map[playerY + 1, playerX] == '#')
                {
                    return;
                }
                else if (map[playerY + 1, playerX] == '♨')
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = ' ';
                    map[0 + 1 , playerX] = temp;
                    playerY = 1;
                    verticalCount += 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY + 1, playerX];
                    map[playerY + 1, playerX] = temp;
                    playerY += 1;
                }
            }
            else if (playerInput.KeyChar == 'a') // 왼쪽으로 이동
            {
                if (map[playerY, playerX - 1] == '#')
                {
                    return;
                }
                else if (map[playerY, playerX - 1] == '♨')
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = ' ';
                    map[playerY, MAP_SIZE - 2] = temp;
                    playerX = MAP_SIZE - 2;
                    horizonCount -= 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY, playerX - 1];
                    map[playerY, playerX - 1] = temp;
                    playerX -= 1;
                }
            }
            else if (playerInput.KeyChar == 'd') // 오른쪽으로 이동
            {
                if (map[playerY, playerX + 1] == '#')
                {
                    return;
                }
                else if (map[playerY, playerX + 1] == '♨')
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = ' ';
                    map[playerY, 0 + 1] = temp;
                    playerX = 1;
                    horizonCount += 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY, playerX + 1];
                    map[playerY, playerX + 1] = temp;
                    playerX += 1;
                }
            }
            else
            {
                return;
            }
        }
    }
}
