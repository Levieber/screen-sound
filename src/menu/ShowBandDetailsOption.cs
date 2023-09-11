using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class ShowBandDetailsOption : Option
{
    private List<Band> Bands { get; }

    public ShowBandDetailsOption(List<Band> bands)
    {
        Bands = bands;
    }

    public override void Execute()
    {
        base.Execute();
        ShowTitleOption("Detalhes da Banda");

        Console.Write("Digite o nome da banda a ter detalhes visualizados: ");
        string? bandNameInput = Console.ReadLine();

        if (string.IsNullOrEmpty(bandNameInput))
        {
            Console.WriteLine("O nome não pode ser vazio");
            return;
        }

        var band = Bands.Find(b => b.Name == bandNameInput);

        if (band is null)
        {
            Console.WriteLine($"A banda {bandNameInput} não foi encontrada! Use a opção 2 para visualizar as bandas registradas.");
            return;
        }

        Console.WriteLine($"A banda {band.Name} contém a média de avaliação de {band.Average}.");
    }
}