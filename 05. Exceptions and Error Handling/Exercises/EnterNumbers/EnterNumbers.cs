namespace EnterNumbers
{
    public class EnterNumbers
    {
        static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            ReadNumber(start, end);
        }

        static void ReadNumber(int start, int end)
        {
            int count = 0;
            int prevNumber = int.MinValue;

            while (count < 10)
            {
                try
                {
                    string n = Console.ReadLine();
                    if (!int.TryParse(n, out int result))
                    {
                        throw new Exception("Number is not valid!");
                    }
                    else
                    {
                        if (result < start || result > end)
                        {
                            throw new Exception("Number is out of range!");
                        }
                        if (result < prevNumber)
                        {
                            throw new Exception("Number is larger than the previous one! Start again!");
                        }
                        count++;
                        prevNumber = result;
                    }
                }
                catch (Exception ex)
                {
                    prevNumber = int.MinValue;
                    count = 0;
                    Console.WriteLine(ex.Message);
                }
                
            }
            
        }
    }
}