namespace ScreenSound.Models;

internal class Album : IRateable
{
    private List<Rating> notes = new();
    private List<Music> musics = new();
    public string Name { get; set; }
    public Band Creator { get; }
    public int Duration => musics.Sum(m => m.Duration);

    public double Average => notes.Count != 0 ? notes.Average(n => n.Note) : 0;

    public Album(string name, Band creator)
    {
        Name = name;
        Creator = creator;
    }

    public void AddMusic(Music music)
    {
        musics.Add(music);
    }

    public void AddNote(Rating note)
    {
        notes.Add(note);
    }

    public void Summary()
    {
        Console.WriteLine($"Músicas do album {Name} de {Creator}:\n");
        foreach (var music in musics)
        {
            Console.WriteLine($"- {music.Summary}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro, você precisa de {(Duration / 60).ToString("F")} minutos");
    }
}