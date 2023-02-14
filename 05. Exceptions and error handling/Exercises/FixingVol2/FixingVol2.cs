namespace FixingVol2
{
    public class FixingVol2
    {
        static void Main()
        {
            int num1, num2;
            byte result = 0;

            num1 = 30;
            num2 = 60;
            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} x {num2} x {result}");
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            Console.ReadLine();
        }
    }
}