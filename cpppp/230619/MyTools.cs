using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public static class MyTools
    {
        //! List 안의 Element가 유효한지 검사한다
        public static bool IsValid<T>(this List<T> list_)
        {
            bool isValid = (list_.Count > 0) && (list_.Count != null);
            return isValid;
        }
        public static void DogPrint(this Dog myDog)
        {
            myDog.Print_Infos();
        }

        public static int Plus(this int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public static int PlusAndPrint(this int firstValue, int secondValue)
        {
            Console.WriteLine("{0} + {1} = {2}", firstValue, secondValue, firstValue + secondValue);
            return firstValue + secondValue;
        }
    }
}
