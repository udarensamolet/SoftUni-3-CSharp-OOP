namespace CustomException
{
    public class StartUp
    {
        static void Main()
        {
            try
            {
                Student student = new Student("Gen4o", "gencho@students.com");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
