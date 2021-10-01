using System;
using System.Collections.Generic;

namespace question4
{
    class Program
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
        static String GetTime (int hour, int minutes)
        {
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
                time += " AM ";
            else
            {
                time += " PM ";
            }
            return time;
        }
        static String GetTimeFromNumber(int minute)
        {
            int hour = minute / 60;
            int minutes = minute % 60;
            Round(ref hour, ref minutes);
            bool am = true;
            if (hour >= 12 && hour < 24)
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
                time += " AM ";
            else
            {
                time += " PM ";
            }
            return time;
        }
        static int GetNumberFromTime(int hour, int minute)
        {
            return hour * 60 + minute;
        }
        static void Main(string[] args)
        {
            int opt = 1;

            Dictionary<int, String> calendar = new Dictionary<int, string>();
            while (true)
            {
                Console.WriteLine("Welcome to the scheduling App \n Enter 1 to schedule \n Enter 0 to exit");
                opt = int.Parse(Console.ReadLine());
                if (opt != 1)
                    break;
                Console.WriteLine("Enter starting hour");
                int start_hour = int.Parse(Console.ReadLine());
                while(!(start_hour >= 0 && start_hour < 24))
                {
                    Console.WriteLine("Enter a valid hour between range 0 and 23.");
                    start_hour = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter starting minute:");
                int start_minute = int.Parse(Console.ReadLine());
                while(!(start_minute >= 0 && start_minute < 60))
                {
                    Console.WriteLine("Enter a valid minute between range 0 and 59");
                    start_minute = int.Parse(Console.ReadLine());
                }

                //Checking if already exists
                Round(ref start_hour, ref start_minute);
                int start_num = GetNumberFromTime(start_hour, start_minute);
                if (calendar.ContainsKey(start_num))
                {
                    Console.WriteLine("Whoops, There is already a Schedule there!");
                    continue;
                }
                Console.WriteLine("Enter ending Hour:");
                int end_hour = int.Parse(Console.ReadLine());
                while(!(end_hour >= 0 && end_hour < 24))
                {
                    Console.WriteLine("Enter a valid Hour between Range 0  and 23.");
                    end_hour = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter ending Minute:");
                int end_minute = int.Parse(Console.ReadLine());
                while(!(end_minute >=0 && end_minute < 60))
                {
                    Console.WriteLine("Enter a valid minute between Range 0 and 59.");
                    end_minute = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter Message:");
                String message = Console.ReadLine();
                while (message.Equals(""))
                {
                    Console.WriteLine("Enter a Valid message");
                    message = Console.ReadLine();
                }
                Round(ref end_hour, ref end_minute);
                int end_num = GetNumberFromTime(end_hour, end_minute);

                for (int i = start_num; i < end_num; i += 15)
                    calendar.Add(i, message);
            }
            string prev = "";
            Console.WriteLine("-------------------------------------------------------");
            for(int i = 480;i <= 1020; i += 15)
            {
                if (calendar.ContainsKey(i))
                {
                    if (prev.Equals(calendar[i]))
                    {
                        Console.Write(GetTimeFromNumber(i));
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.Write(GetTimeFromNumber(i));
                        Console.Write("\t");
                        Console.WriteLine(calendar[i]);
                    }
                    prev = calendar[i];
                }
                else
                {
                    Console.WriteLine("-------------------------------------------------------");
                    prev = "";
                    Console.WriteLine(GetTimeFromNumber(i));
                }
            }
            Console.WriteLine("-------------------------------------------------------------");
        }
    }
}
