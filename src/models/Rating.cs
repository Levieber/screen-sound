namespace ScreenSound.Models;

class Rating
{
    public int Note { get; }

    public Rating(int note)
    {
        if (note > 10)
        {
            Note = 10;
        }
        else if (note < 0)
        {
            Note = 0;
        }
        Note = note;
    }

    public static Rating Parse(string input)
    {
        if (!int.TryParse(input, out int note))
        {
            throw new ArgumentException("A nota precisa ser um número!");
        }

        return new Rating(note);
    }
}