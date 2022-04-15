using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 콘솔 창에서 데카르트 좌표계를 이용한 원 그리기

namespace _07_Circle
{
    class Program
    {
        static int XMAX = 41;
        static int YMAX = 41;
        static int XORG = XMAX / 2;
        static int YORG = YMAX / 2;
        static int NDOTS = 100;
        static int RADIUS = XMAX / 2;

        static void drawCircle()
        {
            char[,] screenBuffer = new char[XMAX, YMAX];
            double theta = 0.0;
            double step = 2 * Math.PI / NDOTS;

            for(int i = 0; i< NDOTS; i++)
            {
                int x, y;

                x = (int)(RADIUS * Math.Cos(theta)) + XORG;
                y = (int)(RADIUS * Math.Sin(theta)) + YORG;

                if (x >= 0 && y >= 0)
                    screenBuffer[x, y] = '*';

                theta += step;
            }


            for (int i = 0; i < XMAX; i++)
            {
                for (int j = 0; j < YMAX; j++)
                {
                    Console.Write(screenBuffer[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            drawCircle();
        }
    }
}
