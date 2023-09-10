namespace ScreenSound.Models;

internal class Band {
    private List<Album> albums = new();
    private List<int> notes = new();
    public string Name { get;  }
    public double Average => notes.Count != 0 ? notes.Average() : 0;

    public Band(string name) {
        Name = name;
    }

    public void AddAlbum(Album album) {
        albums.Add(album);
    }

    public void AddNote(int note) {
        notes.Add(note);
    }

    public void ShowAlbums() {
        Console.WriteLine($"Álbuns da banda {Name}:\n");
        foreach (var album in albums)
        {
            Console.WriteLine($"- {album.Name} ({(album.Duration / 60).ToString("F")} min)");
        };
    }
}