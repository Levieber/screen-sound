using ScreenSound.Models;

List<Band> bands = new();

void ShowMenuOptions()
{
    Console.Clear();
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("\nDigite o número de uma das opções abaixo:");
    Console.WriteLine("(1): registrar banda");
    Console.WriteLine("(2): registrar álbum de uma banda");
    Console.WriteLine("(3): mostrar todas as bandas");
    Console.WriteLine("(4): avaliar uma banda");
    Console.WriteLine("(5): média de uma banda");
    Console.WriteLine("(-1): sair do programa");


    Console.Write("\nDigite sua opção: ");
    HandleMenu();
}

void HandleMenu()
{
    string? input = Console.ReadLine();

    if (input == null || input == "")
    {
        Console.WriteLine("Insira um valor!");
        return;
    }

    if (!int.TryParse(input, out int chosen))
    {
        Console.WriteLine("Coloque um número válido!");
        return;
    }

    if (chosen == -1)
    {
        Console.WriteLine("\nSaindo do programa...");
        Console.WriteLine("Tchau, tchau :)");
        return;
    }

    switch (chosen)
    {
        case 1:
            {
                RegisterBand();
                break;
            };
        case 2:
            {
                RegisterAlbum();
                break;
            };
        case 3:
            {
                ShowBands(bands);
                break;
            };
        case 4:
            {
                EvaluateBand(bands);
                break;
            };
        case 5:
            {
                ShowBandDetails(bands);
                break;
            };
        default:
            {
                Console.Clear();
                ShowMenuOptions();
                break;
            };
    }

    Thread.Sleep(750);
    ShowMenuOptions();
}

void ShowTitleOption(string title)
{
    int length = title.Length;
    string asterisks = string.Empty.PadLeft(length, '*');
    Console.WriteLine(asterisks);
    Console.WriteLine(title);
    Console.WriteLine(asterisks + "\n");
}

void RegisterBand()
{
    Console.Clear();
    ShowTitleOption("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string? bandName = Console.ReadLine();

    if (string.IsNullOrEmpty(bandName))
    {
        Console.WriteLine("Insira o nome da banda!");
        return;
    }

    bands.Add(new Band(bandName));
    Console.WriteLine($"\nA banda {bandName} foi registrada com sucesso!");
}

void RegisterAlbum()
{
    Console.Clear();
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

    var band = bands.Find(b => b.Name == bandNameInput);

    if (band is null)
    {
        Console.WriteLine($"A banda {bandNameInput} não foi encontrada! Use a opção 2 para visualizar as bandas registradas.");
        return;
    }


    band.AddAlbum(new Album(albumNameInput, band));
    Console.WriteLine($"Álbum {albumNameInput} da banda {band.Name} cadastrado com sucesso!");
}

void ShowBands(List<Band> bands)
{
    Console.Clear();
    ShowTitleOption("Bandas Registradas");
    foreach (var band in bands)
    {
        Console.WriteLine($"- Banda {band.Name}");
    }
}

void EvaluateBand(List<Band> bands)
{
    Console.Clear();
    ShowTitleOption("Avalie uma Banda");

    Console.Write("Digite o nome da banda a ser avaliada: ");
    string? bandNameInput = Console.ReadLine();

    if (string.IsNullOrEmpty(bandNameInput))
    {
        Console.WriteLine("O nome pode não ser vazio");
        return;
    }

    var band = bands.Find(b => b.Name == bandNameInput);

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

    if (!int.TryParse(bandNoteInput, out int bandNote))
    {
        Console.WriteLine("A nota tem que ser um número inteiro!");
        return;
    };

    band.AddNote(bandNote);
    Console.WriteLine($"A nota foi registrada com sucesso para a banda {bandNameInput}");
}

void ShowBandDetails(List<Band> bands)
{
    Console.Clear();
    ShowTitleOption("Média da Banda");

    Console.Write("Digite o nome da banda a ter média visualizada: ");
    string? bandNameInput = Console.ReadLine();

    if (string.IsNullOrEmpty(bandNameInput))
    {
        Console.WriteLine("O nome pode não ser vazio");
        return;
    }

    var band = bands.Find(b => b.Name == bandNameInput);

    if (band is null)
    {
        Console.WriteLine($"A banda {bandNameInput} não encontrada! Use a opção 2 para visualizar as bandas registradas.");
        return;
    }

    Console.WriteLine($"A banda {band.Name} contém a média de notas de {band.Average}.");
}

ShowMenuOptions();