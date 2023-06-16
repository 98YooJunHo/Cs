using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _230615
{
    public class StoneAge
    {
        System.ConsoleKeyInfo playerInput;
        int playerX;
        int playerY;
        char[,] map = new char[17, 17];
        int mapSize;
        int count = 0;
        int score = 0;
        int stoneCount = 0;

        public void Play_Game()
        {
            string playerStr;
            Console.SetCursorPosition(0, 0);
            Console.Write("맵의 크기를 입력하고 엔터를 누르세요(5~15) : ");
            playerStr = Console.ReadLine();
            int.TryParse(playerStr, out mapSize);

            if(mapSize < 5 || 15 < mapSize)
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

            Make_Map();                             // 맵을 만드는 함수

            while (true)
            {
                Print_StoneAndScore();              // 돌과 점수 출력함수
                Print_Map();                        // 맵을 출력하는 함수
                Move_Player();                      // 플레이어의 키입력을 받아 이동하고 이동에 따라 변화값을 넣는 함수
                Consider_StoneBreak();              // 돌이 부서지는 조건 체크
                if (count % ((mapSize+1)/2) == 0 && count != 0)
                {
                    if(stoneCount >= (mapSize * mapSize - 7)) { /*pass*/ }
                    else 
                    {
                        Make_Stone();                   // 땅을 (맵사이즈+1)/2번 밟을 경우 돌을 생성, 맵을 리셋하거나 돌을 터트린 후에도 (맵사이즈+1)/2번 땅을 밟을 시 돌 생성
                    }
                }
            }
        }

        void Make_Map()
        {
            playerX = (mapSize+1) / 2;
            playerY = (mapSize+1) / 2;

            for (int y = 0; y < mapSize + 2; y++)
            {
                for (int x = 0; x < mapSize + 2; x++)
                {
                    map[y, x] = '■';
                }
            }

            for (int y = 1; y < mapSize + 1; y++)
            {
                for (int x = 1; x < mapSize + 1; x++)
                {
                    map[y, x] = ' ';
                }
            }

            map[playerY, playerX] = '★';
        }

        void Print_Map()
        {
            Console.SetCursorPosition(0, 3);
            for (int y = 0; y < mapSize + 2; y++)
            {
                for (int x = 0; x < mapSize + 2; x++)
                {
                    if (map[y, x] == '★')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '●')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '■')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
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

        void Print_StoneAndScore()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("맵에 있는 바위 수 : {0} 현재 점수 : {1}                 ", stoneCount, score);
        }

        void Move_Player()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("위 w, 왼쪽 a, 아래 s, 오른쪽 d, 리셋 r : ");
            playerInput = Console.ReadKey();
            char temp;
            int broken;
            if (playerInput.KeyChar == 'w') // 위로 이동
            {
                if (map[playerY - 1, playerX] == '■')
                {
                    return;
                }
                else if (map[playerY - 1, playerX] == '●')
                {
                    for(int y = playerY - 2; y > 0; y --)
                    {
                        if (map[y, playerX] == '■' || map[y, playerX] == '●')
                        {
                            return;
                        }
                        else
                        {
                            temp = map[y, playerX];
                            map[y, playerX] = map[y + 1, playerX];
                            map[y + 1, playerX] = temp;
                            broken = Consider_StoneBreak();
                            Print_Map();
                            Thread.Sleep(30);
                            if (broken == 1)
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY - 1, playerX];
                    map[playerY - 1, playerX] = temp;
                    playerY -= 1;
                    count += 1;
                }
            }
            else if (playerInput.KeyChar == 's') // 아래로 이동
            {
                if (map[playerY + 1, playerX] == '■')
                {
                    return;
                }
                else if (map[playerY + 1, playerX] == '●')
                {
                    for (int y = playerY + 2; y < mapSize + 2; y++)
                    {
                        if (map[y, playerX] == '■' || map[y, playerX] == '●')
                        {
                            return;
                        }
                        else
                        {
                            temp = map[y, playerX];
                            map[y, playerX] = map[y - 1, playerX];
                            map[y - 1, playerX] = temp;
                            broken = Consider_StoneBreak();
                            Print_Map();
                            Thread.Sleep(30);
                            if (broken == 1)
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY + 1, playerX];
                    map[playerY + 1, playerX] = temp;
                    playerY += 1;
                    count += 1;
                }
            }
            else if (playerInput.KeyChar == 'a') // 왼쪽으로 이동
            {
                if (map[playerY, playerX - 1] == '■')
                {
                    return;
                }
                else if (map[playerY, playerX - 1] == '●')
                {
                    for (int x = playerX - 2; x > 0; x--)
                    {
                        if (map[playerY, x] == '■' || map[playerY, x] == '●')
                        {
                            return;
                        }
                        else
                        {
                            temp = map[playerY, x];
                            map[playerY, x] = map[playerY, x + 1];
                            map[playerY, x + 1] = temp;
                            broken = Consider_StoneBreak();
                            Print_Map();
                            Thread.Sleep(30);
                            if (broken == 1)
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY, playerX - 1];
                    map[playerY, playerX - 1] = temp;
                    playerX -= 1;
                    count += 1;
                }
            }
            else if (playerInput.KeyChar == 'd') // 오른쪽으로 이동
            {
                if (map[playerY, playerX + 1] == '■')
                {
                    return;
                }
                else if (map[playerY, playerX + 1] == '●')
                {
                    for (int x = playerX + 2; x < mapSize + 2; x++)
                    {
                        if (map[playerY, x] == '■' || map[playerY, x] == '●')
                        {
                            return;
                        }
                        else
                        {
                            temp = map[playerY, x];
                            map[playerY, x] = map[playerY, x - 1];
                            map[playerY, x - 1] = temp;
                            broken = Consider_StoneBreak();
                            Print_Map();
                            Thread.Sleep(30);
                            if (broken == 1)
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY, playerX + 1];
                    map[playerY, playerX + 1] = temp;
                    playerX += 1;
                    count += 1;
                }
            }
            else if (playerInput.KeyChar == 'r')
            {
                for (int x = 0; x < mapSize + 2; x++)
                {
                    for (int y = 0; y < mapSize + 2; y++)
                    {
                        if (map[y, x] == '●')
                        {
                            map[y, x] = ' ';
                        }
                    }
                }
                stoneCount = 0;
                count = 0;
            }
            else
            {
                return;
            }
        }

        void Make_Stone()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, (mapSize + 2) * (mapSize + 2));
            while (true)
            {
                if (map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] == ' ')
                {
                    map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] = '●';
                    stoneCount += 1;
                    break;
                }
                else
                {
                    randomIndex = random.Next(0, (mapSize + 2) * (mapSize + 2));
                    continue;
                }
            }
            while (true)
            {
                if (map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] == ' ')
                {
                    map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] = '●';
                    stoneCount += 1;
                    break;
                }
                else
                {
                    randomIndex = random.Next(0, (mapSize + 2) * (mapSize + 2));
                    continue;
                }
            }
            while (true)
            {
                if (map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] == ' ')
                {
                    map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] = '●';
                    stoneCount += 1;
                    break;
                }
                else
                {
                    randomIndex = random.Next(0, (mapSize + 2) * (mapSize + 2));
                    continue;
                }
            }
        }

        int Consider_StoneBreak()
        {
            int VerticalWin = 0;

            for (int x = 0; x < mapSize + 2; x++)
            {
                for (int y = 0; y < mapSize; y++)
                {
                    for (int i = y + 0; i < y + 3; i++)
                    {
                        if (map[i, x] == '●')
                        {
                            VerticalWin += 1;
                        }

                        if (VerticalWin == 3)
                        {
                            map[i, x] = ' ';
                            map[i - 1, x] = ' ';
                            map[i - 2, x] = ' ';
                            stoneCount -= 3;
                            count = 0;
                            score += 100;
                            return 1;
                        }
                    }
                    VerticalWin = 0;
                }
            }

            int horizonWin = 0;

            for (int y = 0; y < mapSize + 2; y++)
            {
                for (int x = 0; x < mapSize; x++)
                {
                    for (int i = x + 0; i < x + 3; i++)
                    {
                        if (map[y, i] == '●')
                        {
                            horizonWin += 1;
                        }

                        if (horizonWin == 3)
                        {
                            map[y, i] = ' ';
                            map[y, i - 1] = ' ';
                            map[y, i - 2] = ' ';
                            stoneCount -= 3;
                            score += 100;
                            count = 0;
                            return 1;
                        }
                    }
                    horizonWin = 0;
                }
            }
            return 0;
        }

    }
}
