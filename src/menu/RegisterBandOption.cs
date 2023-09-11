using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class RegisterBandOption : Option
{
    private List<Band> Bands { get; }

    public RegisterBandOption(List<Band> bands)
    {
        Bands = bands;
    }

    public override void Execute()
    {
        base.Execute();
        ShowTitleOption("Registro de Bandas");

        Console.Write("Digite o nome da banda que deseja registrar: ");
        string? bandName = Console.ReadLine();

        if (string.IsNullOrEmpty(bandName))
        {
            Console.WriteLine("Insira o nome da banda!");
            return;
        }

        Bands.Add(new Band(bandName));
        Console.WriteLine($"\nA banda {bandName} foi registrada com sucesso!");
    }
}