using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230622
{
    public class CustomClass
    {
        public int xPos;
        public int yPos;


        public void Initialize(int _xPos, int _yPos)
        {
            xPos = _xPos;
            yPos = _yPos;
        }

        public virtual void PrintPosition()
        {
            Console.WriteLine("현 위치는 ({0}, {1}) 입니다.", xPos, yPos);
        }
    }
}
