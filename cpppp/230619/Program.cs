
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            Wolf myWolf = new Wolf();
            Slime mySlime = new Slime();
            Dictionary<string, MonsterBase> monsterList = new Dictionary<string, MonsterBase>();

            //myDog.DogPrint();
            //myDog.Print_AnotherThings();
            //myDog.Print_Infos();

            int number = 10;
            number.PlusAndPrint(5);


        }

        static void Des001()
        {
            int number = 10;
            char charValue = 'A';
            string textStr = "Hello World!";

            object canSaveAll1 = number;
            object canSaveAll2 = charValue;
            object canSaveAll3 = textStr;

            var canSaveAnything1 = number;
            var canSaveAnything2 = charValue;
            var canSaveAnything3 = textStr;

            int number2 = (int)canSaveAll1;

            Console.WriteLine(number2);
            Console.WriteLine(canSaveAll2);
            Console.WriteLine(canSaveAll3);
        }

        static void Des002()
        {
            Parent myParent = new Parent();
            Child myChild = new Child();

            Parent tempParent = myChild;     // 업 캐스팅
            Child tempChild = (Child)tempParent; // 다운 캐스팅

            //myParent.Print_Infos();
            //Console.WriteLine();
            //myChild.Print_Infos();
            //Console.WriteLine();

            tempParent.Print_Infos();
            Console.WriteLine();
            tempChild.Print_Infos();
        }
    }
}
