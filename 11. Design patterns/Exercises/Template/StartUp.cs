namespace Template.Models;

public class StartUp
{
    static void Main()
    {
        SourDough sourdough = new SourDough();
        sourdough.Make();

        TwelveGrain twelvegrain = new TwelveGrain();
        twelvegrain.Make();

        WholeWheat wholewheat = new WholeWheat();
        wholewheat.Make();
    }
}