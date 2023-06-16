using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230609_Warmup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Draw();
        }

        static void Draw()
        {
            Random random = new Random();

            int[] cardNumber = new int[52];
            string[] cards = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            string[] cardPattern = { "♣", "♥", "◆", "♠" };  // 카드넘버 /13 해서 문양 넣음 뒤에 있는 문양 일수록 더 높음
            int[] draw = new int[4];
            int[] player = new int[2];
            string[] playerPattern = new string[2];
            int[] computer = new int[2];
            string[] computerPattern = new string[2];

            for (int i = 0; i < cardNumber.Length; i++) // 카드넘버 0~51 기입
            {
                cardNumber[i] = i;
            }

            while (true)
            {
                int playerSum = 0;
                int computerSum = 0;
                string userInput = "0";
                Console.Clear();
                for (int i = 0; i < 100000; i++)           // 카드넘버 셔플
                {
                    int randomcard = random.Next(0, 51);
                    int temp = cardNumber[randomcard];
                    cardNumber[randomcard] = cardNumber[randomcard + 1];
                    cardNumber[randomcard + 1] = temp;
                }

                for (int i = 0; i < draw.Length; i++)       // 카드넘버에서 4개 뽑기
                {
                    draw[i] = cardNumber[i];
                }

                for (int i = 0; i < player.Length; i++)     // 플레이어가 위에서 두장
                {
                    player[i] = draw[i];
                }

                for (int i = 1; i < player.Length; i++)     // 플레이어카드 두 장의 값 비교
                {
                    if (((player[i]) % 13) == ((player[i - 1]) % 13))   // 두 장의 %13한 수 = (진짜수) 가 같다면
                    {
                        if (((player[i]) / 13) > ((player[i - 1]) / 13))    // 두 장의 문양 비교후 뒷장의 문양이 크다면 섞음
                        {
                            int temp = player[i - 1];
                            player[i - 1] = player[i];
                            player[i] = temp;
                        }
                    }

                    if (((player[i]) % 13) > ((player[i - 1]) % 13))    // 두 장의 %13한 수 = (진짜수) 가  뒷장이 더 크다면 섞음
                    {
                        int temp = player[i - 1];
                        player[i - 1] = player[i];
                        player[i] = temp;
                    }
                }                                           // 플레이어카드 두 장의 값 비교 종료

                for (int i = 0; i < computer.Length; i++)   // 컴퓨터가 나머지 두장
                {
                    computer[i] = draw[i + 2];
                }

                for (int i = 1; i < computer.Length; i++)   // 컴퓨터카드 두 장의 값 비교
                {
                    if (((computer[i]) % 13) == ((computer[i - 1]) % 13))   // 두 장의 %13한 수 =(진짜수) 가 같다면
                    {
                        if (((computer[i]) / 13) > ((computer[i - 1]) / 13))     // 두 장의 문양 비교후 뒷장의 문양이 크다면 섞음
                        {
                            int temp = computer[i - 1];
                            computer[i - 1] = computer[i];
                            computer[i] = temp;
                        }
                    }

                    if (((computer[i]) % 13) > ((computer[i - 1]) % 13))    // 두 장의 %13한 수 = (진짜수) 가  뒷장이 더 크다면 섞음
                    {
                        int temp = computer[i - 1];
                        computer[i - 1] = computer[i];
                        computer[i] = temp;
                    }
                }                                           // 컴퓨터 카드 두 장의 값 비교 종료

                for (int i = 0; i < computer.Length; i++)   // 컴퓨터 카드 문양값 저장
                {
                    if ((computer[i]) / 13 == 0)
                    {
                        computerPattern[i] = cardPattern[0];
                    }
                    if ((computer[i]) / 13 == 1)
                    {
                        computerPattern[i] = cardPattern[1];
                    }
                    if ((computer[i]) / 13 == 2)
                    {
                        computerPattern[i] = cardPattern[2];
                    }
                    if ((computer[i]) / 13 == 3)
                    {
                        computerPattern[i] = cardPattern[3];
                    }
                }                                           // 컴퓨터 카드 문양값 저장종료

                for (int i = 0; i < player.Length; i++)     // 플레이어 카드 문양값 저장
                {
                    if ((player[i]) / 13 == 0)
                    {
                        playerPattern[i] = cardPattern[0];
                    }
                    if ((player[i]) / 13 == 1)
                    {
                        playerPattern[i] = cardPattern[1];
                    }
                    if ((player[i]) / 13 == 2)
                    {
                        playerPattern[i] = cardPattern[2];
                    }
                    if ((player[i]) / 13 == 3)
                    {
                        playerPattern[i] = cardPattern[3];
                    }                                       // 컴퓨터 카드 문양값 저장 종료
                }

                Console.WriteLine("플레이어의 두 카드는 {0}{1}, {2}{3}", playerPattern[0], cards[player[0] % 13], playerPattern[1], cards[player[1] % 13]);
                Console.WriteLine("컴퓨터의 두 카드는 {0}{1}, {2}{3}\n", computerPattern[0], cards[computer[0] % 13], computerPattern[1], cards[computer[1] % 13]);

                for (int i = 0; i < player.Length; i++)     // 플레이어 카드 두장의 진짜수의 합 입력
                {
                    if (player[i] % 13 == 0)                  // %연산시 0 (A)일경우
                    {
                        playerSum += 1;                    // 플레이어 카드 두장의 진짜수의 합에 1추가
                        continue;
                    }
                    playerSum += ((player[i] % 13) + 1);            // 그외의 경우 진짜수의 합에 진짜수 추가
                }                                           // 플레이어 카드 두장의 진짜수의 합 입력 종료

                for (int i = 0; i < computer.Length; i++)   // 컴퓨터 카드 두장의 진짜수의 합 입력
                {
                    if (computer[i] % 13 == 0)
                    {
                        computerSum += 1;                  // 내부 내용 위의 플레이어 카드 합 과 동일
                        continue;
                    }
                    computerSum += ((computer[i] % 13) + 1);
                }                                           // 컴퓨터 카드 두장의 진짜수의 합 입력 종료

                Console.WriteLine("플레이어의 두 카드의 수 총합은 {0}", playerSum);
                Console.WriteLine("컴퓨터의 두 카드의 수 총합은 {0}\n", computerSum);

                if (playerSum == computerSum)                // 플레이어의 두 카드 수의 합이 컴퓨터와 같다면
                {
                    Console.WriteLine("플레이어의 두 카드중 수가 큰 카드의 수는 {0}", ((player[0]) % 13) + 1);
                    Console.WriteLine("컴퓨터의 두 카드중 수가 큰 카드의 수는 {0}\n", ((computer[0]) % 13) + 1);

                    if (player[0] == computer[0])           // 큰 수의 문양이 같다면
                    {
                        Console.WriteLine("플레이어와 컴퓨터의 큰 카드의 수가 동일하고");
                        Console.WriteLine("플레이어의 문양은 {0}, 컴퓨터의 문양은 {1} 이므로", playerPattern[0], computerPattern[0]);

                        if (playerPattern[0] == "♠")                                    // 그 중에 플레이어가 스페이드 라면
                        {
                            Console.WriteLine("플레이어의 승리입니다\n");
                        }
                        else if (playerPattern[0] == "◆" && computerPattern[0] != "♠") // 그 중에 플레이어가 다이아이고 컴퓨터가 스페이드가 아니라면
                        {
                            Console.WriteLine("플레이어의 승리입니다\n");
                        }
                        else if (playerPattern[0] == "♥" && computerPattern[0] == "♣")   // 그 중에 플레이어가 하트이고 컴퓨터가 클로버라면
                        {
                            Console.WriteLine("플레이어의 승리입니다\n");
                        }
                        else                                                            // 그 외의 경우 문양이 겹치지 않으므로 플레이어가 무조건 패배하는 경우의 수
                        {
                            Console.WriteLine("컴퓨터의 승리입니다\n");
                        }

                    }                                       // 큰 수의 문양이 같다면 종료

                    if (((player[0] - 1) % 13) + 1 > ((computer[0]) % 13) + 1)            // 플레이어의 큰 수가 컴퓨터의 큰 수보다 크다면
                    {
                        Console.WriteLine("플레이어의 승리입니다\n");
                    }
                    else if (((computer[0] - 1) % 13) + 1 > ((player[0]) % 13) + 1) // 컴퓨터의 큰 수가 플레이어의 큰 수보다 크다면
                    {
                        Console.WriteLine("컴퓨터의 승리입니다\n");
                    }
                }                                                                   // 플레이어의 두 카드 수의 합이 컴퓨터와 같다면 종료


                if (playerSum > computerSum)                                             // 플레이어의 두 카드 수의 합이 컴퓨터보다 크다면
                {
                    Console.WriteLine("플레이어의 승리입니다\n");
                }
                else if (playerSum < computerSum)                                        // 컴퓨터의 두 카드 수의 합이 플레이어보다 크다면
                {
                    Console.WriteLine("컴퓨터의 승리입니다\n");
                }

                Console.WriteLine("계속하려면 아무키나입력, 종료를 원할시 q입력후 엔터");
                userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    break;
                }
                else
                {
                    continue;
                }

            }                                                                   // while();
        }                                                                       // Draw();
    }
}