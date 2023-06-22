using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230622_BushBattle
{
    public class Player : Npc
    {
        protected int player_Y;
        protected int player_X;
        protected int playerClearCount = 0;
        protected int playerHp = 30;
        protected int playerMHp = 30;
        protected int playerAtk = 5;
        protected int playerGold = 500;
        protected int battleCount = 0;
        protected int totalBattle = 0;
        protected int onQuest = 0;
        protected int clearQuest = 0;
    }
}
