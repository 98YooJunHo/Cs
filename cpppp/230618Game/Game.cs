using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace _230618Game
{
    public class Game
    {
        System.ConsoleKeyInfo playerInput;
        int userGold = 5000;
        Dictionary<string, int> userInventory = new Dictionary<string, int>();
        Dictionary<string, int> shopInventory = new Dictionary<string, int>();
        int userX;
        int userY;
        int userMaxHp = 30;
        int userHp = 30;
        int userCritRate = 10;
        int userAtk = 5;
        int userArmor = 1;
        char[,] map = new char[28, 40];
        const int MAP_SIZE_Y = 28;
        const int MAP_SIZE_X = 40;
        char mapTile = ' ';
        char mapWall = '■';
        char user = '★';
        char shop = 'ⓒ';
        char casino = '♣';
        char dungeon = 'Ω';
        int quit = 0;
        public void Play_Game()
        {
            Make_Map();
            Make_Shop(ref shopInventory);
            while (true)
            {
                if (quit == 1)
                {
                    Clear();
                    break;
                }
                Print_Map();
                Control_Player();
            }
        }

        void Make_Map()
        {
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (y == 0 || y == MAP_SIZE_Y - 1 || x == 0 || x == MAP_SIZE_X - 1)
                    {
                        map[y, x] = mapWall;
                    }
                    else if (y == (MAP_SIZE_Y / 3) * 2 && x == (MAP_SIZE_X / 2) - 1)
                    {
                        map[y, x] = user;
                        userX = x;
                        userY = y;
                    }
                    else if (y == (MAP_SIZE_Y / 2) && x == (MAP_SIZE_X / 4) - 1)
                    {
                        map[y, x] = shop;
                    }
                    else if (y == (MAP_SIZE_Y / 2) && x == (MAP_SIZE_X / 4) * 3 - 1)
                    {
                        map[y, x] = casino;
                    }
                    else if (y == (MAP_SIZE_Y / 3) && x == (MAP_SIZE_X / 2) - 1)
                    {
                        map[y, x] = dungeon;
                    }
                    else
                    {
                        map[y, x] = mapTile;
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
                    if (map[y, x] == user)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == casino)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == dungeon)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0} ", map[y, x]);
                        Console.ResetColor();
                    }
                    else if (map[y, x] == shop)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Print_Status(userHp, userMaxHp, userAtk, userArmor, userCritRate, userGold);
            Console.SetCursorPosition(0, 29);
            Console.Write("|  ⓒ:상점, ♣:도박장, Ω:던전  |  w,a,s,d로 이동  |  i:인벤토리  |  q:종료  |");
        }

        public void Clear()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    "); Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    "); Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    "); Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.WriteLine("                                                                                                    ");
            Console.SetCursorPosition(0, 0);
        }

        void Control_Player()
        {
            playerInput = Console.ReadKey();
            char temp;
            if (playerInput.KeyChar == 'q')
            {
                quit = 1;
                Clear();
                Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                Console.WriteLine("잠시 후 게임을 종료합니다");
                Thread.Sleep(1000);
                return;
            }
            else if (playerInput.KeyChar == 'w')
            {
                if (map[userY - 1, userX] == casino)
                {
                    CardGame(ref userGold);
                }
                else if (map[userY - 1, userX] == shop)
                {
                    Shopping(ref userGold, ref userInventory);
                }
                else if (map[userY - 1, userX] == dungeon)
                {
                    Dungeon();
                }
                else if (map[userY - 1, userX] == ' ')
                {
                    temp = map[userY - 1, userX];
                    map[userY - 1, userX] = map[userY, userX];
                    map[userY, userX] = temp;
                    userY -= 1;
                }
                else { /*pass*/ }
            }
            else if (playerInput.KeyChar == 's')
            {
                if (map[userY + 1, userX] == casino)
                {
                    CardGame(ref userGold);
                }
                else if (map[userY + 1, userX] == shop)
                {
                    Shopping(ref userGold, ref userInventory);
                }
                else if (map[userY + 1, userX] == dungeon)
                {
                    Dungeon();
                }
                else if (map[userY + 1, userX] == ' ')
                {
                    temp = map[userY + 1, userX];
                    map[userY + 1, userX] = map[userY, userX];
                    map[userY, userX] = temp;
                    userY += 1;
                }
                else { /*pass*/ }
            }
            else if (playerInput.KeyChar == 'a')
            {
                if (map[userY, userX - 1] == casino)
                {
                    CardGame(ref userGold);
                }
                else if (map[userY, userX - 1] == shop)
                {
                    Shopping(ref userGold, ref userInventory);
                }
                else if (map[userY, userX - 1] == dungeon)
                {
                    Dungeon();
                }
                else if (map[userY, userX - 1] == ' ')
                {
                    temp = map[userY, userX - 1];
                    map[userY, userX - 1] = map[userY, userX];
                    map[userY, userX] = temp;
                    userX -= 1;
                }
                else { /*pass*/ }
            }
            else if (playerInput.KeyChar == 'd')
            {
                if (map[userY, userX + 1] == casino)
                {
                    CardGame(ref userGold);
                }
                else if (map[userY, userX + 1] == shop)
                {
                    Shopping(ref userGold, ref userInventory);
                }
                else if (map[userY, userX + 1] == dungeon)
                {
                    Dungeon();
                }
                else if (map[userY, userX + 1] == ' ')
                {
                    temp = map[userY, userX + 1];
                    map[userY, userX + 1] = map[userY, userX];
                    map[userY, userX] = temp;
                    userX += 1;
                }
                else { /*pass*/ }
            }
            else if (playerInput.KeyChar == 'i')
            {
                Using_Inventory();
            }
            else { /*pass*/ }
        }

        void Print_Status(int hp, int mHp, int atk, int arm, int cri, int money)
        {
            Console.Write("| 체력:{0}/{1} | 공격력:{2} | 방어력:{3} | 치명타율:{4} | 소지금:{5} |", hp, mHp, atk, arm, cri, money);
        }

        void CardGame(ref int money)
        {
            Random random = new Random();
            int[] cardNumber = new int[52];
            string[] cards = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] cardPattern = { "♣", "♥", "◆", "♠" };  // 카드넘버 /13 해서 문양 넣음 뒤에 있는 문양 일수록 더 높음
            int[] draw = new int[3];
            int[] playerNumber = new int[1];
            string[] playerPattern = new string[1];
            int[] computerNumber = new int[2];
            string[] computerPattern = new string[2];
            string userMoneyInput;


            for (int i = 0; i < cardNumber.Length; i++) // 카드넘버 0~51 기입
            {
                cardNumber[i] = i;
            }

            while (true)
            {
                if (money < 500)
                {
                    Clear();
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.Write("베팅하기에 충분한 돈이 없습니다");
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2);
                    Console.Write("두들겨 맞고 쫓겨납니다.......");
                    Thread.Sleep(500);
                    Clear();
                    break;
                }

                int userBet;

                // 카드넘버 셔플
                for (int i = 0; i < 10000; i++)
                {
                    int randomcard = random.Next(0, 51);
                    int temp = cardNumber[randomcard];
                    cardNumber[randomcard] = cardNumber[randomcard + 1];
                    cardNumber[randomcard + 1] = temp;
                }

                // 카드넘버에서 3개 뽑기
                for (int i = 0; i < draw.Length; i++)
                {
                    draw[i] = cardNumber[i];
                }

                // 컴퓨터가 위에서 두 장
                for (int i = 0; i < computerNumber.Length; i++)
                {
                    computerNumber[i] = draw[i];
                }

                // 플레이어가 나머지 한 장
                for (int i = 0; i < playerNumber.Length; i++)
                {
                    playerNumber[i] = draw[i + 2];
                }

                // 컴퓨터카드 두 장의 값 비교
                for (int i = 1; i < computerNumber.Length; i++)
                {
                    if (((computerNumber[i]) % 13) == ((computerNumber[i - 1]) % 13))   // 두 장의 %13한 수 =(진짜수) 가 같다면
                    {
                        if (((computerNumber[i]) / 13) < ((computerNumber[i - 1]) / 13))     // 두 장의 문양 비교후 뒷장의 문양이 작다면 섞음
                        {
                            int temp = computerNumber[i - 1];
                            computerNumber[i - 1] = computerNumber[i];
                            computerNumber[i] = temp;
                        }
                    }

                    if (((computerNumber[i]) % 13) < ((computerNumber[i - 1]) % 13))    // 두 장의 %13한 수 = (진짜수) 가  뒷장이 작다면 섞음
                    {
                        int temp = computerNumber[i - 1];
                        computerNumber[i - 1] = computerNumber[i];
                        computerNumber[i] = temp;
                    }
                }

                // 컴퓨터 카드 문양값 저장
                for (int i = 0; i < computerNumber.Length; i++)
                {
                    if ((computerNumber[i]) / 13 == 0)
                    {
                        computerPattern[i] = cardPattern[0];
                    }
                    if ((computerNumber[i]) / 13 == 1)
                    {
                        computerPattern[i] = cardPattern[1];
                    }
                    if ((computerNumber[i]) / 13 == 2)
                    {
                        computerPattern[i] = cardPattern[2];
                    }
                    if ((computerNumber[i]) / 13 == 3)
                    {
                        computerPattern[i] = cardPattern[3];
                    }
                }

                // 플레이어 카드 문양값 저장
                for (int i = 0; i < playerNumber.Length; i++)
                {
                    if ((playerNumber[i]) / 13 == 0)
                    {
                        playerPattern[i] = cardPattern[0];
                    }
                    if ((playerNumber[i]) / 13 == 1)
                    {
                        playerPattern[i] = cardPattern[1];
                    }
                    if ((playerNumber[i]) / 13 == 2)
                    {
                        playerPattern[i] = cardPattern[2];
                    }
                    if ((playerNumber[i]) / 13 == 3)
                    {
                        playerPattern[i] = cardPattern[3];
                    }
                }

                Clear();
                Console.WriteLine("현재 소유 금액은 {0}원", money);
                Console.WriteLine("컴퓨터의 두 카드는");

                // 컴퓨터 카드 이미지 출력
                if ((computerNumber[0] % 13) == 9 && (computerNumber[1] % 13) == 9)
                {
                    Console.WriteLine("┌───────────┐     ┌───────────┐");
                    Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("│{0}         │     │{1}         │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│         {0}│     │         {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("└───────────┘     └───────────┘");
                }
                else if ((computerNumber[0] % 13) == 9)
                {
                    Console.WriteLine("┌───────────┐     ┌───────────┐");
                    Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("│{0}         │     │{1}          │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│         {0}│     │          {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("└───────────┘     └───────────┘");
                }
                else if ((computerNumber[1] % 13) == 9)
                {
                    Console.WriteLine("┌───────────┐     ┌───────────┐");
                    Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("│{0}          │     │{1}         │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│          {0}│     │         {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("└───────────┘     └───────────┘");
                }
                else
                {
                    Console.WriteLine("┌───────────┐     ┌───────────┐");
                    Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("│{0}          │     │{1}          │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│           │     │           │");
                    Console.WriteLine("│          {0}│     │          {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                    Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                    Console.WriteLine("└───────────┘     └───────────┘");
                }

                Console.WriteLine("위와 같습니다, 들어온후 베팅없이 바로 종료시 500원이 차감됩니다");
                Console.WriteLine("베팅하시려면 b, 카드 덱을 다시 섞으시려면 r, 종료하시려면 q를 입력하세요");
                Console.WriteLine("베팅 하시겠습니까? 카드 덱을 다시 섞을경우 500원이 차감됩니다");
                playerInput = Console.ReadKey();
                Clear();

                if (playerInput.KeyChar == 'q')
                {
                    money -= 500;
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.Write("카지노를 나갑니다");
                    Thread.Sleep(500);
                    Clear();
                    break;
                }
                else if (playerInput.KeyChar == 'r')
                {
                    money -= 500;
                    continue;
                }
                else if (playerInput.KeyChar == 'b')
                {
                    while (true)
                    {
                        Console.WriteLine("현재 소유 금액은 {0}원", money);
                        Console.WriteLine("컴퓨터의 두 카드는");

                        // 컴퓨터 카드 이미지 출력
                        if ((computerNumber[0] % 13) == 9 && (computerNumber[1] % 13) == 9)
                        {
                            Console.WriteLine("┌───────────┐     ┌───────────┐");
                            Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("│{0}         │     │{1}         │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│         {0}│     │         {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("└───────────┘     └───────────┘");
                        }
                        else if ((computerNumber[0] % 13) == 9)
                        {
                            Console.WriteLine("┌───────────┐     ┌───────────┐");
                            Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("│{0}         │     │{1}          │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│         {0}│     │          {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("└───────────┘     └───────────┘");
                        }
                        else if ((computerNumber[1] % 13) == 9)
                        {
                            Console.WriteLine("┌───────────┐     ┌───────────┐");
                            Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("│{0}          │     │{1}         │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│          {0}│     │         {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("└───────────┘     └───────────┘");
                        }
                        else
                        {
                            Console.WriteLine("┌───────────┐     ┌───────────┐");
                            Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("│{0}          │     │{1}          │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│           │     │           │");
                            Console.WriteLine("│          {0}│     │          {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                            Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                            Console.WriteLine("└───────────┘     └───────────┘");
                        }

                        Console.WriteLine("베팅하실 금액을 입력하신후 엔터를 누르세요");
                        userMoneyInput = Console.ReadLine();
                        int.TryParse(userMoneyInput, out userBet);
                        Clear();

                        if (userBet > money)
                        {
                            Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                            Console.WriteLine("현재 소유금액보다 크게 베팅할 수 없습니다");
                            Thread.Sleep(500);
                            Clear();
                            continue;
                        }
                        else if (userBet < 500)
                        {
                            Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                            Console.WriteLine("500원보다 적게 베팅할 수 없습니다");
                            Thread.Sleep(500);
                            Clear();
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine("현재 소유 금액은 {0}원", money);
                    Console.WriteLine("컴퓨터의 두 카드는");

                    // 컴퓨터 카드 이미지 출력
                    if ((computerNumber[0] % 13 == 9) && (computerNumber[1] % 13) == 9)
                    {
                        Console.WriteLine("┌───────────┐     ┌───────────┐");
                        Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("│{0}         │     │{1}         │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│         {0}│     │         {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("└───────────┘     └───────────┘");
                    }
                    else if ((computerNumber[0] % 13) == 9)
                    {
                        Console.WriteLine("┌───────────┐     ┌───────────┐");
                        Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("│{0}         │     │{1}          │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│         {0}│     │          {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("└───────────┘     └───────────┘");
                    }
                    else if ((computerNumber[1] % 13) == 9)
                    {
                        Console.WriteLine("┌───────────┐     ┌───────────┐");
                        Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("│{0}          │     │{1}         │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│          {0}│     │         {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("└───────────┘     └───────────┘");
                    }
                    else
                    {
                        Console.WriteLine("┌───────────┐     ┌───────────┐");
                        Console.WriteLine("│{0}          │     │{1}          │", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("│{0}          │     │{1}          │", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│           │     │           │");
                        Console.WriteLine("│          {0}│     │          {1}│", cards[computerNumber[0] % 13], cards[computerNumber[1] % 13]);
                        Console.WriteLine("│          {0}│     │          {1}│", computerPattern[0], computerPattern[1]);
                        Console.WriteLine("└───────────┘     └───────────┘");
                    }

                    Console.WriteLine("플레이어의 카드는");

                    // 유저 카드 이미지 출력
                    if ((playerNumber[0] % 13) == 9)
                    {
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│{0}          │", playerPattern[0]);
                        Console.WriteLine("│{0}         │", cards[playerNumber[0] % 13]);
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│         {0}│", cards[playerNumber[0] % 13]);
                        Console.WriteLine("│          {0}│", playerPattern[0]);
                        Console.WriteLine("└───────────┘");
                    }
                    else
                    {
                        Console.WriteLine("┌───────────┐");
                        Console.WriteLine("│{0}          │", playerPattern[0]);
                        Console.WriteLine("│{0}          │", cards[playerNumber[0] % 13]);
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│           │");
                        Console.WriteLine("│          {0}│", cards[playerNumber[0] % 13]);
                        Console.WriteLine("│          {0}│", playerPattern[0]);
                        Console.WriteLine("└───────────┘");
                    }

                    Console.WriteLine("이므로");

                    if ((computerNumber[0] % 13) < (playerNumber[0] % 13) && (playerNumber[0] % 13) < (computerNumber[1] % 13))
                    {
                        Console.WriteLine("플레이어의 승리입니다!");
                        Console.WriteLine("베팅금액의 2배를 획득합니다!");
                        money += userBet;
                        Console.WriteLine("계속하시려면 엔터를 누르세요");
                        Console.ReadLine();
                        Clear();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("플레이어의 패배입니다...");
                        Console.WriteLine("베팅금액을 전부 잃습니다...");
                        money -= userBet;
                        Console.WriteLine("계속하시려면 엔터를 누르세요");
                        Console.ReadLine();
                        Clear();
                        continue;
                    }
                }
                else
                {
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.Write("올바르지 못한 입력입니다");
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2);
                    Console.Write("괘씸하니 덱을 다시섞습니다");
                    money -= 500;
                    Thread.Sleep(500);
                    Clear();
                    continue;
                }
            }
        }

        void Make_Shop(ref Dictionary<string, int> shopItems)
        {
            shopItems.Add("strelixir", 5000);
            shopItems.Add("conelixir", 5000);
            shopItems.Add("madelixir", 5000);
            shopItems.Add("defelixir", 5000);
            shopItems.Add("healingpotion", 1000);
        }

        void Print_Shop()
        {
            Clear();
            foreach (KeyValuePair<string, int> item in shopInventory)
            {
                Console.WriteLine("{0,6} : {1,4}원", item.Key, item.Value);
            }
            Console.WriteLine("\n소지금액 : {0}원\n", userGold);
        }

        void Print_Inventory()
        {
            Clear();
            foreach (KeyValuePair<string, int> item in userInventory)
            {
                Console.WriteLine("{0,6} : {1,2}개", item.Key, item.Value);
            }
            Console.WriteLine("\n소지금액 : {0}원\n", userGold);
        }

        void Using_Inventory()
        {
            while (true)
            {
                string tempStr = "";
                int tempValue = 0;
                string userInput;
                Print_Inventory();
                Console.WriteLine("나가시려면 q를, 아니라면 사용하고자 하는 아이템의 이름을 입력하고 엔터를 누르세요");
                userInput = Console.ReadLine();
                Clear();

                if (userInput == "q")
                {
                    break;
                }

                else if (userInput == "strelixir")
                {
                    foreach (KeyValuePair<string, int> item in userInventory)
                    {
                        if (item.Key == "strelixir")
                        {
                            tempStr = item.Key;
                            tempValue = item.Value;
                        }
                    }

                    if (tempStr != "strelixir")
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3)*2, MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당아이템이 존재하지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3)*2, MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 사용하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "strelixir")
                            {
                                userInventory[item.Key] -= 1;
                                userAtk += 1;

                                if (userInventory[item.Key] == 0)
                                {
                                    userInventory.Remove(item.Key);
                                }

                                break;
                            }
                            else { /* pass */}
                        }
                    }
                }
                else if (userInput == "conelixir")
                {
                    foreach (KeyValuePair<string, int> item in userInventory)
                    {
                        if (item.Key == "conelixir")
                        {
                            tempStr = item.Key;
                            tempValue = item.Value;
                        }
                    }

                    if (tempStr != "conelixir")
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당아이템이 존재하지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 사용하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "conelixir")
                            {
                                userInventory[item.Key] -= 1;
                                userMaxHp += 3;

                                if (userInventory[item.Key] == 0)
                                {
                                    userInventory.Remove(item.Key);
                                }

                                break;
                            }
                            else { /* pass */}
                        }
                    }
                }
                else if (userInput == "madelixir")
                {
                    foreach (KeyValuePair<string, int> item in userInventory)
                    {
                        if (item.Key == "madelixir")
                        {
                            tempStr = item.Key;
                            tempValue = item.Value;
                        }
                    }

                    if (tempStr != "madelixir")
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당아이템이 존재하지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 사용하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "madelixir")
                            {
                                userInventory[item.Key] -= 1;
                                userCritRate += 2;

                                if (userCritRate > 100)
                                {
                                    userCritRate = 100;
                                }

                                if (userInventory[item.Key] == 0)
                                {
                                    userInventory.Remove(item.Key);
                                }

                                break;
                            }
                            else { /* pass */}
                        }
                    }
                }
                else if (userInput == "defelixir")
                {
                    foreach (KeyValuePair<string, int> item in userInventory)
                    {
                        if (item.Key == "defelixir")
                        {
                            tempStr = item.Key;
                            tempValue = item.Value;
                        }
                    }

                    if (tempStr != "defelixir")
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당아이템이 존재하지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 사용하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "defelixir")
                            {
                                userInventory[item.Key] -= 1;
                                userArmor += 1;

                                if (userInventory[item.Key] == 0)
                                {
                                    userInventory.Remove(item.Key);
                                }

                                break;
                            }
                            else { /* pass */}
                        }
                    }
                }
                else if (userInput == "healingpotion")
                {
                    foreach (KeyValuePair<string, int> item in userInventory)
                    {
                        if (item.Key == "healingpotion")
                        {
                            tempStr = item.Key;
                            tempValue = item.Value;
                        }
                    }

                    if (tempStr != "healingpotion")
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당아이템이 존재하지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 사용하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "healingpotion")
                            {
                                userInventory[item.Key] -= 1;
                                userHp += 5;

                                if (userHp > userMaxHp)
                                {
                                    userHp = userMaxHp;
                                }

                                if (userInventory[item.Key] == 0)
                                {
                                    userInventory.Remove(item.Key);
                                }

                                break;
                            }
                            else { /* pass */}
                        }
                    }
                }
                else
                {
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("올바른 입력을 하세요!");
                    Thread.Sleep(500);
                }
            }
        }

        void Shopping(ref int money, ref Dictionary<string, int> inventory)
        {
            while (true)
            {
                string tempStr = "";
                int tempPrice = 0;
                string userInput;
                Print_Shop();
                Console.WriteLine("나가시려면 q를, 아니라면 사고자 하는 아이템의 이름을 입력하고 엔터를 누르세요");
                userInput = Console.ReadLine();
                Clear();

                if (userInput == "q")
                {
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("상점에서 나갑니다");
                    Thread.Sleep(500);
                    break;
                }
                else if (userInput == "strelixir")
                {
                    foreach (KeyValuePair<string, int> item in shopInventory)
                    {
                        if (item.Key == "strelixir")
                        {
                            tempStr = item.Key;
                            tempPrice = item.Value;
                        }
                    }

                    if (money < tempPrice)
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당 아이템을 구매하기에 충분한 돈을 소지하고 있지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 구매하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        int isThere = 0;
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "strelixir")
                            {
                                money -= tempPrice;
                                userInventory[item.Key] += 1;
                                isThere += 1;
                                break;
                            }
                            else { /* pass */}
                        }

                        if (isThere == 0)
                        {
                            money -= tempPrice;
                            userInventory.Add(tempStr, 1);
                        }
                    }
                }
                else if (userInput == "conelixir")
                {
                    foreach (KeyValuePair<string, int> item in shopInventory)
                    {
                        if (item.Key == "conelixir")
                        {
                            tempStr = item.Key;
                            tempPrice = item.Value;
                        }
                    }

                    if (money < tempPrice)
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당 아이템을 구매하기에 충분한 돈을 소지하고 있지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 구매하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        int isThere = 0;
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "conelixir")
                            {
                                money -= tempPrice;
                                userInventory[item.Key] += 1;
                                isThere += 1;
                                break;
                            }
                            else { /* pass */}
                        }

                        if (isThere == 0)
                        {
                            money -= tempPrice;
                            userInventory.Add(tempStr, 1);
                        }
                    }
                }
                else if (userInput == "madelixir")
                {
                    foreach (KeyValuePair<string, int> item in shopInventory)
                    {
                        if (item.Key == "madelixir")
                        {
                            tempStr = item.Key;
                            tempPrice = item.Value;
                        }
                    }

                    if (money < tempPrice)
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당 아이템을 구매하기에 충분한 돈을 소지하고 있지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 구매하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        int isThere = 0;
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "madelixir")
                            {
                                money -= tempPrice;
                                userInventory[item.Key] += 1;
                                isThere += 1;
                                break;
                            }
                            else { /* pass */}
                        }

                        if (isThere == 0)
                        {
                            money -= tempPrice;
                            userInventory.Add(tempStr, 1);
                        }
                    }
                }
                else if (userInput == "defelixir")
                {
                    foreach (KeyValuePair<string, int> item in shopInventory)
                    {
                        if (item.Key == "defelixir")
                        {
                            tempStr = item.Key;
                            tempPrice = item.Value;
                        }
                    }

                    if (money < tempPrice)
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당 아이템을 구매하기에 충분한 돈을 소지하고 있지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 구매하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        int isThere = 0;
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "defelixir")
                            {
                                money -= tempPrice;
                                userInventory[item.Key] += 1;
                                isThere += 1;
                                break;
                            }
                            else { /* pass */}
                        }

                        if (isThere == 0)
                        {
                            money -= tempPrice;
                            userInventory.Add(tempStr, 1);
                        }
                    }
                }
                else if (userInput == "healingpotion")
                {
                    foreach (KeyValuePair<string, int> item in shopInventory)
                    {
                        if (item.Key == "healingpotion")
                        {
                            tempStr = item.Key;
                            tempPrice = item.Value;
                        }
                    }

                    if (money < tempPrice)
                    {
                        Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                        Console.WriteLine("해당 아이템을 구매하기에 충분한 돈을 소지하고 있지 않습니다");
                        Thread.Sleep(500);
                        continue;
                    }

                    Console.SetCursorPosition((MAP_SIZE_X / 3), MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("정말로 {0,6}을 구매하시겠습니까? 아니라면 q를 누르세요", tempStr);
                    playerInput = Console.ReadKey();
                    if (playerInput.KeyChar == 'q')
                    {
                        continue;
                    }
                    else
                    {
                        int isThere = 0;
                        foreach (KeyValuePair<string, int> item in userInventory)
                        {
                            if (item.Key == "healingpotion")
                            {
                                money -= tempPrice;
                                userInventory[item.Key] += 1;
                                isThere += 1;
                                break;
                            }
                            else { /* pass */}
                        }

                        if (isThere == 0)
                        {
                            money -= tempPrice;
                            userInventory.Add(tempStr, 1);
                        }
                    }
                }
                else
                {
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.WriteLine("올바른 입력을 하세요!");
                    Thread.Sleep(500);
                }
            }
        }

        void Dungeon()
        {
            Random random = new Random();
            string slime = "슬라임";
            int slimeMaxHp = 13;
            int slimeHp = 13;
            int slimeAtk = 4;
            int slimeArmor = 0;
            int slimeCritRate = 1;
            int slimeGold = 1000;
            int battleCount = 0;

            Clear();

            int fight = random.Next(1, 101);

            if (fight < 41)
            {
                Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                Console.Write("무사히 던전을 탐사하고 나왔습니다");
                Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2);
                Console.Write("    약간의 수확이 있었습니다");
                Thread.Sleep(500);
                userGold += 500;
                return;
            }
            else
            {
                Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                Console.Write("던전의 {0}과 마주쳤습니다!", slime);
                Thread.Sleep(500);
            }

            while (true)
            {
                Clear();

                if(battleCount % 2 == 0)
                {
                    battleCount += 1;
                    int crit = random.Next(1, 101);
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.Write("나의 공격 ");
                    if(crit  <=  userCritRate)
                    {
                        Console.Write("크리티컬!!");
                        slimeHp -= (userAtk * 3) / 2 + slimeArmor;
                        if (slimeHp < 0)
                        {
                            slimeHp = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        slimeHp -= userAtk + slimeArmor;
                        if (slimeHp < 0)
                        { 
                            slimeHp = 0;
                        }
                    }
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2);
                    Console.WriteLine("{0}의 체력:{1}/{2}", slime, slimeHp, slimeMaxHp);
                    Thread.Sleep(700);
                    if(slimeHp == 0)
                    {
                        Clear();
                        Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                        Console.Write("무사히 적을 물리치고 나왔습니다");
                        Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2);
                        Console.Write("    적의 전리품을 획득합니다");
                        Thread.Sleep(500);
                        userGold += slimeGold;
                        return;
                    }
                }
                else
                {
                    battleCount += 1;
                    int crit = random.Next(1, 101);
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                    Console.Write("{0}의 공격 ", slime);
                    if (crit <= slimeCritRate)
                    {
                        Console.Write("크리티컬!!");
                        userHp -= (slimeAtk * 3) / 2 - userArmor;
                        if (userHp <= 0)
                        {
                            userHp = 1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        userHp -= slimeAtk - userArmor;
                        if (userHp <= 0)
                        {
                            userHp = 1;
                        }
                    }
                    Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2);
                    Console.WriteLine("나의 체력:{0}/{1}", userHp, userMaxHp);
                    Thread.Sleep(700);
                    if(userHp == 1)
                    {
                        Clear();
                        Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2 - 1);
                        Console.Write("죽기직전 온 힘을 다해 도망쳐 나왔습니다");
                        Console.SetCursorPosition((MAP_SIZE_X / 3) * 2, MAP_SIZE_Y / 2);
                        Console.Write("피투성이가 된 몸을 이끌고 빠져나옵니다");
                        Thread.Sleep(500);
                        return;
                    }
                }

            }

        }
    }
}
