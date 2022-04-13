using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 이전에는 세로로 sin 그래프를 그렸지만 이건 가로 버전
// 2차원 배열에 몰아넣고 출력

namespace _02_SineTest
{
    class Program
    { // 매크로 대신
        static int XMAX = 60;
        static int YMAX = 20;
        static void drawSine()
        {
            double x = 0.0;
            double step = 2 * Math.PI / XMAX; // 2pi 값을 XMAX값으로 나눈 거
            char[,] screenBuffer = new char[YMAX + 2, XMAX + 1]; // 출력할 내용을 담을 2차원 배열

            // 2차원 배열 초기화
            for (int i = 0; i < YMAX + 1; i++)
                for (int j = 0; j < XMAX + 1; j++)
                    screenBuffer[i, j] = ' ';

            // y축 저장
            for (int i = 0; i < YMAX + 1; i++)
                screenBuffer[i, 0] = '|';

            // x,y축 0,0 자리
            screenBuffer[YMAX / 2 + 1, 0] = '*';

            // x축 저장
            for (int i = 1; i < XMAX + 1; i++)
                screenBuffer[YMAX / 2 + 1, i] = '-';

            // sin 그래프를 그릴 * 좌표 저장
            for(int i = 0; i < XMAX + 1; i++)
            {
                double y; // 구할 sin 값
                int yPrime;

                x += step;
                y = Math.Sin(x);

                yPrime = (int)(-(YMAX / 2) * y + (YMAX / 2 + 1));

                screenBuffer[yPrime, i] = '*';
            }

            // 출력
            for(int i =0; i<YMAX+1; i++)
            {
                for (int j = 0; j < XMAX+1; j++)
                {
                    Console.Write(screenBuffer[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            drawSine();
        }
    }
}
