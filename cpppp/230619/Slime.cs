﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public class Slime : MonsterBase
    {
        public override void Print_Infos()
        {
            //base.Print_Infos();

            name = "슬라임";
            Console.WriteLine("이 몬스터의 이름은 {0}입니다."
                ,this.name);
        }
    }
}
