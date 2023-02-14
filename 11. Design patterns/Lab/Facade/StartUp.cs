namespace Facade
{
    public class StartUp 
    {
        static void Main()
        {
            var car = new CarBuilderFacade()
                .Info
                    .WithType("BMW")
                    .WithColor("Black")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Leipzig")
                    .AtAddress("SomeAddress 254")
                .Build();

            Console.WriteLine(car);
        }
    }
}