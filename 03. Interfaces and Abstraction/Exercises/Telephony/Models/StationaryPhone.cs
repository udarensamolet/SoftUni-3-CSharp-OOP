using Telephony.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICalling
    {
        public string Call(string number)
        {
            foreach (var digit in number)
            {
                if (!char.IsNumber(digit))
                {
                    return $"Invalid number!";
                }
            }
            return $"Dialing... {number}";
        }
    }
}
