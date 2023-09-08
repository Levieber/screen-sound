namespace ScreenSound.Models;

class Music
{
    public string Name { get; }
    public Band Artist { get; }
    public int Duration { get; set; }
    public bool Available { get; set; }
    public string Summary => $"{Name} de {Artist.Name}";

    public Music(string name, Band artist)
    {
        Name = name;
        Artist = artist;
    }

    public void ShowTechnicalSheet()
    {
        System.Console.WriteLine($"{Summary} com duração de {(Duration / 60).ToString("F")} minutos");

        if (Available)
        {
            System.Console.WriteLine($"{Summary} está disponível no seu plano.\n");
        }
        else
        {
            System.Console.WriteLine($"{Summary} não disponível no seu plano. Adquira o Ultra Plus para conseguir acesso.\n");
        }
    }
}