using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Assignment10Ex4
{
    // These classes are intentionally empty for the purpose of this example.
    internal class Alarm { }
    internal class Teeth { }
    internal class Shower { }
    internal class Dress { }
    internal class Drive { }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                TurnOffAlarm();
                Console.WriteLine("Out of bed and ready to go");

                BrushTeeth();
                Console.WriteLine("Teeth are clean");

                Shower shower = TakeAShower();
                Console.WriteLine("Showering is done");

                GetDressed();
                Console.WriteLine("Dressed and ready to go");

                Drive drive = DriveToWork(10);
                Console.WriteLine("Walking into work.");

                Console.WriteLine("Ready to begin");
                sw.Stop();
                Console.WriteLine("The program took " + sw.ElapsedMilliseconds + " milliseconds to run");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"An exception has occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void TurnOffAlarm()
        {
            Console.WriteLine("Turned off alarm");
            return;
        }


        private static void BrushTeeth() => Console.WriteLine("Putting paste on the brush... Brushing");


        private static Shower TakeAShower()
        {
            Console.WriteLine("Warming the water...");
            Task.Delay(1000);
            Console.WriteLine($"Shampoo and Condition the hair");
            Console.WriteLine("Rinse off");
            Task.Delay(2000);
            Console.WriteLine("Dry off");
            return new Shower();
        }

        private static void GetDressed() => Console.WriteLine("Together and ready to go");

        private static Drive DriveToWork(int time)
        {
            Console.WriteLine("Starting the car...");
            for (int i = 0; i < time; i++)
            {
                Console.WriteLine($"Driving...");
            }
            Task.Delay(1000);
            Console.WriteLine("Arrived at work");
            return new Drive();
        }
    }
}
2.There are 3 methods you need to convert: DriveToWork, TakeAShower and Main.

a) Add await before all occurrences of Task.Delay() in the 3 methods.

b) Add async to the method signatures

If the signature is returning a class object, then you will need to include the Class as the data type for the Task

Example:

convert

private static Shower TakeAShower()

to

private static async Task<Shower> TakeAShowerAsync()

c) Add await before the method call in Main

Example:

convert

Shower shower = TakeAShower();

to

Shower shower = await TakeAShowerAsync();
