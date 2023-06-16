using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.SqlServer.Server;
using static System.Console; // 이거 전처리하면 Console 안써도 됨.

namespace _230612
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 객체 지향의 4가지 요소
            // 캡슐화, 상속, 다형성, 추상화

            Diablo myDiablo = new Diablo();
            myDiablo.Initialize("디아블로", 100000, 50000, 1000, 500, "대형악마");
            myDiablo.Print_MonsterInfo();
            myDiablo.Print_OverloadingTest();
            myDiablo.Print_OverloadingTest(1812636);
            Console.WriteLine();

            Baal myBaal = new Baal();
            myBaal.Print_Baal_Status();
            Console.WriteLine();

            Skeleton mySkeleton = new Skeleton();
            mySkeleton.Print_Skeleton_Status();
            Console.WriteLine();

            //Dog myDog = new Dog();
            //Console.WriteLine("우리집 강아지 이름은 {0}이고, 다리 갯수는 {1}개 이다.",
            //    myDog.dogName, myDog.legCount);
            //myDog.Print_DogDescription();

            //Dog.Print_DogDescription2();
            //Console.WriteLine();

            //Cat myCat = new Cat(4, "야옹이", "검정색");
            //myCat.Print_MyCat();
            //myCat.catName = "새로운 야옹이";
            //myCat.Print_MyCat();
        }       // Main()

        static void Pm1()
        {
            string[] str = new string[2] { "Hello", "World" };
            //CallFunction001(str);
            //CallFunc002("Hello", "World", "+", "Hello", "World");
            CallFunc003(ref str);

            string[] resultStr;             // string 배열을 선언함
            CallFunc004(str, out resultStr);// out을 활용해서 값을 넘겨 받음 out을 활용하는 이유: return값이 무조건 존재해야할 때
            foreach (string result_ in resultStr)
            {
                Console.Write("{0} ", result_);
            }
            Console.WriteLine();

            //int num = 0;
            //num = num++;
            //Console.WriteLine("num에는 무슨 값이 들어 있나?? {0}", num);
        }

        //! 네 번째 방법도 매개변수를 Call by reference 방식으로 넘기는 방법인데
        //! 매개변수를 통해서 값을 Return한다
        static void CallFunc004(string[] str, out string[] outstr)
        {
            string[] resultString = new string[str.Length + 1];

            for (int i = 0; i < str.Length; i++)
            {
                resultString[i] = str[i];
            }
            resultString[str.Length] = "!";
            outstr = resultString;
        }       // CallFunc004()

        //! 세 번째 방법은 매개변수를 Call by reference 방식으로 넘기는 방법
        static void CallFunc003(ref string[] str)
        {
            foreach(string strElement in str)
            {
                Console.Write("{0} ", strElement);
            }
            Console.WriteLine();
        }       // CallFunc003()

        //! 두 번째 방법은 매개변수를 Call by value 방식으로 넘기는건 똑같음, 그런데 넘겨줄
        //! 매개변수를 배열의 요소 형태로 여러개 넘길 수 있다
        static void CallFunc002(params string[] str)
        {
            foreach (string strElement in str)
            {
                Console.Write("{0} ", strElement);
            }
            Console.WriteLine();
        }       // CallFunc002()

        //! 첫 번째 방법은 매개변수를 Call by value 방식으로 넘기는 방법
        static void CallFunction001(string[] str)
        {
            foreach(string strElement in str)
            {
                foreach (char char_ in strElement)
                {
                    Console.Write("{0} ", char_);
                }
                Console.WriteLine("{0} ", strElement);
            }
            Console.WriteLine();
        }       // CallFunction001()
    }           // class Program
}
