using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Runtime.InteropServices;

namespace _230621_Warmup
{
    public class WallRunner
    {
        System.ConsoleKeyInfo playerInput;
        public const int MAP_SIZE_Y = 17;
        public const int MAP_SIZE_X = 32;
        public const char MONSTER = 'δ';
        public const char PLAYER = '♥';
        public const char WALL = '■';
        public const char GROUND = ' ';
        public const char DEATH = '†';
        int player_Y = MAP_SIZE_Y / 2;
        int player_X = MAP_SIZE_X / 2;
        char[,] map = new char[MAP_SIZE_Y, MAP_SIZE_X];
        int moveCount = 0;
        int totalMoveCount = 0;
        int death = 0;
        int score = 0;
        int maxScore = 0;
        int regame = 0;
        List<MopPosition> enemy = new List<MopPosition>();

        public void Play_Game()
        {
            death = 0;
            score = 0;
            moveCount = 0;
            totalMoveCount = 0;
            enemy.Clear();
            Clear();
            Make_Map();
            Make_Wall();
            Make_Monster();
            while (true)
            {
                if(death > 0)
                {
                    Death();

                    if(regame > 0)
                    {
                        regame = 0;
                        Play_Game();
                    }

                    else
                    {
                        break;
                    }

                }

                score = totalMoveCount * 100;
                if(score > maxScore)
                {
                    maxScore = score;
                }
                Print_Map();
                Move_Player();
                if (moveCount == 10)
                {
                    Make_Monster();
                    moveCount = 0;
                }
            }
        }

        void Clear()
        {
            for(int i = 0; i < MAP_SIZE_Y+3; i++)
            {
                Console.WriteLine("                                                                                                                                 ");
            }
        }

