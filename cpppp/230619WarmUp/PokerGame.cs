using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _230619WarmUp
{
    public class PokerGame : CardDeck
    {
        int considerRoyalStraightFlush = 0;
        int considerStraightFlush = 0;
        int considerFourCard = 0;
        int considerFullHouse = 0;
        int considerFlush = 0;
        int considerStraight = 0;
        int considerTriple = 0;
        int considerTwoPair = 0;
        int considerPair = 0;
        int spadeSameCount = 0;
        int diaSameCount = 0;
        int heartSameCount = 0;
        int cloverSameCount = 0;

        int considerPlayerRoyalStraightFlush = 0;
        int considerPlayerStraightFlush = 0;
        int considerPlayerFourCard = 0;
        int considerPlayerFullHouse = 0;
        int considerPlayerFlush = 0;
        int considerPlayerStraight = 0;
        int considerPlayerTriple = 0;
        int considerPlayerTwoPair = 0;
        int considerPlayerPair = 0;
        int playerSpadeSameCount = 0;
        int playerDiaSameCount = 0;
        int playerHeartSameCount = 0;
        int playerCloverSameCount = 0;

        Random random = new Random();
        List<Card> computerCards = new List<Card>();
        List<Card> playerCards = new List<Card>();
        string[] tempPrint;
        int playerLevel;
        int computerLevel;
        System.ConsoleKeyInfo playerInput;
        System.ConsoleKeyInfo playerInput1;

        int playerMoney = 10000;
        int playerBet;

        public void Play_Game()
        {
            Make_Deck();
            while (true)
            {
                Bet();
            }
        }

        // 배팅
        void Bet()
        {
            while (true)
            {
                Draw_Cards();
                Print_TotalCard();
                Consider_ComputerCards();
                Consider_PlayerCards();
                computerLevel = Print_ComputerLevel();
                playerLevel = Print_PlayerLevel();
                Console.SetCursorPosition(0, 15);
                Console.Write("                                                                          ");
                Console.SetCursorPosition(0, 16);
                Console.Write("                                                                          ");
                Console.SetCursorPosition(0, 15);
                Console.Write("베팅하실 금액을 입력하세요 (최소 500원): ");
                int.TryParse(Console.ReadLine(), out playerBet);
                if (playerBet > playerMoney)
                {
                    Console.WriteLine("소지금액 초과로 배팅할 수 없습니다");
                    Thread.Sleep(800);
                    continue;
                }
                else if (playerBet < 500)
                {
                    Console.WriteLine("최소 배팅금액은 500원입니다");
                    Thread.Sleep(800);
                    continue;
                }
                else
                {

                    while (true)
                    {
                        
                        Console.SetCursorPosition(0, 14);
                        Console.Write("                                                                          ");
                        Console.SetCursorPosition(0, 15);
                        Console.Write("                                                                          ");
                        Console.SetCursorPosition(0, 14);
                        Console.Write("다시 받고 싶은 카드 갯수를 입력하세요 (0~2): ");
                        playerInput = Console.ReadKey();
                        if (playerInput.KeyChar == '0')
                        {
                            Sort_PlayerCards();
                            Print_PlayerCard();
                            Consider_PlayerCards();
                            playerLevel = Print_PlayerLevel();
                            break;
                        }
                        else if (playerInput.KeyChar == '1')
                        {
                            while (true)
                            {
                                Console.SetCursorPosition(0, 15);
                                Console.Write("                                                                            ");
                                Console.SetCursorPosition(0, 15);
                                Console.Write("다시 받고 싶은 카드의 번호를 입력하세요 (앞에서부터 1~5): ");
                                playerInput = Console.ReadKey();
                                int player = Convert.ToInt32(Convert.ToString(playerInput.KeyChar));
                                if ((0 < player) && (player < 6))
                                {
                                    playerCards[player - 1] = playerCards[5];
                                    Sort_PlayerCards();
                                    Print_PlayerCard();
                                    Consider_PlayerCards();
                                    playerLevel = Print_PlayerLevel();
                                    break;
                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 15);
                                    Console.Write("                                                                            ");
                                    Console.SetCursorPosition(0, 15);
                                    Console.Write("올바른 값을 입력하세요");
                                    Thread.Sleep(800);
                                    continue;
                                }
                            }
                            break;
                        }
                        else if (playerInput.KeyChar == '2')
                        {
                            while (true)
                            {
                                Console.SetCursorPosition(0, 15);
                                Console.Write("                                                                          ");
                                Console.SetCursorPosition(0, 15);
                                Console.Write("다시 받고 싶은 카드의 번호를 두 번 입력하세요 (앞에서부터 1~5): ");
                                playerInput = Console.ReadKey();
                                Console.Write(" ");
                                playerInput1 = Console.ReadKey();
                                int player, player1;
                                player = Convert.ToInt32(Convert.ToString(playerInput.KeyChar));
                                player1 = Convert.ToInt32(Convert.ToString(playerInput1.KeyChar));
                                if ((0 < player && player < 6) && (0 < player1 && player1 < 6) && (player != player1))
                                {
                                    playerCards[player - 1] = playerCards[5];
                                    playerCards[player1 - 1] = playerCards[6];
                                    Sort_PlayerCards();
                                    Print_PlayerCard();
                                    Consider_PlayerCards();
                                    playerLevel = Print_PlayerLevel();
                                    break;
                                }
                                else
                                {
                                    Console.SetCursorPosition(0, 15);
                                    Console.Write("                                                                             ");
                                    Console.SetCursorPosition(0, 15);
                                    Console.Write("올바른 값을 입력하세요");
                                    Thread.Sleep(800);
                                    continue;
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 15);
                            Console.Write("올바른 값을 입력하세요");
                            Thread.Sleep(800);
                            continue;
                        }
                    }

                    Console.SetCursorPosition(0, 15);
                    Console.Write("                                                                                ");
                    Console.SetCursorPosition(0, 16);
                    Console.Write("                                                                                ");
                    Console.SetCursorPosition(0, 15);

                    if (playerLevel == computerLevel)
                    {
                        Compare();
                        Thread.Sleep(1500);
                        Clear();
                        Clear_Cards();
                        break;
                    }
                    else if (playerLevel > computerLevel)
                    {
                        Console.WriteLine("플레이어의 승리입니다");
                        playerMoney += playerBet;
                        Thread.Sleep(1500);
                        Clear();
                        Clear_Cards();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터의 승리입니다");
                        playerMoney -= playerBet;
                        Thread.Sleep(1500);
                        Clear();
                        Clear_Cards();
                        break;
                    }
                }
            }
        }

        // 동일 족보일시 비교
        void Compare()
        {
            // 다섯 장으로 이루어지는 족보의 경우 플레이어는 다섯 장뿐이기에 가장 앞의 카드가 큰 카드

            // 둘 다 로얄 스트레이트 플러쉬일경우 비교
            if(playerLevel == 10)
            {
                // 둘 다 로티플일 경우 절대 숫자가 같지않으므로 문양끼리 비교
                if((playerCards[3].cardNumbers/13) > (computerCards[3].cardNumbers/13))
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 스트레이트 플러쉬일경우 비교
            if(playerLevel == 9)
            {
                int computerNumber = 0;
                for (int i = 0; i < 3; i++)
                {
                    if ((computerCards[i].cardNumbers % 13 - 1 == computerCards[i + 1].cardNumbers % 13)
                        && (computerCards[i + 1].cardNumbers % 13 - 1 == computerCards[i + 2].cardNumbers % 13)
                        && (computerCards[i + 2].cardNumbers % 13 - 1 == computerCards[i + 3].cardNumbers % 13)
                        && (computerCards[i + 3].cardNumbers % 13 - 1 == computerCards[i + 4].cardNumbers % 13))
                    {
                        computerNumber = computerCards[i].cardNumbers;
                        break;
                    }
                }

                // 유저의 경우 5장이므로 가장 앞의 큰 카드의 숫자와 컴퓨터의 스트레이트 플러쉬중 가장 큰 숫자를 비교함
                if ((playerCards[0].cardNumbers % 13) > (computerNumber % 13))
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                // 그 중에서도 둘의 큰 카드의 숫자가 같을 경우
                else if((playerCards[0].cardNumbers % 13) == (computerNumber % 13))
                {
                    // 둘의 문양을 비교함
                    if((playerCards[0].cardNumbers / 13) > (computerNumber / 13))
                    {
                        Console.WriteLine("플레이어의 승리입니다");
                        playerMoney += playerBet;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터의 승리입니다");
                        playerMoney -= playerBet;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 포카드일경우 비교
            if (playerLevel == 8)
            {
                int computerNumber = 0;
                int playerNumber = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (computerCards[i].cardNumbers % 13 == computerCards[i + 3].cardNumbers % 13)
                    {
                        computerNumber = computerCards[i].cardNumbers;
                        break;
                    }
                }

                for (int i = 0; i < 2; i++)
                {
                    if (playerCards[i].cardNumbers % 13 == playerCards[i + 3].cardNumbers % 13)
                    {
                        playerNumber = playerCards[i].cardNumbers;
                        break;
                    }
                }

                // 둘 다 포카드일경우 둘의 문양과 숫자가 절대 같을 수 없으므로 가장 큰 카드의 크기를 비교함
                if(playerNumber > computerNumber)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 풀 하우스일경우
            if (playerLevel == 7)
            {
                int computerNumber = 0;
                int playerNumber = 0;
                for (int i = 0; i < 5; i++)
                {
                    if ((computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                        && (computerCards[i + 1].cardNumbers % 13 == computerCards[i + 2].cardNumbers % 13))
                    {
                        for (int j = i + 3; j < 6; j++)
                        {
                            if ((computerCards[j].cardNumbers % 13 == computerCards[j + 1].cardNumbers % 13))
                            {
                                computerNumber = computerCards[i].cardNumbers;
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < 6; i++)
                {
                    if (computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                    {
                        for (int j = i + 2; j < 5; j++)
                        {
                            if ((computerCards[j].cardNumbers % 13 == computerCards[j + 1].cardNumbers % 13)
                                && (computerCards[j + 1].cardNumbers % 13 == computerCards[j + 2].cardNumbers % 13))
                            {
                                computerNumber = computerCards[j].cardNumbers;
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    if ((playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                        && (playerCards[i + 1].cardNumbers % 13 == playerCards[i + 2].cardNumbers % 13))
                    {
                        for (int j = i + 3; j < 4; j++)
                        {
                            if ((playerCards[j].cardNumbers % 13 == playerCards[j + 1].cardNumbers % 13))
                            {
                                playerNumber = playerCards[i].cardNumbers;
                                break;
                            }
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                    {
                        for (int j = i + 2; j < 3; j++)
                        {
                            if ((playerCards[j].cardNumbers % 13 == playerCards[j + 1].cardNumbers % 13)
                                && (playerCards[j + 1].cardNumbers % 13 == playerCards[j + 2].cardNumbers % 13))
                            {
                                playerNumber = playerCards[j].cardNumbers;
                                break;
                            }
                        }
                    }
                }

                // 둘 다 풀하우스일 경우 둘의 트리플의 숫자가 절대로 같을 수 없음
                if (playerNumber % 13 > computerNumber % 13)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 플러쉬 일경우
            if (playerLevel == 6)
            {
                int computerNumber = 0;

                // 컴퓨터의 플러쉬중 가장 큰 카드를 컴퓨터 넘버에 대입
                for (int i = 0; i < 7; i++)
                {
                    int zeroSame = 0;
                    int oneSame = 0;
                    int twoSame = 0;
                    int threeSame = 0;
                    // 클로버 플러쉬인경우
                    if (computerCards[i].cardNumbers / 13 == 0)
                    {
                        zeroSame += 1;
                        if(zeroSame >= 5)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if(computerCards[j].cardNumbers / 13 == 0)
                                {
                                    computerNumber = computerCards[j].cardNumbers;
                                    break;
                                }
                            }
                        }
                    }
                    // 하트 플러쉬인경우
                    else if (computerCards[i].cardNumbers / 13 == 1)
                    {
                        oneSame += 1;
                        if (oneSame >= 5)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (computerCards[j].cardNumbers / 13 == 1)
                                {
                                    computerNumber = computerCards[j].cardNumbers;
                                    break;
                                }
                            }
                        }
                    }
                    // 다이아 플러쉬인경우
                    else if (computerCards[i].cardNumbers / 13 == 2)
                    {
                        twoSame += 1;
                        if (twoSame >= 5)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (computerCards[j].cardNumbers / 13 == 2)
                                {
                                    computerNumber = computerCards[j].cardNumbers;
                                    break;
                                }
                            }
                        }
                    }
                    // 스페이드 플러쉬인경우
                    else if (computerCards[i].cardNumbers / 13 == 3)
                    {
                        threeSame += 1;
                        if (threeSame >= 5)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (computerCards[j].cardNumbers / 13 == 3)
                                {
                                    computerNumber = computerCards[j].cardNumbers;
                                    break;
                                }
                            }
                        }
                    }
                }

                // 둘의 플러쉬 중 가장 큰 카드의 숫자를 비교
                if (playerCards[0].cardNumbers % 13 > computerNumber % 13)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                // 큰 카드의 숫자가 같을 경우 문양 비교
                else if(playerCards[0].cardNumbers % 13 == computerNumber % 13)
                {
                    if (playerCards[0].cardNumbers / 13 > computerNumber / 13)
                    {
                        Console.WriteLine("플레이어의 승리입니다");
                        playerMoney += playerBet;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터의 승리입니다");
                        playerMoney -= playerBet;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 스트레이트일경우
            if (playerLevel == 5)
            {
                int computerNumber = 0;
                // 컴퓨터의 스트레이트의 가장 큰 카드를 컴퓨터 넘버에 대입
                for (int i = 0; i < 3; i++)
                {
                    if ((computerCards[i].cardNumbers % 13 - 1 == computerCards[i + 1].cardNumbers % 13)
                        && (computerCards[i + 1].cardNumbers % 13 - 1 == computerCards[i + 2].cardNumbers % 13)
                        && (computerCards[i + 2].cardNumbers % 13 - 1 == computerCards[i + 3].cardNumbers % 13)
                        && (computerCards[i + 3].cardNumbers % 13 - 1 == computerCards[i + 4].cardNumbers % 13))
                    {
                        computerNumber = computerCards[i].cardNumbers;
                        break;
                    }
                }
                // 플레이어의 스트레이트의 가장 큰 카드의 숫자가 컴퓨터 넘버보다 클경우
                if (playerCards[0].cardNumbers % 13 > computerNumber % 13)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                // 둘의 가장 큰 카드의 숫자가 같을 경우
                else if(playerCards[0].cardNumbers % 13 == computerNumber % 13)
                {
                    // 문양 비교
                    if (playerCards[0].cardNumbers / 13 > computerNumber / 13)
                    {
                        Console.WriteLine("플레이어의 승리입니다");
                        playerMoney += playerBet;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터의 승리입니다");
                        playerMoney -= playerBet;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 트리플일경우
            if (playerLevel == 4)
            {
                int computerNumber = 0;
                int playerNumber = 0;
                // 컴퓨터 트리플의 가장 큰 카드를 컴퓨터 넘버에 대입
                for (int i = 0; i < 5; i++)
                {
                    if ((computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                        && (computerCards[i + 1].cardNumbers % 13 == computerCards[i + 2].cardNumbers % 13))
                    {
                        computerNumber = computerCards[i].cardNumbers;
                        break;
                    }
                }
                // 플레이어 트리플의 가장 큰 카드를 플레이어 넘버에 대입
                for (int i = 0; i < 3; i++)
                {
                    if ((playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                        && (playerCards[i + 1].cardNumbers % 13 == playerCards[i + 2].cardNumbers % 13))
                    {
                        playerNumber = playerCards[i].cardNumbers;
                        break;
                    }
                }
                // 둘 다 트리플일경우 둘의 트리플 숫자는 같을 수 없음
                // 플레이어 넘버의 숫자가 컴퓨터 넘버의 숫자보다 크다면
                if(playerNumber % 13 > computerNumber % 13)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 투페어일경우
            if (playerLevel == 3)
            {
                int computerNumber = 0;
                int playerNumber = 0;
                // 컴퓨터의 큰 페어의 큰 수를 컴퓨터 넘버에 대입
                for (int i = 0; i < 6; i++)
                {
                    if (computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                    {
                        computerNumber = computerCards[i].cardNumbers;
                        break;
                    }
                }
                // 플레이어의 큰 페어의 큰 수를 플레이어 넘버에 대입
                for (int i = 0; i < 4; i++)
                {
                    if (playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                    {
                        playerNumber = playerCards[i].cardNumbers;
                        break;
                    }
                }
                // 플레이어 넘버의 숫자가 컴퓨터 넘버의 숫자보다 클경우
                if (playerNumber % 13 > computerNumber % 13)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                // 둘의 숫자가 같을 경우
                else if(playerNumber % 13 == computerNumber % 13)
                {
                    // 문양 비교
                    if (playerNumber / 13 > computerNumber / 13)
                    {
                        Console.WriteLine("플레이어의 승리입니다");
                        playerMoney += playerBet;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터의 승리입니다");
                        playerMoney -= playerBet;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 원페어일경우
            if (playerLevel == 2)
            {
                int computerNumber = 0;
                int playerNumber = 0;
                // 컴퓨터의 페어의 큰 수를 컴퓨터 넘버에 대입
                for (int i = 0; i < 6; i++)
                {
                    if (computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                    {
                        computerNumber = computerCards[i].cardNumbers;
                        break;
                    }
                }
                // 플레이어의 페어의 큰 수를 플레이어 넘버에 대입
                for (int i = 0; i < 4; i++)
                {
                    if (playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                    {
                        playerNumber = playerCards[i].cardNumbers;
                        break;
                    }
                }
                // 플레이어 넘버의 숫자가 컴퓨터 넘버의 숫자보다 클경우
                if (playerNumber % 13 > computerNumber % 13)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                // 둘의 숫자가 같을 경우
                else if (playerNumber % 13 == computerNumber % 13)
                {
                    // 문양 비교
                    if (playerNumber / 13 > computerNumber / 13)
                    {
                        Console.WriteLine("플레이어의 승리입니다");
                        playerMoney += playerBet;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터의 승리입니다");
                        playerMoney -= playerBet;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }

            // 둘 다 탑일경우
            if (playerLevel == 1)
            {
                // 가장 큰 카드를 앞으로 정렬해뒀기 때문에 가장 앞의 카드를 비교
                // 둘의 숫자 우선 비교
                if (playerCards[0].cardNumbers % 13 > computerCards[0].cardNumbers % 13)
                {
                    Console.WriteLine("플레이어의 승리입니다");
                    playerMoney += playerBet;
                    return;
                }
                // 둘의 숫자가 같을 경우
                else if(playerCards[0].cardNumbers % 13 == computerCards[0].cardNumbers % 13)
                {
                    // 문양 비교
                    if(playerCards[0].cardNumbers / 13 > computerCards[0].cardNumbers / 13)
                    {
                        Console.WriteLine("플레이어의 승리입니다");
                        playerMoney += playerBet;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("컴퓨터의 승리입니다");
                        playerMoney -= playerBet;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("컴퓨터의 승리입니다");
                    playerMoney -= playerBet;
                    return;
                }
            }
        }

        // 화면 클리어
        void Clear()
        {
            Console.SetCursorPosition(0, 0);
            for(int i = 0; i < 20; i ++)
            {
                Console.WriteLine("                                                            ");
            }
        }

        // 컴퓨터, 유저 카드 받은후 큰 순서로 나열
        void Draw_Cards()
        {
            // 0~51 섞기
            for (int i = 0; i < 10000; i++)
            {
                int randNum = random.Next(0, 51);
                int temp = cardsLevel[randNum + 1];
                cardsLevel[randNum + 1] = cardsLevel[randNum];
                cardsLevel[randNum] = temp;
            }

            // 앞에서 7장 컴퓨터꺼
            for (int i = 0; i < 7; i++)
            {
                foreach (KeyValuePair<string, int> item in cardDeck)
                {
                    if (cardsLevel[i] == item.Value)
                    {
                        Card tempCard = new Card();
                        tempCard.cardPattern = item.Key;
                        tempCard.cardNumbers = item.Value;
                        computerCards.Add(tempCard);
                    }
                }
            }

            // 컴퓨터 카드 정렬
            Sort_ComputerCards();

            // 나머지 7장 플레이어꺼
            for (int i = 7; i < 14; i++)
            {
                foreach (KeyValuePair<string, int> item in cardDeck)
                {
                    if (cardsLevel[i] == item.Value)
                    {
                        Card tempCard = new Card();
                        tempCard.cardPattern = item.Key;
                        tempCard.cardNumbers = item.Value;
                        playerCards.Add(tempCard);
                    }
                }
            }

            //플레이어 카드 정렬
            Sort_PlayerCards();
        }

        // 컴퓨터 카드 정렬
        void Sort_ComputerCards()
        {
            // 컴퓨터 카드 숫자 비교후 큰 수 앞으로
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 6 - j; i++)
                {
                    if (computerCards[i].cardNumbers % 13 < computerCards[i + 1].cardNumbers % 13)
                    {
                        Card tempCard = computerCards[i + 1];
                        computerCards[i + 1] = computerCards[i];
                        computerCards[i] = tempCard;
                    }
                }
            }

            // 큰 수 앞으로 정렬 후 앞에서 부터 수가 같을경우 문자 비교후 큰 문자 앞으로
            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 6 - j; i++)
                {
                    if ((computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                        && (computerCards[i].cardNumbers / 13 < computerCards[i + 1].cardNumbers / 13))
                    {
                        Card tempCard = computerCards[i + 1];
                        computerCards[i + 1] = computerCards[i];
                        computerCards[i] = tempCard;
                    }
                }
            }
        }

        // 플레이어 카드 정렬
        void Sort_PlayerCards()
        {
            // 플레이어 카드 숫자 비교후 큰 수 앞으로
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4 - j; i++)
                {
                    if (playerCards[i].cardNumbers % 13 < playerCards[i + 1].cardNumbers % 13)
                    {
                        Card tempCard = playerCards[i + 1];
                        playerCards[i + 1] = playerCards[i];
                        playerCards[i] = tempCard;
                    }
                }
            }

            // 큰 수 앞으로 정렬 후 앞에서 부터 수가 같을경우 문자 비교후 큰 문자 앞으로
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 4 - j; i++)
                {
                    if ((playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                        && (playerCards[i].cardNumbers / 13 < playerCards[i + 1].cardNumbers / 13))
                    {
                        Card tempCard = playerCards[i + 1];
                        playerCards[i + 1] = playerCards[i];
                        playerCards[i] = tempCard;
                    }
                }
            }
        }

        // 카드 초기화
        void Clear_Cards()
        {
            computerCards.Clear();
            playerCards.Clear();
        }

        // 카드 전부 출력
        void Print_TotalCard()
        {
            Print_ComputerCard();
            Print_PlayerCard();
        }

        // 컴퓨터 카드 출력
        void Print_ComputerCard()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("                  컴퓨터의 카드");
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    string[] splitStr = { "_", "." };
                    tempPrint = computerCards[x].cardPattern.Split(splitStr, StringSplitOptions.RemoveEmptyEntries);
                    Console.SetCursorPosition(x * 7, y + 1);
                    if (y == 0)
                    {
                        Console.WriteLine("┌──────┐");
                    }
                    else if (y == 1)
                    {
                        if (tempPrint[1] == "10")
                        {
                            Console.WriteLine("│{0}    │", tempPrint[1]);
                        }
                        else
                        {
                            Console.WriteLine("│{0}     │", tempPrint[1]);
                        }
                    }
                    else if (y == 2)
                    {
                        if (tempPrint[0] == "♥" || tempPrint[0] == "◆")
                        {
                            Console.Write("│");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("{0}     ", tempPrint[0]);
                            Console.ResetColor();
                            Console.WriteLine("│");
                        }
                        else
                        {
                            Console.Write("│");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("{0}     ", tempPrint[0]);
                            Console.ResetColor();
                            Console.WriteLine("│");
                        }
                    }
                    else if (y == 5)
                    {
                        Console.WriteLine("└──────┘");
                    }
                    else
                    {
                        Console.WriteLine("│      │");
                    }
                }
            }
        }

        // 플레이어 카드 출력
        void Print_PlayerCard()
        {
            Console.SetCursorPosition(0, 7);
            Console.Write("소지금:{0,8}    플레이어의 카드", playerMoney);
            for (int x = 0; x < 5; x++)
            {
                for (int y = 7; y < 13; y++)
                {
                    string[] splitStr = { "_", "." };
                    tempPrint = playerCards[x].cardPattern.Split(splitStr, StringSplitOptions.RemoveEmptyEntries);
                    Console.SetCursorPosition(x * 7, y + 1);
                    if (y == 7)
                    {
                        Console.WriteLine("┌──────┐");
                    }
                    else if (y == 8)
                    {
                        if (tempPrint[1] == "10")
                        {
                            Console.WriteLine("│{0}    │", tempPrint[1]);
                        }
                        else
                        {
                            Console.WriteLine("│{0}     │", tempPrint[1]);
                        }
                    }
                    else if (y == 9)
                    {
                        if (tempPrint[0] == "♥" || tempPrint[0] == "◆")
                        {
                            Console.Write("│");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("{0}     ", tempPrint[0]);
                            Console.ResetColor();
                            Console.WriteLine("│");
                        }
                        else
                        {
                            Console.Write("│");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("{0}     ", tempPrint[0]);
                            Console.ResetColor();
                            Console.WriteLine("│");
                        }
                    }
                    else if (y == 12)
                    {
                        Console.WriteLine("└──────┘");
                    }
                    else
                    {
                        Console.WriteLine("│      │");
                    }
                }
            }
        }

        // 컴퓨터 족보 체크
        void Consider_ComputerCards()
        {
            considerRoyalStraightFlush = 0;
            considerStraightFlush = 0;
            considerFourCard = 0;
            considerFullHouse = 0;
            considerFlush = 0;
            considerStraight = 0;
            considerTriple = 0;
            considerTwoPair = 0;
            considerPair = 0;
            // 로티플 체크
            for (int i = 0; i < 3; i ++)
            {
                if ((computerCards[i].cardNumbers%13 == 12) && (computerCards[i+1].cardNumbers % 13 == 11)
                    && (computerCards[i+2].cardNumbers % 13 == 10) && (computerCards[i+3].cardNumbers % 13 == 9)
                    && (computerCards[i+4].cardNumbers % 13 == 8))
                {
                    if ((computerCards[i].cardNumbers / 13 == computerCards[i + 1].cardNumbers / 13)
                    && (computerCards[i + 1].cardNumbers / 13 == computerCards[i + 2].cardNumbers / 13)
                    && (computerCards[i + 2].cardNumbers / 13 == computerCards[i + 3].cardNumbers / 13)
                    && (computerCards[i + 3].cardNumbers / 13 == computerCards[i + 4].cardNumbers / 13))
                    {
                        considerRoyalStraightFlush += 1;
                        return;
                    }
                    else
                    {
                        considerStraight += 1;
                    }
                }
            }
            // 스티플 체크
            for (int i = 0; i < 3; i ++)
            {
                if ((computerCards[i].cardNumbers % 13 - 1 == computerCards[i + 1].cardNumbers % 13)
                    && (computerCards[i + 1].cardNumbers % 13 - 1 == computerCards[i + 2].cardNumbers % 13)
                    && (computerCards[i + 2].cardNumbers % 13 - 1 == computerCards[i + 3].cardNumbers % 13)
                    && (computerCards[i + 3].cardNumbers % 13 - 1 == computerCards[i + 4].cardNumbers % 13))
                {
                    if ((computerCards[i].cardNumbers / 13 == computerCards[i + 1].cardNumbers / 13)
                    && (computerCards[i + 1].cardNumbers / 13 == computerCards[i + 2].cardNumbers / 13)
                    && (computerCards[i + 2].cardNumbers / 13 == computerCards[i + 3].cardNumbers / 13)
                    && (computerCards[i + 3].cardNumbers / 13 == computerCards[i + 4].cardNumbers / 13))
                    {
                        considerStraightFlush += 1;
                        return;
                    }
                    else
                    {
                        considerStraight += 1;
                    }
                }
            }
            // 포카드 체크
            for (int i = 0; i < 4; i ++)
            {
                if (computerCards[i].cardNumbers % 13 == computerCards[i + 3].cardNumbers % 13)
                {
                    considerFourCard += 1;
                    return;
                }
            }
            // 트리플 + 풀하우스 체크
            for(int i = 0; i < 5; i++)
            {
                if ((computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                    && (computerCards[i + 1].cardNumbers % 13 == computerCards[i + 2].cardNumbers % 13))
                {
                    for (int j = i + 3; j < 6; j++)
                    {
                        if ((computerCards[j].cardNumbers % 13 == computerCards[j + 1].cardNumbers % 13))
                        {
                            considerFullHouse += 1;
                            return;
                        }
                    }
                    considerTriple += 1;
                }
            }
            // 페어스타팅 풀하우스 체크
            for(int i = 0; i < 6; i++)
            {
                if (computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                {
                    for(int j = i + 2; j < 5; j++)
                    {
                        if ((computerCards[j].cardNumbers % 13 == computerCards[j + 1].cardNumbers % 13)
                            && (computerCards[j + 1].cardNumbers % 13 == computerCards[j + 2].cardNumbers % 13))
                        {
                            considerFullHouse += 1;
                            return;
                        }
                    }
                }
            }
            // 투 페어 + 원 페어 체크
            for (int i = 0; i < 6; i++)
            {
                if (computerCards[i].cardNumbers % 13 == computerCards[i + 1].cardNumbers % 13)
                {
                    for (int j = i + 2; j < 6; j++)
                    {
                        if ((computerCards[j].cardNumbers % 13 == computerCards[j + 1].cardNumbers % 13))
                        {
                            considerTwoPair += 1;
                            return;
                        }
                    }
                    considerPair += 1;
                }
            }

            spadeSameCount = 0;
            diaSameCount = 0;
            heartSameCount = 0;
            cloverSameCount = 0;
            // 플러쉬 체크
            for (int i = 0; i < 7; i++)
            {
                if (computerCards[i].cardNumbers / 13 == 0)
                {
                    spadeSameCount += 1;
                    if(spadeSameCount >= 5)
                    {
                        considerFlush += 1;
                        return;
                    }
                }
                else if(computerCards[i].cardNumbers / 13 == 1)
                {
                    diaSameCount += 1;
                    if (diaSameCount >= 5)
                    {
                        considerFlush += 1;
                        return;
                    }
                }
                else if(computerCards[i].cardNumbers / 13 == 2)
                {
                    heartSameCount += 1;
                    if (heartSameCount >= 5)
                    {
                        considerFlush += 1;
                        return;
                    }
                }
                else if(computerCards[i].cardNumbers / 13 == 3)
                {
                    cloverSameCount += 1;
                    if (cloverSameCount >= 5)
                    {
                        considerFlush += 1;
                        return;
                    }
                }
            }
        }

        // 컴퓨터 족보 표출
        int Print_ComputerLevel()
        {
            Console.SetCursorPosition(32, 0);
            if (considerRoyalStraightFlush == 1)
            {
                Console.Write("로얄스트레이트 플러시");
                return 10;
            }
            else if (considerStraightFlush == 1)
            {
                Console.Write("스트레이트 플러시");
                return 9;
            }
            else if (considerFourCard == 1)
            {
                Console.Write("포카드");
                return 8;
            }
            else if (considerFullHouse == 1)
            {
                Console.Write("풀하우스");
                return 7;
            }
            else if (considerFlush == 1)
            {
                Console.Write("플러시");
                return 6;
            }
            else if (considerStraight >= 1)
            {
                Console.Write("스트레이트");
                return 5;
            }
            else if (considerTriple == 1)
            {
                Console.Write("트리플");
                return 4;
            }
            else if (considerTwoPair == 1)
            {
                Console.Write("투페어");
                return 3;
            }
            else if (considerPair >= 1)
            {
                Console.Write("원페어");
                return 2;
            }
            else 
            {
                Console.Write("{0}탑", computerCards[0].cardPattern);
                return 1;
            }
        }

        // 플레이어 족보 체크
        void Consider_PlayerCards()
        {
            considerPlayerRoyalStraightFlush = 0;
            considerPlayerStraightFlush = 0;
            considerPlayerFourCard = 0;
            considerPlayerFullHouse = 0;
            considerPlayerFlush = 0;
            considerPlayerStraight = 0;
            considerPlayerTriple = 0;
            considerPlayerTwoPair = 0;
            considerPlayerPair = 0;
            // 로티플 체크
            for (int i = 0; i < 1; i++)
            {
                if ((playerCards[i].cardNumbers % 13 == 12) && (playerCards[i + 1].cardNumbers % 13 == 11)
                    && (playerCards[i + 2].cardNumbers % 13 == 10) && (playerCards[i + 3].cardNumbers % 13 == 9)
                    && (playerCards[i + 4].cardNumbers % 13 == 8))
                {
                    if ((playerCards[i].cardNumbers / 13 == playerCards[i + 1].cardNumbers / 13)
                    && (playerCards[i + 1].cardNumbers / 13 == playerCards[i + 2].cardNumbers / 13)
                    && (playerCards[i + 2].cardNumbers / 13 == playerCards[i + 3].cardNumbers / 13)
                    && (playerCards[i + 3].cardNumbers / 13 == playerCards[i + 4].cardNumbers / 13))
                    {
                        considerPlayerRoyalStraightFlush += 1;
                        return;
                    }
                    else
                    {
                        considerPlayerStraight += 1;
                    }
                }
            }
            // 스티플 체크
            for (int i = 0; i < 1; i++)
            {
                if ((playerCards[i].cardNumbers % 13 - 1 == playerCards[i + 1].cardNumbers % 13)
                    && (playerCards[i + 1].cardNumbers % 13 - 1 == playerCards[i + 2].cardNumbers % 13)
                    && (playerCards[i + 2].cardNumbers % 13 - 1 == playerCards[i + 3].cardNumbers % 13)
                    && (playerCards[i + 3].cardNumbers % 13 - 1 == playerCards[i + 4].cardNumbers % 13))
                {
                    if ((playerCards[i].cardNumbers / 13 == playerCards[i + 1].cardNumbers / 13)
                    && (playerCards[i + 1].cardNumbers / 13 == playerCards[i + 2].cardNumbers / 13)
                    && (playerCards[i + 2].cardNumbers / 13 == playerCards[i + 3].cardNumbers / 13)
                    && (playerCards[i + 3].cardNumbers / 13 == playerCards[i + 4].cardNumbers / 13))
                    {
                        considerPlayerStraightFlush += 1;
                        return;
                    }
                    else
                    {
                        considerPlayerStraight += 1;
                    }
                }
            }
            // 포카드 체크
            for (int i = 0; i < 2; i++)
            {
                if (playerCards[i].cardNumbers % 13 == playerCards[i + 3].cardNumbers % 13)
                {
                    considerPlayerFourCard += 1;
                    return;
                }
            }
            // 풀하우스 + 트리플 체크
            for (int i = 0; i < 3; i++)
            {
                if ((playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                    && (playerCards[i + 1].cardNumbers % 13 == playerCards[i + 2].cardNumbers % 13))
                {
                    for (int j = i + 3; j < 4; j++)
                    {
                        if ((playerCards[j].cardNumbers % 13 == playerCards[j + 1].cardNumbers % 13))
                        {
                            considerPlayerFullHouse += 1;
                            return;
                        }
                    }
                    considerPlayerTriple += 1;
                }
            }
            // 페어 스타팅 풀하우스 체크
            for (int i = 0; i < 4; i++)
            {
                if (playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                {
                    for (int j = i + 2; j < 3; j++)
                    {
                        if ((playerCards[j].cardNumbers % 13 == playerCards[j + 1].cardNumbers % 13)
                            && (playerCards[j + 1].cardNumbers % 13 == playerCards[j + 2].cardNumbers % 13))
                        {
                            considerPlayerFullHouse += 1;
                            return;
                        }
                    }
                }
            }
            // 투 페어 + 원 페어 체크
            for (int i = 0; i < 4; i++)
            {
                if (playerCards[i].cardNumbers % 13 == playerCards[i + 1].cardNumbers % 13)
                {
                    for (int j = i + 2; j < 4; j++)
                    {
                        if ((playerCards[j].cardNumbers % 13 == playerCards[j + 1].cardNumbers % 13))
                        {
                            considerPlayerTwoPair += 1;
                            return;
                        }
                    }
                    considerPlayerPair += 1;
                }
            }

            playerSpadeSameCount = 0;
            playerDiaSameCount = 0;
            playerHeartSameCount = 0;
            playerCloverSameCount = 0;
            // 플러쉬 체크
            for (int i = 0; i < 5; i++)
            {
                if (playerCards[i].cardNumbers / 13 == 0)
                {
                    playerSpadeSameCount += 1;
                    if (playerSpadeSameCount >= 5)
                    {
                        considerPlayerFlush += 1;
                        return;
                    }
                }
                else if (playerCards[i].cardNumbers / 13 == 1)
                {
                    playerDiaSameCount += 1;
                    if (playerDiaSameCount >= 5)
                    {
                        considerPlayerFlush += 1;
                        return;
                    }
                }
                else if (playerCards[i].cardNumbers / 13 == 2)
                {
                    playerHeartSameCount += 1;
                    if (playerHeartSameCount >= 5)
                    {
                        considerPlayerFlush += 1;
                        return;
                    }
                }
                else if (playerCards[i].cardNumbers / 13 == 3)
                {
                    playerCloverSameCount += 1;
                    if (playerCloverSameCount >= 5)
                    {
                        considerPlayerFlush += 1;
                        return;
                    }
                }

            }
        }

        // 플레이어 족보 표출
        int Print_PlayerLevel()
        {
            Console.SetCursorPosition(35, 7);
            if (considerPlayerRoyalStraightFlush == 1)
            {
                Console.Write("로얄스트레이트 플러시");
                return 10;
            }
            else if (considerPlayerStraightFlush == 1)
            {
                Console.Write("스트레이트 플러시");
                return 9;
            }
            else if (considerPlayerFourCard == 1)
            {
                Console.Write("포카드");
                return 8;
            }
            else if (considerPlayerFullHouse == 1)
            {
                Console.Write("풀하우스");
                return 7;
            }
            else if (considerPlayerFlush == 1)
            {
                Console.Write("플러시");
                return 6;
            }
            else if (considerPlayerStraight >= 1)
            {
                Console.Write("스트레이트");
                return 5;
            }
            else if (considerPlayerTriple == 1)
            {
                Console.Write("트리플");
                return 4;
            }
            else if (considerPlayerTwoPair == 1)
            {
                Console.Write("투페어");
                return 3;
            }
            else if (considerPlayerPair >= 1)
            {
                Console.Write("원페어");
                return 2;
            }
            else
            {
                Console.Write("{0}탑", playerCards[0].cardPattern);
                return 1;
            }
        }

    }
}