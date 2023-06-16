using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230612
{
    public class Diablo : MonsterBase
    {
        //private string _name = "디아블로";
        //private int _hp = 100000;
        //private int _mp = 10000;
        //private int _damage = 1000;
        //private int _defence = 500;
        //private string _type = "대형 악마";
        public override void Initialize(string name, int hp, int mp, int damage, int defence, string type)
        {
            // 이렇게 부모에 정의 되어 있는 함수를 내려 받아서 사용하는 것을 overriding(재정의) 이라고 한다
            base.Initialize(name, hp, mp, damage, defence, type);
        }           // Initialize()

        public override void Print_MonsterInfo()
        {
            base.Print_MonsterInfo();

            Console.WriteLine("디아블로에서 추가 작업을 한다");
        }           // Print_MonsterInfo()

        public void Print_OverloadingTest()
        {
            Console.WriteLine("함수 찍힌다");
        }           // Print_OverloadingTest()

        public void Print_OverloadingTest(int textStr)
        {
            Console.WriteLine("함수 찍힌다 -> {0}", textStr);
        }           // Print_OverloadingTest()


        //public void Print_Diablo_Status()
        //{
        //    Console.WriteLine("몬스터의 이름은 {0}이고\n 타입은 {1}\n 체력은 {2}\n 마력은 {3}\n 공격력은 {4}\n 방어력은 {5}\n",
        //        _name, _type, _hp, _mp, _damage, _defence);
        //}
    }
}
