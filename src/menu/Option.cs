namespace ScreenSound.Menu;

internal class Option
{
    protected static void ShowTitleOption(string title)
    {
        int length = title.Length;
        string asterisks = string.Empty.PadLeft(length, '*');
        Console.WriteLine(asterisks);
        Console.WriteLine(title);
        Console.WriteLine(asterisks + "\n");
    }

    public virtual void Execute() {
        Console.Clear();
    }
}