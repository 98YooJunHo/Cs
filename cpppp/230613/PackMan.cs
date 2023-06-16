using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Timers;

namespace _230613
{
    public class PackMan
    {
        System.ConsoleKeyInfo playerInput;
        int playerX;
        int playerY;
        int realTime;
        string realSecond;
        int Count = 1;
        System.Threading.Timer timer;
        char[,] map = new char[17, 17];
        int mapSize;
        int score = 0;
        int coinCount = 0;
        bool mapOn = false;
        bool scoreOn = false;

        public void PackGame()
        {
            string playerStr;

            Console.WriteLine("맵의 크기를 입력하고 엔터를 누르세요(5~15)");
            playerStr = Console.ReadLine();
            int.TryParse(playerStr, out mapSize);

            int saveTime = 0;
            Make_Map(mapSize, ref map);
            string saveSecond;
            saveSecond = DateTime.Now.ToString("ss");
            int.TryParse(saveSecond, out saveTime);
            timer = new System.Threading.Timer(Make_Coin, null, 100, 3000);

            while (true)
            {
                //if (Count%(mapSize-2) == 0)
                //{
                //    Make_Coin(ref map, ref mapSize);
                //    coinCount += 1;
                //}

                Print_CoinAndScore(ref coinCount, ref score);
                Print_Map(mapSize, ref map);
                Move_Player(ref map, ref score, ref coinCount);
            }
        }
        public void Make_Map(int mapsize, ref char[,] ptrMap)
        {
            playerX = mapsize / 2 + 1;
            playerY = mapsize / 2 + 1;

            for (int y = 0; y < mapsize + 2; y++)
            {
                for (int x = 0; x < mapsize + 2; x++)
                {
                    ptrMap[y, x] = '#';
                }
            }

            for (int y = 1; y < mapsize + 1; y++)
            {
                for (int x = 1; x < mapsize + 1; x++)
                {
                    ptrMap[y, x] = '*';
                }
            }

            ptrMap[playerY, playerX] = '◎';
        }

