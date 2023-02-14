try
{
    double input = Convert.ToDouble(Console.ReadLine());
    throw new InvalidCastException();
    throw new FormatException();
    throw new OverflowException();
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch(InvalidCastException ex)
{
    Console.WriteLine(ex.Message);
}
catch (OverflowException ex)
{
    Console.WriteLine(ex.Message);
}
