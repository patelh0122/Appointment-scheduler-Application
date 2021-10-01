using System;

namespace test4
{
    class Question1
    {
        static void Round(ref int a, ref int b)
        {
            int remainder = b % 15;
            b -= remainder;
            if (remainder > (15 / 2))
                b += 15;
            if(b == 60)
            {
                b = 0;
                a += 1;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the hour:");
            int a = int.Parse(Console.ReadLine());
            while(!(a >= 0 && a < 24))
            {
                Console.WriteLine("Enter a valid hour between range 0 and 23.");
                a = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Enter the minute");
            int b = int.Parse(Console.ReadLine());
            while(!(b >= 0 && b < 60))
            {
                Console.WriteLine("Enter a valid Minute between 0 and 59.");
                b = int.Parse(Console.ReadLine());
            }
            Round(ref a, ref b);
            Console.Write("The time is ");
            Console.Write(a);
            Console.Write(":");
            if (b < 10)
                Console.Write(0);
            Console.Write(b);

        }
    }
}
