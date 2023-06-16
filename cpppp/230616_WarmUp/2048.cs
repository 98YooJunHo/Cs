using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// By YJH

namespace _230616_WarmUp
{
    public class _2048
    {
        System.ConsoleKeyInfo playerInput;
        int[,] map = new int[10, 10];
        int mapSize;
        int zeroCount;

        public void Play_Game()
        {
            string playerStr;
            Console.SetCursorPosition(0, 0);
            Console.Write("맵의 크기를 입력하고 엔터를 누르세요(4~10) : ");
            playerStr = Console.ReadLine();
            int.TryParse(playerStr, out mapSize);

            if (mapSize < 4 || 10 < mapSize)
            {
                Console.SetCursorPosition(0, 1);
                Console.Write("올바른 범위의 값을 입력하세요");
                Thread.Sleep(500);
                Console.SetCursorPosition(0, 0);
                Console.Write("                                                    ");
                Console.SetCursorPosition(0, 1);
                Console.Write("                                ");
                Play_Game();
            }      // 지정한 범위 이외의 값 예외처리

            Make_Map();

            while(true)
            {
                Make_2();
                Clear_Map();
                Print_Map();
                Move_2();
            }
        }

        void Clear_Map()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.WriteLine("                                                                                 ");
            Console.SetCursorPosition(0, 0);
        }

        void Make_Map()
        {
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    map[y, x] = 0;
                }
            }
        }

        void Print_Map()
        {
            Console.SetCursorPosition(0, 3);
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    if (map[y, x] == 2 || map[y, x] == 4 || map[y, x] == 8 || map[y, x] == 16 || 
                        map[y, x] == 32 || map[y, x] == 64 || map[y, x] == 128 || map[y, x] == 256 || 
                        map[y, x] == 512 || map[y, x] == 1024 || map[y, x] == 2048 || map[y, x] == 4096)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    //else if (map[y, x] == 0)
                    //{
                    //    Console.ForegroundColor = ConsoleColor.Red;
                    //    Console.Write("{0} ", map[y, x]);
                    //    Console.ResetColor();
                    //}
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }

        void Make_2()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, mapSize * mapSize);
            for (int i = 0; i < 1; i++)
            {
                while (true)
                {
                    if (map[(randomIndex / mapSize), (randomIndex % mapSize)] == 0)
                    {
                        map[(randomIndex / mapSize), (randomIndex % mapSize)] = 2;
                        break;
                    }
                    else
                    {
                        randomIndex = random.Next(0, mapSize * mapSize);
                        continue;
                    }
                }
            }
        }

        void Move_2()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("위 w, 왼쪽 a, 아래 s, 오른쪽 d : ");
            playerInput = Console.ReadKey();
            int temp;

            if (playerInput.KeyChar == 'w') // 위로 이동
            {
                for (int x = 0; x < mapSize; x++)
                {
                    for (int i = 0; i < mapSize; i++)           // 맵 크기 만큼 x정렬 반복
                    {
                        for (int y = 0; y < mapSize - 1; y++)
                        {
                            if (map[y, x] == 0)                     // 본 숫자가 0인 경우
                            {
                                temp = map[y + 1, x];           // 오른쪽 으로 밈
                                map[y + 1, x] = map[y, x];
                                map[y, x] = temp;
                            }
                            else if (map[y + 1, x] == map[y, x])    // 본 숫자가 0이 아니고 본 숫자와 왼쪽 숫자가 같은경우
                            {
                                map[y, x] += map[y + 1, x];         // 본 숫자에 왼쪽 숫자 더하고
                                map[y + 1, x] = 0;                  // 왼쪽 숫자 초기화
                            }
                            else { /*pass*/ }
                        }
                    }
                }
            }
            else if (playerInput.KeyChar == 's') // 아래로 이동
            {
                for (int x = 0; x < mapSize; x++)
                {
                    for (int i = 0; i < mapSize; i++)           // 맵 크기 만큼 x정렬 반복
                    {
                        for (int y = mapSize - 1; y > 0; y--)
                        {
                            if (map[y, x] == 0)                     // 본 숫자가 0인 경우
                            {
                                temp = map[y-1, x];           // 0을 맨 왼쪽으로 밈
                                map[y-1, x] = map[y, x];
                                map[y, x] = temp;
                            }
                            else if (map[y-1, x] == map[y, x])    // 본 숫자가 0이 아니고 본 숫자와 왼쪽 숫자가 같은경우
                            {
                                map[y, x] += map[y-1, x];         // 본 숫자에 왼쪽 숫자 더하고
                                map[y-1, x] = 0;                  // 왼쪽 숫자 초기화
                            }
                            else { /*pass*/ }
                        }
                    }
                }
            }
            else if (playerInput.KeyChar == 'a') // 왼쪽으로 이동
            {
                for (int y = 0; y < mapSize; y++)
                {
                    for (int i = 0; i < mapSize; i++)           // 맵 크기 만큼 x정렬 반복
                    {
                        for (int x = 0; x < mapSize - 1; x++)
                        {
                            if (map[y, x] == 0)                     // 본 숫자가 0인 경우
                            {
                                temp = map[y, x + 1];           // 오른쪽 으로 밈
                                map[y, x + 1] = map[y, x];
                                map[y, x] = temp;
                            }
                            else if (map[y, x + 1] == map[y, x])    // 본 숫자가 0이 아니고 본 숫자와 왼쪽 숫자가 같은경우
                            {
                                map[y, x] += map[y, x + 1];         // 본 숫자에 왼쪽 숫자 더하고
                                map[y, x + 1] = 0;                  // 왼쪽 숫자 초기화
                            }
                            else { /*pass*/ }
                        }
                    }
                }
            }
            else if (playerInput.KeyChar == 'd')                // 오른쪽으로 이동
            {
                for(int y = 0; y < mapSize; y++) 
                {
                    for (int i = 0; i < mapSize; i++)           // 맵 크기 만큼 x정렬 반복
                    {
                        for (int x = mapSize - 1; x > 0; x--)
                        {
                            if (map[y, x] == 0)                     // 본 숫자가 0인 경우
                            {
                                temp = map[y, x - 1];           // 0을 맨 왼쪽으로 밈
                                map[y, x - 1] = map[y, x];
                                map[y, x] = temp;
                            }
                            else if (map[y, x - 1] == map[y, x])    // 본 숫자가 0이 아니고 본 숫자와 왼쪽 숫자가 같은경우
                            {
                                map[y, x] += map[y, x - 1];         // 본 숫자에 왼쪽 숫자 더하고
                                map[y, x - 1] = 0;                  // 왼쪽 숫자 초기화
                            }
                            else { /*pass*/ }
                        }
                    }
                }
            }
        }

    }
}
