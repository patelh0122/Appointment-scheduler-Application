using System;
using System.Collections.Generic;

namespace test4
{
    class Question3
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
        static IEnumerable<String> GetTime(int start, int end)
        {
            for(int i = start; i <= end; i += 15)
            {
                int hour = i / 60;
                int minutes = i % 60;
                Round(ref hour, ref minutes);
                bool am = true;
                if(hour >= 12 && hour < 24)
                {
                    am = false;
                    hour -= 12;
                }
                if (hour == 0 || hour == 24)
                    hour = 12;
                String time = "";
                if (hour < 10)
                    time += "0";
                time += hour + ":";
                if (minutes < 10)
                    time += "0";
                time += minutes;
                if (am)
                {
                    time += " AM ";
                }
                else
                {
                    time += " PM ";
                }
                yield return time;
            }
        }

        static void Main(string[] args)
        {
            int start = int.Parse(args[0]);
            int end = int.Parse(args[1]);

            Console.Write("Calling SequenceTime(");
            Console.Write(start);
            Console.Write(", ");
            Console.Write(end);
            Console.WriteLine(")produces:");

            if(start < 0)
            {
                throw new ArgumentOutOfRangeException("Specified argument was out of the range of valid value. (Parameters 'firstTotal')");
            }
            if(end > 1440)
            {
                throw new ArgumentOutOfRangeException("Specified Argument was out of the range of valid value. (Parameters 'lastTotal'");
            }
            foreach (var i in GetTime(start, end))
                Console.Write(i);


        }
    }
}
