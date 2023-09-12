namespace ScreenSound.Models;

internal class Band : IRateable
{
    private readonly List<Album> albums = new();
    private List<Rating> notes = new();
    public string Name { get; }
    public double Average => notes.Count != 0 ? notes.Average(n => n.Note) : 0;
    public IEnumerable<Album> Albums => albums;

    public Band(string name)
    {
        Name = name;
    }

    public void AddAlbum(Album album)
    {
        albums.Add(album);
    }

    public void AddNote(Rating note)
    {
        notes.Add(note);
    }

    public void ShowAlbums()
    {
        Console.WriteLine($"Álbuns da banda {Name}:\n");
        foreach (var album in albums)
        {
            Console.WriteLine($"- {album.Name} ({(album.Duration / 60).ToString("F")} min)");
        };
    }
}