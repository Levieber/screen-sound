using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class RateBandOption : Option
{
    private List<Band> Bands { get; }

    public RateBandOption(List<Band> bands)
    {
        Bands = bands;
    }

    public override void Execute()
    {
        base.Execute();
        ShowTitleOption("Avalie uma Banda");

        Console.Write("Digite o nome da banda a ser avaliada: ");
        string? bandNameInput = Console.ReadLine();

        if (string.IsNullOrEmpty(bandNameInput))
        {
            Console.WriteLine("O nome pode não ser vazio");
            return;
        }

        var band = Bands.Find(b => b.Name == bandNameInput);

        if (band is null)
        {
            Console.WriteLine($"A banda {bandNameInput} não foi encontrada! Use a opção 2 para visualizar as bandas registradas.");
            return;
        }

        Console.Write($"Digite a nota que você deseja dar a banda {bandNameInput}: ");
        string? bandNoteInput = Console.ReadLine();

        if (string.IsNullOrEmpty(bandNoteInput))
        {
            Console.WriteLine("O nome pode não ser vazio");
            return;
        }

        try
        {
            band.AddNote(Rating.Parse(bandNoteInput));
            Console.WriteLine($"A nota foi registrada com sucesso para a banda {bandNameInput}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}