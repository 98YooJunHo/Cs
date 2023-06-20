using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230619
{
    public class Child : Parent
    {
        public string strChild;

        public override void Print_Infos()
        {
            //base.Print_Infos();

            number = 10;
            strValue = "This is Child";
            strChild = "Sentence of child added";
            Console.WriteLine("Child Class -> number : {0}, strValue : {1} strChild : {2}",
                this.number,this.strValue, this.strChild); // this. : 이곳의 것을 사용하겠다
        }
    }
}
