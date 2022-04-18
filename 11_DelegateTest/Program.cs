using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 델리게이트 사용

namespace _11_DelegateTest
{
    class Program
    {
        static void add(int x, int y)
        {
            Console.WriteLine("add : "+ (x + y));
        }
        static void sub(int x, int y)
        {
            Console.WriteLine("sub : " + (x - y));
        }

        static void mul(int x , int y)
        {
            Console.WriteLine("mul : " + (x * y));
        }

        static void div(int x, int y)
        {
            Console.WriteLine("div : " + (x / y));
        }

        delegate void SampleDelegate(int x, int y); // argument가 두 개인 함수를 호출 할 때 사용하는 포인터 함수

        static void Main(string[] args)
        {
            SampleDelegate f = new SampleDelegate(add);
            SampleDelegate g = new SampleDelegate(sub);
            // function pointer처럼 선언해놓으면 코드를 짧게 처리할 수 있다
            f(10, 20);
            g(30, 20);

            Console.WriteLine("=========");

            SampleDelegate h;
            h = f + g; // 함수 두 개를 합쳐줄 수 있다

            h(10, 20); // 출력값은 함수 두 개가 똑같은 인자로 따로 실행된다

            Console.WriteLine("=========");

            h += new SampleDelegate(mul); // 이렇게 해도 함수가 하나로 합쳐진다

            h(20, 20);

            Console.WriteLine("=========");
            h -= f; // 이러면 delegate 안에서 f가 빠진다(add가 빠진다)

            h(20, 20);
        }
    }
}
