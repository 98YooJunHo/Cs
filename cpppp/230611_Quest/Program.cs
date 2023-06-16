using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _230611_Quest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardGame();
        }

        static void CardGame()
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
            int userMoney = 10000;
            string userMoneyInput;


            for (int i = 0; i < cardNumber.Length; i++) // 카드넘버 0~51 기입
            {
                cardNumber[i] = i;
            }

            while (true)
            {
                if(userMoney <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("돈을 모두 잃었습니다...");
                    Console.WriteLine("두들겨 맞고 쫓겨납니다...");
                    break;
                }

                if(userMoney >= 100000)
                {
                    Console.Clear();
                    Console.WriteLine("돈을 모두 따냈습니다!!");
                    Console.WriteLine("또 다른 카드게임장을 찾아 떠납니다");
                    break;
                }

                string userInput;
                int userBet;

                for (int i = 0; i < 10000; i++)           // 카드넘버 셔플
                {
                    int randomcard = random.Next(0, 51);
                    int temp = cardNumber[randomcard];
                    cardNumber[randomcard] = cardNumber[randomcard + 1];
                    cardNumber[randomcard + 1] = temp;
                }

                for (int i = 0; i < draw.Length; i++)       // 카드넘버에서 3개 뽑기
                {
                    draw[i] = cardNumber[i];
                }

                for (int i = 0; i < computerNumber.Length; i++)   // 컴퓨터가 위에서 두 장
                {
                    computerNumber[i] = draw[i];
                }

                for (int i = 0; i < playerNumber.Length; i++)   // 플레이어가 나머지 한 장
                {
                    playerNumber[i] = draw[i + 2];
                }

                for (int i = 1; i < computerNumber.Length; i++)   // 컴퓨터카드 두 장의 값 비교
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
                }                                           // 컴퓨터 카드 두 장의 값 비교 종료

                for (int i = 0; i < computerNumber.Length; i++)   // 컴퓨터 카드 문양값 저장
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
                }                                           // 컴퓨터 카드 문양값 저장종료

                for (int i = 0; i < playerNumber.Length; i++)     // 플레이어 카드 문양값 저장
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
                }                                           // 플레이어 카드 문양값 저장 종료

                Console.WriteLine("현재 소유 금액은 {0}원", userMoney);
                Console.WriteLine("컴퓨터의 두 카드는");

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

                Console.WriteLine("위와 같습니다");
                Console.WriteLine("베팅하시려면 b, 카드 덱을 다시 섞으시려면 r, 종료하시려면 q를 입력하고 엔터를 누르세요");
                Console.WriteLine("베팅 하시겠습니까? 카드 덱을 다시 섞을경우 500원이 차감됩니다");
                userInput = Console.ReadLine();
                Console.Clear();

                if(userInput == "q")
                {
                    Console.WriteLine("게임을 종료합니다");
                    break;
                }
                else if (userInput == "r")
                {
                    userMoney -= 500;
                    continue;
                }
                else if (userInput == "b")
                {
                    while (true)
                    {
                        Console.WriteLine("현재 소유 금액은 {0}원", userMoney);
                        Console.WriteLine("컴퓨터의 두 카드는");

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
                        Console.Clear();

                        if(userBet > userMoney)
                        {
                            Console.WriteLine("현재 소유금액보다 크게 베팅할 수 없습니다");
                            Thread.Sleep(1300);
                            Console.Clear();
                            continue;
                        }
                        else if(userBet < 500)
                        {
                            Console.WriteLine("500원보다 적게 베팅할 수 없습니다");
                            Thread.Sleep(1300);
                            Console.Clear();
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine("현재 소유 금액은 {0}원", userMoney);
                    Console.WriteLine("컴퓨터의 두 카드는");

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
                        userMoney += userBet;
                        Console.WriteLine("계속하시려면 엔터를 누르세요");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("플레이어의 패배입니다...");
                        Console.WriteLine("베팅금액을 전부 잃습니다...");
                        userMoney -= userBet;
                        Console.WriteLine("계속하시려면 엔터를 누르세요");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("올바르지 못한 입력입니다\n괘씸하니 덱을 다시섞습니다");
                    userMoney -= 500;
                    Thread.Sleep(1300);
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
