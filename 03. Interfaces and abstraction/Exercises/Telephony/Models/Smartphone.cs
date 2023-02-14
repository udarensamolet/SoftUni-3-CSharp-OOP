using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICalling, IBrowsing
    {
        public Smartphone() 
        {
        }

        public string Browse(string website)
        {
            foreach (var letter in website)
            {
                if (char.IsDigit(letter))
                {
                    return $"Invalid URL!";
                }
            }
            return $"Browsing: {website}!";
        }

        public string Call(string number)
        {
            foreach(var digit in number)
            {
                if(!char.IsNumber(digit))
                {
                    return $"Invalid number!";
                }
            }
            return $"Calling... {number}";
        }
    }
}
