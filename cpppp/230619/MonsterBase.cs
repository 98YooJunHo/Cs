using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public class MonsterBase
    {
        protected string name = "없다";

        public virtual void Print_Infos()
        {
            Console.WriteLine("이 몬스터의 이름은 {0}입니다.",
                this.name);
        }
    }
}
