using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230614
{
    public class Am940
    {
        public static string staticMessage;
        string message = "인스턴스 필드에 미리 넣어둔 값";

        public void Print_Message(string localMessage)
        {
            message = localMessage;
            Console.WriteLine("이런걸 출력할 것 -> {0}", message);
        }

        public static void Print_Message()
        {
            Console.WriteLine("Static 메서드에서 인스턴스 필드를 찍어볼 수 있을까?-> {0}");
        }
    }
}
