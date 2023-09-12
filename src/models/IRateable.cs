namespace ScreenSound.Models;

internal interface IRateable
{
    void AddNote(Rating note);
    double Average { get; }
}