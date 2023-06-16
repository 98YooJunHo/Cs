using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230614
{
    public static class Am950
    {
        static string message;

        public static void Print_Message(string localMessage)
        {
            message = localMessage;
            Console.WriteLine("{0}", message);
        }

    }
}
