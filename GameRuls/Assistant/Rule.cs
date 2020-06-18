using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRuls.Assistant
{
    public static class Rule
    {
        public static bool CheckWin(int player, int sizePlaingFaild, int sizeWin)
        {
            for (int col = 0; col < sizePlaingFaild - sizeWin + 1; col++)
            {
                for (int row = 0; row < sizePlaingFaild - sizeWin + 1; row++)
                {
                    if (CheckDiagonal(player, col, row, sizeWin) || CheckLanes(player, col, row, sizeWin)) return true;
                }
            }
            return false;
        }

        public static bool CheckDiagonal(int player, int offsetX, int offsetY, int sizeWin)
        {
            bool toright, toleft;
            toright = true;
            toleft = true;
            for (int i = 0; i < sizeWin; i++)
            {
                toright &= (WorkingMap.Map[i + offsetX, i + offsetY] == player);
                toleft &= (WorkingMap.Map[sizeWin - i - 1 + offsetX, i + offsetY] == player);
            }

            if (toright || toleft) return true;

            return false;
        }

        public static bool CheckLanes(int player, int offsetX, int offsetY, int sizeWin)
        {
            bool cols, rows;
            for (int col = offsetX; col < sizeWin + offsetX; col++)
            {
                cols = true;
                rows = true;
                for (int row = offsetY; row < sizeWin + offsetY; row++)
                {
                    cols &= (WorkingMap.Map[col, row] == player);
                    rows &= (WorkingMap.Map[row, col] == player);
                }
                if (cols || rows) return true;
            }
            return false;
        }


    }
}