        void Make_Map()
        {
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (y == 0 || x == 0 || y == MAP_SIZE_Y - 1 || x == MAP_SIZE_X - 1)
                    {
                        map[y, x] = WALL;
                    }
                    else if (y == player_Y && x == player_X)
                    {
                        map[y, x] = PLAYER;
                    }
                    else
                    {
                        map[y, x] = GROUND;
                    }
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
                    else if (map[y, x] == MONSTER)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else
                        Console.Write("{0} ", map[y, x]);
                }
                Console.WriteLine();
            }
            Console.Write("현재 점수: {0}, 최고 점수: {1}", score, maxScore);
        }

        void Move_Player()
        {
            Console.SetCursorPosition(0, 18);
            Console.Write("방향키로 이동:");
            playerInput = Console.ReadKey();
            switch (playerInput.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        if (map[player_Y - 1, player_X] == MONSTER)
                        {
                            death += 1;
                            return;
                        }

                        if (map[player_Y - 1, player_X] == GROUND)
                        {
                            char temp = map[player_Y - 1, player_X];
                            map[player_Y - 1, player_X] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_Y -= 1;
                            moveCount++;
                            totalMoveCount++;
                            Move_Monster();
                            break;
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        if (map[player_Y + 1, player_X] == MONSTER)
                        {
                            death += 1;
                            return;
                        }

                        if (map[player_Y + 1, player_X] == GROUND)
                        {
                            char temp = map[player_Y + 1, player_X];
                            map[player_Y + 1, player_X] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_Y += 1;
                            moveCount++;
                            totalMoveCount++;
                            Move_Monster();
                            break;
                        }
                        break;
                    }
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        if (map[player_Y, player_X - 1] == MONSTER)
                        {
                            death += 1;
                            return;
                        }

                        if (map[player_Y, player_X - 1] == GROUND)
                        {
                            char temp = map[player_Y, player_X - 1];
                            map[player_Y, player_X - 1] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_X -= 1;
                            moveCount++;
                            totalMoveCount++;
                            Move_Monster();
                            break;
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        if (map[player_Y, player_X + 1] == MONSTER)
                        {
                            death += 1;
                            return;
                        }

                        if (map[player_Y, player_X + 1] == GROUND)
                        {
                            char temp = map[player_Y, player_X + 1];
                            map[player_Y, player_X + 1] = map[player_Y, player_X];
                            map[player_Y, player_X] = temp;
                            player_X += 1;
                            moveCount++;
                            totalMoveCount++;
                            Move_Monster();
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

        void Make_Wall()
        {
            Random random = new Random();
            int indexY = random.Next(MAP_SIZE_Y);
            int indexX = random.Next(MAP_SIZE_X);
            int wallCount = 0;
            while (wallCount < ((MAP_SIZE_X-2)*(MAP_SIZE_Y-2)) / 7)
            {

                if (map[indexY, indexX] == GROUND)
                {
                    map[indexY, indexX] = WALL;
                    wallCount++;
                    continue;
                }
                else
                {
                    indexX = random.Next(MAP_SIZE_X);
                    indexY = random.Next(MAP_SIZE_Y);
                    continue;
                }

            }
        }

        void Make_Monster()
        {
            Random random = new Random();
            int indexY = random.Next(MAP_SIZE_Y);
            int indexX = random.Next(MAP_SIZE_X);
            while (true)
            {

                if (map[indexY, indexX] == GROUND)
                {
                    map[indexY, indexX] = MONSTER;
                    MopPosition mop = new MopPosition();
                    mop.pos[0] = indexY;
                    mop.pos[1] = indexX;
                    enemy.Add(mop);
                    break;
                }
                else
                {
                    indexX = random.Next(MAP_SIZE_X);
                    indexY = random.Next(MAP_SIZE_Y);
                    continue;
                }

            }
        }

        void Move_Monster()
        {
            for(int i = 0; i < enemy.Count; i++)
            {
                int yDiff = player_Y - enemy[i].pos[0];
                int xDiff = player_X - enemy[i].pos[1];
                if ((xDiff * xDiff) > (yDiff * yDiff))
                {
                    if (xDiff < 0)
                    {
                        if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == GROUND)
                        {
                            char temp = map[enemy[i].pos[0], enemy[i].pos[1] - 1];
                            map[enemy[i].pos[0], enemy[i].pos[1] - 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                            map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                            enemy[i].pos[1] -= 1;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == PLAYER)
                        {
                            death += 1;
                            return;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == WALL || map[enemy[i].pos[0], enemy[i].pos[1] - 1] == MONSTER)
                        {
                            if (yDiff < 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (yDiff > 0)
                            {
                                if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if(yDiff == 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                        }
                    }
                    else if (xDiff > 0)
                    {
                        if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == GROUND)
                        {
                            char temp = map[enemy[i].pos[0], enemy[i].pos[1] + 1];
                            map[enemy[i].pos[0], enemy[i].pos[1] + 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                            map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                            enemy[i].pos[1] += 1;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == PLAYER)
                        {
                            death += 1;
                            return;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == WALL || map[enemy[i].pos[0], enemy[i].pos[1] + 1] == MONSTER)
                        {
                            if (yDiff < 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (yDiff > 0)
                            {
                                if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (yDiff == 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                        }
                    }
                }
                else if ((xDiff * xDiff) < (yDiff * yDiff))
                {
                    if (yDiff < 0)
                    {
                        if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                        {
                            char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                            map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                            map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                            enemy[i].pos[0] -= 1;
                        }
                        else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                        {
                            death += 1;
                            return;
                        }
                        else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == WALL || map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == MONSTER)
                        {
                            if (xDiff < 0)
                            {
                                if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] - 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] - 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] -= 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if(xDiff > 0)
                            {
                                if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] + 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] + 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] += 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (xDiff == 0)
                            {
                                if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] - 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] - 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] -= 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] + 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] + 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] += 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                        }
                    }
                    else if (yDiff > 0)
                    {
                        if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                        {
                            char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                            map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                            map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                            enemy[i].pos[0] += 1;
                        }
                        else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                        {
                            death += 1;
                            return;
                        }
                        else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == WALL || map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == MONSTER)
                        {
                            if (xDiff < 0)
                            {
                                if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] - 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] - 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] -= 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (xDiff > 0)
                            {
                                if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] + 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] + 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] += 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (xDiff == 0)
                            {
                                if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] - 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] - 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] -= 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0], enemy[i].pos[1] + 1];
                                    map[enemy[i].pos[0], enemy[i].pos[1] + 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[1] += 1;
                                }
                                else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                        }
                    }
                }
                else if ((xDiff * xDiff) == (yDiff * yDiff))
                {
                    if (xDiff < 0)
                    {
                        if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == GROUND)
                        {
                            char temp = map[enemy[i].pos[0], enemy[i].pos[1] - 1];
                            map[enemy[i].pos[0], enemy[i].pos[1] - 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                            map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                            enemy[i].pos[1] -= 1;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == PLAYER)
                        {
                            death += 1;
                            return;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] - 1] == WALL || map[enemy[i].pos[0], enemy[i].pos[1] - 1] == MONSTER)
                        {
                            if (yDiff < 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (yDiff > 0)
                            {
                                if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (yDiff == 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                        }
                    }
                    else if (xDiff > 0)
                    {
                        if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == GROUND)
                        {
                            char temp = map[enemy[i].pos[0], enemy[i].pos[1] + 1];
                            map[enemy[i].pos[0], enemy[i].pos[1] + 1] = map[enemy[i].pos[0], enemy[i].pos[1]];
                            map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                            enemy[i].pos[1] += 1;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == PLAYER)
                        {
                            death += 1;
                            return;
                        }
                        else if (map[enemy[i].pos[0], enemy[i].pos[1] + 1] == WALL || map[enemy[i].pos[0], enemy[i].pos[1] + 1] == MONSTER)
                        {
                            if (yDiff < 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (yDiff > 0)
                            {
                                if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                            else if (yDiff == 0)
                            {
                                if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] - 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] - 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] -= 1;
                                }
                                else if (map[enemy[i].pos[0] - 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == GROUND)
                                {
                                    char temp = map[enemy[i].pos[0] + 1, enemy[i].pos[1]];
                                    map[enemy[i].pos[0] + 1, enemy[i].pos[1]] = map[enemy[i].pos[0], enemy[i].pos[1]];
                                    map[enemy[i].pos[0], enemy[i].pos[1]] = temp;
                                    enemy[i].pos[0] += 1;
                                }
                                else if (map[enemy[i].pos[0] + 1, enemy[i].pos[1]] == PLAYER)
                                {
                                    death += 1;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        void Death()
        {
            map[player_Y, player_X] = DEATH;
            Print_Map();
            Console.SetCursorPosition(0, MAP_SIZE_Y + 2);
            Console.WriteLine("               슬라임에 짓밟혔다!               ");
            Console.WriteLine("               다시하기:r 종료:q                ");
            while (true)
            {
                playerInput = Console.ReadKey();
                if (playerInput.Key == ConsoleKey.R)
                {
                    regame += 1;
                    return;
                }
                else if (playerInput.Key == ConsoleKey.Q)
                {
                    return;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
