using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiimoteLib;
namespace TGGJWiiMote
{
    class Program
    {
        public static bool IsRestarting = true;
        private static long prevTime;
        private static Stopwatch _stopwatch;
        
        static void Main(string[] args)
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            prevTime = _stopwatch.ElapsedMilliseconds;
            Console.WriteLine("Welcome!");
            while (IsRestarting)
            {
                IsRestarting = false;
                
                Game game = new Game();

                while (!game.IsExiting && !IsRestarting)
                {
                    game.Update((int)(_stopwatch.ElapsedMilliseconds -prevTime));
                    prevTime = _stopwatch.ElapsedMilliseconds;

                }
            }

            Console.WriteLine("Thank you for playing! Press any key to exit.");
            Console.ReadKey();

        }
    }
}
