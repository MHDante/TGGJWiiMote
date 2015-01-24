using System;

namespace TGGJWiiMote
{
    //HEHAHHEHASHHEAHEUHEUHEUHAUHEUAHEUHAEUHUEHRUASHJDIHAJDGFNokdsgjsflkg
    internal class Utils
    {
        public static bool YesOrNo()
        {
            while (true)
            {
                var response = Console.ReadLine();
                if (string.IsNullOrEmpty(response) || response.ToLower() == "Y" || response.ToLower() == "Yes")
                    return true;
                if (response.ToLower() == "N" || response.ToLower() == "No")
                    return false;
                Console.WriteLine("Incorrect input, try again");
            }
        }

        public static int ForceReadInt() {
            while (true) {
                var response = Console.ReadLine();
                int result;
                if (int.TryParse(response,out result)) return result;
                Console.WriteLine("Type a number!");
            }
        }
    }
}