try
{
    string input = Console.ReadLine();

    if (!int.TryParse(input, out int result))
    {
        throw new FormatException();
    }
    if (result < 0)
    {
        throw new FormatException();
    }
    Console.WriteLine(Math.Sqrt(result));
}
catch (FormatException)
{
    Console.WriteLine("Invalid number");
}
finally
{
    Console.WriteLine("Good bye!");
}