        public void Print_Map(int mapSize, ref char[,] ptrMap)
        {

            if (mapOn == true)
            {
                return;
            }

            mapOn = true;
            Console.SetCursorPosition(0, 3);
            for (int y = 0; y < mapSize + 2; y++)
            {
                for (int x = 0; x < mapSize + 2; x++)
                {
                    if (ptrMap[y, x] == '◎')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0} ", ptrMap[y, x]);
                        Console.ResetColor();
                    }
                    else if (ptrMap[y, x] == '$')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", ptrMap[y, x]);
                        Console.ResetColor();
                    }
                    else if (ptrMap[y, x] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", ptrMap[y, x]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0} ", ptrMap[y, x]);
                    }
                }
                Console.WriteLine();
            }
            mapOn = false;

        }
        
        public void Print_Map()
        {
            if (mapOn == true)
            {
                return;
            }

            mapOn = true;
            Console.SetCursorPosition(0, 3);
            for (int y = 0; y < mapSize + 2; y++)
            {
                for (int x = 0; x < mapSize + 2; x++)
                {
                    if (map[y, x] == '◎')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '$')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == '#')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
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
            mapOn = false;

        }

        public void Print_CoinAndScore(ref int coinCount, ref int score)
        {
            if (scoreOn == true)
            {
                return;
            }

            scoreOn = true;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("맵에 있는 코인 수 : {0} 현재 점수 : {1}                 ", coinCount, score);
            scoreOn = false;

        }

        public void Print_CoinAndScore()
        {
            if (scoreOn == true)
            {
                return;
            }

            scoreOn = true;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("맵에 있는 코인 수 : {0} 현재 점수 : {1}                 ", coinCount, score);
            scoreOn = false;

        }

        public void Move_Player(ref char[,] ptrMap, ref int score, ref int count)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("위 w, 왼쪽 a, 아래 s, 오른쪽 d : ");
            playerInput = Console.ReadKey();

            if (playerInput.KeyChar == 'w') // 위로 이동
            {
                if (ptrMap[playerY - 1, playerX] == '#')
                {
                    return;
                }
                else if (ptrMap[playerY - 1, playerX] == '$')
                {
                    score += 100;
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = '*';
                    ptrMap[playerY - 1, playerX] = temp;
                    playerY -= 1;
                    count -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = ptrMap[playerY - 1, playerX];
                    ptrMap[playerY - 1, playerX] = temp;
                    playerY -= 1;
                    Count += 1;
                }
            }
            else if (playerInput.KeyChar == 's') // 아래로 이동
            {
                if (ptrMap[playerY + 1, playerX] == '#')
                {
                    return;
                }
                else if (ptrMap[playerY + 1, playerX] == '$')
                {
                    score += 100;
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = '*';
                    ptrMap[playerY + 1, playerX] = temp;
                    playerY += 1;
                    count -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = ptrMap[playerY + 1, playerX];
                    ptrMap[playerY + 1, playerX] = temp;
                    playerY += 1;
                    Count += 1;
                }
            }
            else if (playerInput.KeyChar == 'a') // 왼쪽으로 이동
            {
                if (ptrMap[playerY, playerX - 1] == '#')
                {
                    return;
                }
                else if (ptrMap[playerY, playerX - 1] == '$')
                {
                    score += 100;
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = '*';
                    ptrMap[playerY, playerX - 1] = temp;
                    playerX -= 1;
                    count -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = ptrMap[playerY, playerX - 1];
                    ptrMap[playerY, playerX - 1] = temp;
                    playerX -= 1;
                    Count += 1;
                }
            }
            else if (playerInput.KeyChar == 'd') // 오른쪽으로 이동
            {
                if (ptrMap[playerY, playerX + 1] == '#')
                {
                    return;
                }
                else if (ptrMap[playerY, playerX + 1] == '$')
                {
                    score += 100;
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = '*';
                    ptrMap[playerY, playerX + 1] = temp;
                    playerX += 1;
                    count -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = ptrMap[playerY, playerX];
                    ptrMap[playerY, playerX] = ptrMap[playerY, playerX + 1];
                    ptrMap[playerY, playerX + 1] = temp;
                    playerX += 1;
                    Count += 1;
                }
            }
            else
            {
                return;
            }
        }

        public void Move_Player()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("위 w, 왼쪽 a, 아래 s, 오른쪽 d : ");
            playerInput = Console.ReadKey();

            if (playerInput.KeyChar == 'w') // 위로 이동
            {
                if (map[playerY - 1, playerX] == '#')
                {
                    return;
                }
                else if (map[playerY - 1, playerX] == '$')
                {
                    score += 100;
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = '*';
                    map[playerY - 1, playerX] = temp;
                    playerY -= 1;
                    coinCount -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY - 1, playerX];
                    map[playerY - 1, playerX] = temp;
                    playerY -= 1;
                    Count += 1;
                }
            }
            else if (playerInput.KeyChar == 's') // 아래로 이동
            {
                if (map[playerY + 1, playerX] == '#')
                {
                    return;
                }
                else if (map[playerY + 1, playerX] == '$')
                {
                    score += 100;
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = '*';
                    map[playerY + 1, playerX] = temp;
                    playerY += 1;
                    coinCount -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY + 1, playerX];
                    map[playerY + 1, playerX] = temp;
                    playerY += 1;
                    Count += 1;
                }
            }
            else if (playerInput.KeyChar == 'a') // 왼쪽으로 이동
            {
                if (map[playerY, playerX - 1] == '#')
                {
                    return;
                }
                else if (map[playerY, playerX - 1] == '$')
                {
                    score += 100;
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = '*';
                    map[playerY, playerX - 1] = temp;
                    playerX -= 1;
                    coinCount -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY, playerX - 1];
                    map[playerY, playerX - 1] = temp;
                    playerX -= 1;
                    Count += 1;
                }
            }
            else if (playerInput.KeyChar == 'd') // 오른쪽으로 이동
            {
                if (map[playerY, playerX + 1] == '#')
                {
                    return;
                }
                else if (map[playerY, playerX + 1] == '$')
                {
                    score += 100;
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = '*';
                    map[playerY, playerX + 1] = temp;
                    playerX += 1;
                    coinCount -= 1;
                    Count += 1;
                }
                else
                {
                    char temp;
                    temp = map[playerY, playerX];
                    map[playerY, playerX] = map[playerY, playerX + 1];
                    map[playerY, playerX + 1] = temp;
                    playerX += 1;
                    Count += 1;
                }
            }
            else
            {
                return;
            }
        }

        public void Make_Coin(ref char[,] ptrMap, ref int size) 
        {
            Random random = new Random();
            int randomIndex = random.Next(0, (size + 2) * (size + 2));
            while (true)
            {
                if (ptrMap[(randomIndex / (size + 2)), (randomIndex % (size + 2))] == '*')
                {
                    ptrMap[(randomIndex / (size + 2)), (randomIndex % (size + 2))] = '$';
                    break;
                }
                else
                {
                    randomIndex = random.Next(0, (size + 2) * (size + 2));
                    continue;
                }
            }
        }

        public void Make_Coin(object state)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, (mapSize + 2) * (mapSize + 2));

            while (true)
            {
                if (map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] == '*')
                {
                    map[(randomIndex / (mapSize + 2)), (randomIndex % (mapSize + 2))] = '$';
                    coinCount += 1;
                    break;
                }
                else
                {
                    randomIndex = random.Next(0, (mapSize + 2) * (mapSize + 2));
                    continue;
                }
            }

            if (mapOn == false)
            {
                Print_Map();
            }

            if (scoreOn == false)
            {
                Print_CoinAndScore();
            }

            Console.SetCursorPosition(0, 1);
            Console.Write("위 w, 왼쪽 a, 아래 s, 오른쪽 d : ");
        }
    }
}
