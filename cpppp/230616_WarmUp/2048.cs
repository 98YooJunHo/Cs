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
            Make_2();
            while(true)
            {
                Clear_Map();
                Print_Map();
                Move_2();
            }
        }

        // 맵을 지우는 함수
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

        // 맵을 만드는 함수
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

        // 맵을 출력하는 함수
        void Print_Map()
        {
            Console.SetCursorPosition(0, 3);
            for (int y = 0; y < mapSize; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    if (map[y, x]%2 == 0 && map[y,x] !=0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("{0,4} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0,4} ", map[y, x]);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("\n\n");
            }
        }

        // 맵에 랜덤으로 2를 만드는 함수
        void Make_2()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, mapSize * mapSize);                // 2차원 배열에 랜덤인덱스를 넣기 위해 배열크기의 제곱까지 랜덤인덱스숫자 저장
            for (int i = 0; i < 1; i++)
            {
                while (true)
                {
                    if (map[(randomIndex / mapSize), (randomIndex % mapSize)] == 0) // 해당 인덱스의 값이 0이라면
                    {
                        map[(randomIndex / mapSize), (randomIndex % mapSize)] = 2;  // 2대입
                        break;
                    }
                    else                                                            // 해당 인덱스의 값이 0이 아니라면
                    {
                        randomIndex = random.Next(0, mapSize * mapSize);            // 다시 섞음
                        continue;
                    }
                }
            }
        }

        // 숫자를 옮기는 함수
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
                    for (int i = 0; i < mapSize; i++)               // 맵 크기 만큼 y정렬 반복
                    {
                        for (int y = 0; y < mapSize - 1; y++)
                        {
                            if (map[y, x] == 0)                     // 본 숫자가 0인 경우
                            {
                                temp = map[y + 1, x];               // 아래쪽 으로 밈
                                map[y + 1, x] = map[y, x];
                                map[y, x] = temp;
                            }
                            else if (map[y + 1, x] == map[y, x])    // 본 숫자가 0이 아니고 본 숫자와 아래쪽 숫자가 같은경우
                            {
                                map[y, x] += map[y + 1, x];         // 본 숫자에 아래쪽 숫자 더하고
                                map[y + 1, x] = 0;                  // 아래쪽 숫자 초기화
                            }
                            else { /*pass*/ }
                        }
                    }
                }
                Make_2();
            }
            else if (playerInput.KeyChar == 's') // 아래로 이동
            {
                for (int x = 0; x < mapSize; x++)
                {
                    for (int i = 0; i < mapSize; i++)           // 맵 크기 만큼 y정렬 반복
                    {
                        for (int y = mapSize - 1; y > 0; y--)
                        {
                            if (map[y, x] == 0)                 // 본 숫자가 0인 경우
                            {
                                temp = map[y-1, x];             // 0을 위쪽으로 밈
                                map[y-1, x] = map[y, x];
                                map[y, x] = temp;
                            }
                            else if (map[y-1, x] == map[y, x])  // 본 숫자가 0이 아니고 본 숫자와 위쪽 숫자가 같은경우
                            {
                                map[y, x] += map[y-1, x];       // 본 숫자에 위쪽 숫자 더하고
                                map[y-1, x] = 0;                // 위쪽 숫자 초기화
                            }
                            else { /*pass*/ }
                        }
                    }
                }
                Make_2();
            }
            else if (playerInput.KeyChar == 'a') // 왼쪽으로 이동
            {
                for (int y = 0; y < mapSize; y++)
                {
                    for (int i = 0; i < mapSize; i++)               // 맵 크기 만큼 x정렬 반복
                    {
                        for (int x = 0; x < mapSize - 1; x++)
                        {
                            if (map[y, x] == 0)                     // 본 숫자가 0인 경우
                            {
                                temp = map[y, x + 1];               // 오른쪽 으로 밈
                                map[y, x + 1] = map[y, x];
                                map[y, x] = temp;
                            }
                            else if (map[y, x + 1] == map[y, x])    // 본 숫자가 0이 아니고 본 숫자와 오른쪽 숫자가 같은경우
                            {
                                map[y, x] += map[y, x + 1];         // 본 숫자에 오른쪽 숫자 더하고
                                map[y, x + 1] = 0;                  // 오른쪽 숫자 초기화
                            }
                            else { /*pass*/ }
                        }
                    }
                }
                Make_2();
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
                                temp = map[y, x - 1];               // 0을 왼쪽으로 밈
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
                Make_2();
            }
            else
            {
                return;
            }
        }

    }
}
