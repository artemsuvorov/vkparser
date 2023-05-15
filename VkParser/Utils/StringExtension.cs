namespace VkParser.Utils;

internal static class StringExtensions
{
    public static IEnumerable<char> GetLetters(this string text)
    {
        return text.Where(c => char.IsLetter(c));
    }
}
