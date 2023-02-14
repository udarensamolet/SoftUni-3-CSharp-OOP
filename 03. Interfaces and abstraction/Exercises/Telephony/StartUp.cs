using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            string[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] websites = Console.ReadLine()
             .Split(' ', StringSplitOptions.RemoveEmptyEntries)
             .ToArray();

            foreach (var number in numbers) 
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                else if (number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(number));
                }
            }

            foreach (var website in websites)
            {
                Console.WriteLine(smartphone.Browse(website));
            }
        }
    }
}