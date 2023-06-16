using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _230612_WarmUp
{
    public class RandomCode
    {
        Random random = new Random();
        int secretNumber = 0;
        char secretCode = 'A';
        char userInput = '0';
        int userNumber = 0;
        int count = -1;
        public void Random_Code()
        {
            secretNumber = random.Next(65, 90);
            secretCode = (char)(secretNumber);

            while(true)
            {
                count += 1;
                Console.WriteLine("현재 시도 횟수는 {0}회 입니다", count);
                Console.WriteLine("영어 대문자를 입력하세요");
                userInput = Convert.ToChar(Console.ReadLine());
                userNumber = Convert.ToInt32(userInput);

                if(userNumber > secretNumber)
                {
                    Console.Clear();
                    Console.WriteLine("{0} 이전 알파벳입니다.", userInput);
                    continue;
                }
                else if(userNumber == secretNumber)
                {
                    Console.Clear();
                    Console.WriteLine("정답 입니다");
                    Console.WriteLine("최종 스코어는 {0}입니다.", (100 - (10 * count)));
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("{0} 이후 알파벳입니다.", userInput);
                    continue;
                }    
            }
        }
    }
}
