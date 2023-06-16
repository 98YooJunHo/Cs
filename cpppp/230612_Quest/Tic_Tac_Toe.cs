using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _230612_Quest
{
    public class Tic_Tac_Toe
    {
        char[,] _map = new char[3, 3];
        string userStr;
        char userInput = 'O';
        char computerInput = 'X';
        int playerWin = 0;
        int computerWin = 0;
        int userKeyInt = 0;
        int draw = 0;

        public void Make_Map()
        {
            for(int y = 0; y < 3; y++)
            {
                for(int x = 0; x < 3; x++)
                {
                    _map[y, x] = ' ';
                }
            }
        }

        public void Print_Map(ref char[,] ptrmap)
        {
            Console.WriteLine("┌───┐┌───┐┌───┐");
            Console.WriteLine("│ {0} ││ {1} ││ {2} │", ptrmap[0, 0], ptrmap[0, 1], ptrmap[0, 2]);
            Console.WriteLine("└───┘└───┘└───┘");
            Console.WriteLine("┌───┐┌───┐┌───┐");
            Console.WriteLine("│ {0} ││ {1} ││ {2} │", ptrmap[1, 0], ptrmap[1, 1], ptrmap[1, 2]);
            Console.WriteLine("└───┘└───┘└───┘");
            Console.WriteLine("┌───┐┌───┐┌───┐");
            Console.WriteLine("│ {0} ││ {1} ││ {2} │", ptrmap[2, 0], ptrmap[2, 1], ptrmap[2, 2]);
            Console.WriteLine("└───┘└───┘└───┘");
        }

        public int Game()
        {
            Make_Map();
            Console.WriteLine("틱택토 게임입니다");
            Console.WriteLine("컴퓨터보다 먼저 빙고를 만들면 승리합니다");
            Console.WriteLine("맨윗줄 세칸 0, 1, 2, 중간줄 3, 4, 5, 마지막줄 6, 7, 8입니다.");
            Console.WriteLine("두기를 원하는 칸의 번호를 입력한후 엔터를 입력하세요");
            while (true)
            {
                Console.SetCursorPosition(0, 4);
                Print_Map(ref _map);
                Random random = new Random();

                userStr = Console.ReadLine();
                int.TryParse(userStr, out userKeyInt);

                if (userKeyInt > 8 || userKeyInt < 0)
                {
                    Console.WriteLine("범위 내의 값을 입력하세요!");
                    Thread.Sleep(1000);
                    continue;
                }

                if (_map[userKeyInt / 3, userKeyInt % 3] == userInput || _map[userKeyInt / 3, userKeyInt % 3] == computerInput)
                {
                    Console.WriteLine("이미 누군가가 둔 곳에 또 둘 수 는 없습니다");
                    Thread.Sleep(1000);
                    continue;
                }
                else
                {
                    _map[userKeyInt / 3, userKeyInt % 3] = userInput;
                }

                Consider_PlayerWin(ref _map);

                if (playerWin == 1)
                {
                    Console.SetCursorPosition(0, 4);
                    Print_Map(ref _map);
                    Console.WriteLine("플레이어 승리!!!");
                    Console.WriteLine("3초후 종료합니다...");
                    Thread.Sleep(3000);
                    return 0;
                }

                Consider_Draw(ref _map);

                if (draw == 1)
                {
                    Console.SetCursorPosition(0, 4);
                    Print_Map(ref _map);
                    Console.WriteLine("무승부 ...");
                    Console.WriteLine("3초후 종료합니다...");
                    Thread.Sleep(3000);
                    return 0;
                }

                while (true)
                {
                    int computerKeyInt = random.Next(0, 9);
                    if (_map[computerKeyInt / 3, computerKeyInt % 3] == userInput || _map[computerKeyInt / 3, computerKeyInt % 3] == computerInput)
                    {
                        continue;
                    }
                    else
                    {
                        _map[computerKeyInt / 3, computerKeyInt % 3] = computerInput;
                        break;
                    }
                }

                Consider_ComputerWin(ref _map);

                if (computerWin == 1)
                {
                    Console.SetCursorPosition(0, 4);
                    Print_Map(ref _map);
                    Console.WriteLine("컴퓨터 승리...");
                    Console.WriteLine("3초후 종료합니다...");
                    Thread.Sleep(3000);
                    return 0;
                }
            }
        }

        public void Consider_PlayerWin(ref char[,] ptrchar)
        {
            for(int y = 0; y < 3; y++)
            {
                int horizonWin = 0;
                for (int x = 0; x < 3; x++)
                {
                    if(ptrchar[x, y] == userInput)
                    {
                        horizonWin += 1;
                    }

                    if(horizonWin == 3)
                    {
                        playerWin = 1;
                    }
                }
            }
            for (int y = 0; y < 3; y++)
            {
                int verticalWin = 0;
                for (int x = 0; x < 3; x++)
                {
                    if (ptrchar[y, x] == userInput)
                    {
                        verticalWin += 1;
                    }

                    if (verticalWin == 3)
                    {
                        playerWin = 1;
                    }
                }
            }
            int diagonalWin = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (y == x)
                    {
                        if (ptrchar[y, x] == userInput)
                        {
                            diagonalWin += 1;
                        }
                    }

                    if (diagonalWin == 3)
                    {
                        playerWin = 1;
                    }
                }
            }
            int diagonalWin2 = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if ((y+x) == 2)
                    {
                        if (ptrchar[y, x] == userInput)
                        {
                            diagonalWin2 += 1;
                        }
                    }

                    if (diagonalWin2 == 3)
                    {
                        playerWin = 1;
                    }
                }
            }
        }

        public void Consider_ComputerWin(ref char[,] ptrchar)
        {
            for (int y = 0; y < 3; y++)
            {
                int horizonWin = 0;
                for (int x = 0; x < 3; x++)
                {
                    if (ptrchar[x, y] == computerInput)
                    {
                        horizonWin += 1;
                    }

                    if (horizonWin == 3)
                    {
                        computerWin = 1;
                    }
                }
            }
            for (int y = 0; y < 3; y++)
            {
                int verticalWin = 0;
                for (int x = 0; x < 3; x++)
                {
                    if (ptrchar[y, x] == computerInput)
                    {
                        verticalWin += 1;
                    }

                    if (verticalWin == 3)
                    {
                        computerWin = 1;
                    }
                }
            }
            int diagonalWin = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (y == x)
                    {
                        if (ptrchar[y, x] == computerInput)
                        {
                            diagonalWin += 1;
                        }
                    }

                    if (diagonalWin == 3)
                    {
                        computerWin = 1;
                    }
                }
            }
            int diagonalWin2 = 0;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if ((y + x) == 2)
                    {
                        if (ptrchar[y, x] == computerInput)
                        {
                            diagonalWin2 += 1;
                        }
                    }

                    if (diagonalWin2 == 3)
                    {
                        computerWin = 1;
                    }
                }
            }
        }

        public void Consider_Draw(ref char[,] ptrchar)
        {
            int drawCount = 0;
            for(int y = 0;y < 3;y++)
            {
                for(int x = 0;x < 3;x++)
                {
                    if (ptrchar[y,x] == computerInput || ptrchar[y,x] == userInput)
                    {
                        drawCount += 1;
                    }
                }
            }

            if(drawCount == 9) 
            {
                draw = 1;
            }
        }
    }
}
