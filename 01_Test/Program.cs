using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 삼각함수 테스트
// sin 그래프를 그릴 값을 우리가 계산할 필요 없이 Math 클래스로 해결이 가능
// sin 그래프를 세로로 그려낸다

namespace _01_Test
{
    class Program
    {
        // 매크로 대신
        static int XMAX = 40;
        static int YMAX = 40;
        static void drawSine()
        {
            double x = 0.0;
            double y = 0.0; // 구할 sin 값
            double step = 2 * Math.PI / XMAX; // 2pi 값을 40으로 나눈 거
            char[] lineBuffer = new char[YMAX + 2]; // overflow 발생 막으려고 과하게 2 추가

            // 사인 y축을 그릴 칸 맞추기
            for(int i = 0; i<12; i++)
                Console.Write(" ");

            // y축을 그림
            for (int i = 0; i < YMAX / 2; i++)
                Console.Write("-");

            Console.Write("*");

            for (int i = 0; i < YMAX / 2; i++)
                Console.Write("-");

            Console.WriteLine();

            
            for (int i = 0; i < XMAX; i++)
            {
                int yPrime = 0; // 배열의 인덱스로 사용할 정수값

                // x 축을 그림
                for (int j = 0; j < YMAX + 1; j++)
                    lineBuffer[j] = ' ';
                lineBuffer[YMAX / 2] = '|';

                x += step; // 라디안 값에 의한 도수가 들어간다
                y = Math.Sin(x); // x를 각도로 sin을 구한다

                // 선형 변환을 위한 인덱스 값 구하기 + 해당 인덱스에 * 삽입
                yPrime = (int)((YMAX / 2) * y + (YMAX / 2 + 1));
                lineBuffer[yPrime] = '*';

                // x 값과 y값의 출력
                Console.Write("{0, 5:F2} {1, 5:F2} ", x, y);

                for (int j = 0; j < YMAX + 1; j++)
                    Console.Write(lineBuffer[j]);

                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            drawSine();
        }
    }
}
