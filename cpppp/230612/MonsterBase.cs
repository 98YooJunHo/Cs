using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230612
{
    public class MonsterBase
    {
        // 캡슐화 -> 필드를 private로 처리해서 외부에서 접근 불가능하도록 하겠다는 의미
        protected string _name;     // protected는 상속받은 자식 클래스에서는 쓸 수 있도록 하겠다는 의미
        protected int _hp;
        protected int _mp;
        protected int _damage;
        protected int _defence;
        protected string _type;

        public virtual void Initialize(string name, int hp, int mp, int damage, int defence, string type)
        {
            // 초기화라는 의미
            this._name = name;
            this._hp = hp;
            this._mp = mp;
            this._damage = damage;
            this._defence = defence;
            this._type = type;
        }           // Intialize

        public virtual void Print_MonsterInfo()
        {
            Console.WriteLine("몬스터 {0}의 정보", _name);
            Console.WriteLine("Hp : {0}, Mp : {1}", _hp, _mp);
            Console.WriteLine("Damage : {0}, Defence : {1}", _damage, _defence);
            Console.WriteLine("Type : {0}\n", _type);
        }           // Print_MonsterInfo()
    }
}
