string text = Console.ReadLine();
string digits = "";
string letters = "";
string otherChars = "";

foreach (char ch in text)
{
    if (char.IsDigit(ch))
    {
        digits += ch;
    }
    else if (char.IsLetter(ch))
    {
        letters += ch;
    }
    else if (!char.IsLetterOrDigit(ch))
    {
        otherChars += ch;
    }
}

Console.WriteLine(digits);
Console.WriteLine(letters);
Console.WriteLine(otherChars);