using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public partial class Dog : MonsterBase
    {
        
        public void Print_AnotherThings()
        {
            Console.WriteLine("파일을 두 개로 나누었다, " +
                "정말로 Dog 클래스에서 이 함수를 부를 수 있을까?");
        }
    }
}