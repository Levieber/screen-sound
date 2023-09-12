using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class RateAlbumOption : Option
{
    private List<Band> Bands { get; }

    public RateAlbumOption(List<Band> bands)
    {
        Bands = bands;
    }

    public override void Execute()
    {
        base.Execute();
        ShowTitleOption("Avalie um Álbim");

        Console.Write("Digite o nome da banda a qual contém o álbum: ");
        string? bandNameInput = Console.ReadLine();

        if (string.IsNullOrEmpty(bandNameInput))
        {
            Console.WriteLine("O nome da banda pode não ser vazio");
            return;
        }

        var band = Bands.Find(b => b.Name == bandNameInput);

        if (band is null)
        {
            Console.WriteLine($"A banda {bandNameInput} não foi encontrada! Use a opção 2 para visualizar as bandas registradas.");
            return;
        }

        Console.Write($"Digite o nome do álbum a ser avaliado: ");
        string? albumNameInput = Console.ReadLine();

        if (string.IsNullOrEmpty(albumNameInput)) {
            Console.WriteLine("O nome do álbum pode não ser vazio");
            return;
        }

        Console.Write($"Digite a nota que você deseja dar ao álbum {albumNameInput}: ");
        string? albumNoteInput = Console.ReadLine();

        if (string.IsNullOrEmpty(albumNoteInput))
        {
            Console.WriteLine("O nome pode não ser vazio");
            return;
        }

        if(!band.Albums.Any(a => a.Name == albumNameInput)) {
            Console.WriteLine($"O álbum {albumNameInput} da banda {band.Name} não foi encontrado");
            return;
        }

        var album = band.Albums.First(a => a.Name == albumNameInput);

        try
        {
            album.AddNote(Rating.Parse(albumNoteInput));
            Console.WriteLine($"A nota foi registrada com sucesso para o álbum {album.Name} da banda {band.Name}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}