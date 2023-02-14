using Stealer.Models;

namespace Stealer
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods("Stealer.Models.Hacker");
            Console.WriteLine(result);
        }
    }
}