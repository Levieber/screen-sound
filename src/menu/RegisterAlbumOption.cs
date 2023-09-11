using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class RegisterAlbumOption : Option
{
    private List<Band> Bands { get; }

    public RegisterAlbumOption(List<Band> bands)
    {
        Bands = bands;
    }

    public override void Execute()
    {
        base.Execute();
        ShowTitleOption("Registro de Álbum");

        Console.Write("Digite a banda cujo álbum deseja registrar: ");
        string? bandNameInput = Console.ReadLine();

        if (string.IsNullOrEmpty(bandNameInput))
        {
            Console.WriteLine("Insira o nome da banda!");
            return;
        }

        Console.Write("Digite o nome do álbum: ");
        string? albumNameInput = Console.ReadLine();

        if (string.IsNullOrEmpty(albumNameInput))
        {
            Console.WriteLine("Insira o nome da banda!");
            return;
        }

        var band = Bands.Find(b => b.Name == bandNameInput);

        if (band is null)
        {
            Console.WriteLine($"A banda {bandNameInput} não foi encontrada! Use a opção 2 para visualizar as bandas registradas.");
            return;
        }

        band.AddAlbum(new Album(albumNameInput, band));
        Console.WriteLine($"Álbum {albumNameInput} da banda {band.Name} cadastrado com sucesso!");
    }
}