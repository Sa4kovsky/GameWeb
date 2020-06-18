using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRuls.Assistant
{
    public class WorkingMap
    {
        public static int[,] Map { get; set; }
        public static void InitMap(int sizePlaingFaild)
        {
            Map = new int[sizePlaingFaild, sizePlaingFaild];
            for (int i = 0; i < sizePlaingFaild; i++)
            {
                for (int j = 0; j < sizePlaingFaild; j++)
                {
                    Map[i, j] = -1;
                }
            }
        }
    }
}
