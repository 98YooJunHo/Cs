using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public class Wolf: MonsterBase
    {
        public override void Print_Infos()
        {
            //base.Print_Infos();

            name = "늑대";
            Console.WriteLine("이 몬스터의 이름은 {0}입니다.",
                this.name);
        }
    }
}
