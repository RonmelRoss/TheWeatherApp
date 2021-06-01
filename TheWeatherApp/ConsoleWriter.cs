using System;
using Weather.Services.Model;

namespace TheWeatherApp
{
    class ConsoleWriter
    {
        public static string InputZipCode()
        {
            Console.Write("Please input ZIP code: ");
            string zipCode = Console.ReadLine();
            return zipCode;
        }

        public static void Output(ServiceResponse response)
        {
            if (response == null)
            {
                Console.WriteLine("Unable to fetch resources. Please check your connection.");
            }
            else if (response.ZipCodeValid == false)
            {
                Console.WriteLine("Invald ZIP Code");
            }
            else
            {
                Console.WriteLine("Should I go outside?");

                Console.WriteLine(response.GoOutSide ? "Yes" : "No");

                Console.WriteLine("Should I wear sunscreen?");

                Console.WriteLine(response.WearSunScreen ? "Yes" : "No");

                Console.WriteLine("Can I fly my kite?");

                Console.WriteLine(response.FlyKite ? "Yes" : "No");
            }
        }
    }
}
