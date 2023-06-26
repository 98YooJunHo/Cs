using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace _230622_BushBattle
{
    public class Map : Player
    {
        protected const int MAP_SIZE_Y = 17;
        protected const int MAP_SIZE_X = 32;
        protected char[,] map = new char[MAP_SIZE_Y,MAP_SIZE_X];
        protected const char PLAYER = '♥';
        protected const char WALL = '■';
        protected const char GROUND = ' ';
        protected const char BUSH = '∥';
        protected const char NPC = '?';
        
        // 맵 생성
        public void Make_Map()
        {
            npc_Y = MAP_SIZE_Y / 10 + 1;
            npc_X = MAP_SIZE_X / 10 + 1;
            player_Y = MAP_SIZE_Y / 2;
            player_X = MAP_SIZE_X / 2;
            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (y == 0 || x == 0 || y == MAP_SIZE_Y - 1 || x == MAP_SIZE_X - 1)
                    {
                        map[y, x] = WALL;
                    }
                    else if (y == player_Y && x == player_X)
                    {
                        map[y, x] = PLAYER;
                    }
                    else if (y == npc_Y && x == npc_X)
                    {
                        map[y, x] = NPC;
                    }
                    else if ((0 < y && y < (MAP_SIZE_Y / 5) * 2) && ((MAP_SIZE_X / 5) * 3 < x && x < MAP_SIZE_X - 1))
                    {
                        map[y, x] = BUSH;
                    }
                    else
                    {
                        map[y, x] = GROUND;
                    }
                }
            }
        }

        // 부쉬 체크
        public void Set_Bush()
        {
            for(int y = 1; y < (MAP_SIZE_Y / 5) * 2; y ++)
            {
                for(int x = (MAP_SIZE_X / 5) * 3 + 1; x < MAP_SIZE_X - 1; x ++)
                {
                    if (map[y, x] == GROUND)
                    {
                        map[y, x] = BUSH;
                    }
                }
            }
        }
    }
}
