using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiimoteLib;
namespace TGGJWiiMote
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            while (PendingRestart)
            {
                Game game = new Game();

                while (!game.IsExiting || IsRestarting)
                {
                    game.Update();
                }
            }

            Console.WriteLine("Thank you for playing! Press any key to exit.");
            Console.ReadKey();

        }

        public static bool IsRestarting { get; set; }

        public static bool PendingRestart { get; set; }
    }
}
