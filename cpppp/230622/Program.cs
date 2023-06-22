using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230622
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Des001();

            // 튜플 선언하는 법
            (int xPos, int yPos) playerPosition = (0, 1);
            playerPosition.xPos = 10;
            playerPosition.yPos = 20;

            Console.WriteLine("Player position ({0}, {1})", playerPosition.yPos, playerPosition.xPos);
            (playerPosition.xPos, playerPosition.yPos) = (playerPosition.yPos, playerPosition.xPos);
            Console.WriteLine("Player position ({0}, {1})", playerPosition.yPos, playerPosition.xPos);
        }

        static void Des002()
        {
            string strValue = "I am a boy.";
            string[] strArray = strValue.Split(' ');

            Console.WriteLine("몇 개로 split 되었는가? -> {0}", strArray.Count());

            foreach (string str in strArray)
            {
                Console.WriteLine(str);
            }
        }

        static void Des001()
        {
            List<int> intList = new List<int>();
            CustomClass customClass = new CustomClass();
            CustomClass customClass2 = null;

            customClass2 = customClass;

            CustomChild customChild = new CustomChild();
            CustomChild customChild2 = null;
            CustomChild customChild3 = new CustomChild();
            
            // 얕은 복사 (값을 바꾸면 원본 객체와 복사 개체 모두 바뀜)
            customChild2 = customChild;
            // 깊은 복사 (값을 바꾸면 본인만 바뀜)
            customChild3.Initialize(customChild.yPos, customChild.xPos);

            customChild.Initialize(0, 1);


            customChild2.PrintPosition();
            customChild3.PrintPosition();

            //PrintValue(customChild);


            //customChild = null;
            //if (customChild == null)
            //{
            //    Console.WriteLine("CustomChild는 null입니다");
            //}
            //else
            //{
            //    customChild.PrintPosition();
            //}

            //customChild?.PrintPosition();                       // 가끔 오류남 위의 이프문으로 하기를 추천함
        }

        static void PrintValue<T>(T anyValue) where T : CustomClass
        {
            anyValue.PrintPosition();
        }

        //static void PrintValue(int intValue)
        //{
        //    Console.WriteLine("int 매개변수로 넘겨받은 값을 출력했다. -> {0}", intValue);
        //}

        //static void PrintValue(float floatValue)
        //{
        //    Console.WriteLine("float 매개변수로 넘겨받은 값을 출력했다. -> {0}", floatValue);
        //}

        //static void PrintValue(string strValue)
        //{
        //    Console.WriteLine("string 매개변수로 넘겨받은 값을 출력했다. -> {0}", strValue);
        //}
    }
}
