using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRuls.Assistant
{
    public static class Move
    {
        public static void PlayerMove(int player, int x, int y, int sizePlaingFaild)
        {
            int x1, y1;
            do
            {
                x1 = x;
                y1 = y;
            } while (!IsCellValid(x, y, sizePlaingFaild));

            WorkingMap.Map[x1, y1] = player;
        }


        public static bool IsCellValid(int x, int y, int sizePlaingFaild)
        {
            if (x < 0 || x >= sizePlaingFaild || y < 0 || y >= sizePlaingFaild) return false;
            if (WorkingMap.Map[x, y] == -1) return true;
            return false;
        }

    }
}
