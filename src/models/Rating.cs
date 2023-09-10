namespace ScreenSound.Models;

class Rating
{
    public int Note { get; }

    public Rating(int note)
    {
        Note = note;
    }

    public static Rating Parse(string input)
    {
        if (int.TryParse(input, out int note))
        {
            return new Rating(note);
        }
        else
        {
            throw new ArgumentException("A nota precisa ser um inteiro!");
        }
    }
}