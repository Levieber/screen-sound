using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class ShowBandsOption : Option
{
    private List<Band> Bands { get; }

    public ShowBandsOption(List<Band> bands)
    {
        Bands = bands;
    }

    public override void Execute()
    {
        base.Execute();
        ShowTitleOption("Bandas Registradas");
        foreach (var band in Bands)
        {
            Console.WriteLine($"- Banda {band.Name}");
        }
    }
}