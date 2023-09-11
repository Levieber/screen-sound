using ScreenSound.Models;

namespace ScreenSound.Menu;

internal class Menu
{
    private Dictionary<int, Option> menuOptions = new();

    public Menu(List<Band> bands)
    {
        menuOptions.Add(1, new RegisterBandOption(bands));
        menuOptions.Add(2, new RegisterAlbumOption(bands));
        menuOptions.Add(3, new ShowBandsOption(bands));
        menuOptions.Add(4, new RateBandOption(bands));
        menuOptions.Add(5, new ShowBandDetailsOption(bands));
    }

    private static void ShowMenuOptions()
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
        Console.WriteLine("(5): detalhes de uma banda");
        Console.WriteLine("(-1): sair do programa");


        Console.Write("\nDigite sua opção: ");
    }

    public void Execute()
    {
        ShowMenuOptions();
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

        if (menuOptions.ContainsKey(chosen))
        {
            menuOptions[chosen].Execute();
        }
        else
        {
            Console.WriteLine("Digite uma opção válida!");
        }

        Thread.Sleep(750);
        Execute();
    }
}