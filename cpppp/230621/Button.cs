using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230621
{
    public class Button : IClickable, IDamagable
    {
        System.ConsoleKeyInfo key;

        public void ClickThisObject(bool isClick_)
        {
            // 에러 사라짐
        }

        public void TestFunc()
        {
            Console.WriteLine("함수 테스트");
        }

        public void Damaged(int damage)
        {
            // 에러 사라짐
        }
    }
}
