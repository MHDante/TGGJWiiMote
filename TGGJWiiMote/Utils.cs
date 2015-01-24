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
    }
}