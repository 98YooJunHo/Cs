using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230612
{
    public class Baal
    {
        private string _name = "바알";
        private int _hp = 50000;
        private int _mp = 5000;
        private int _damage = 500;
        private int _defence = 300;
        private string _type = "중형 악마";

        public void Print_Baal_Status()
        {
            Console.WriteLine("몬스터의 이름은 {0}이고\n 타입은 {1}\n 체력은 {2}\n 마력은 {3}\n 공격력은 {4}\n 방어력은 {5}\n",
                _name, _type, _hp, _mp, _damage, _defence);
        }
    }
}
