using System.Collections.Immutable;
using VkParser.Utils;

namespace VkParser.Services;

public enum Casing
{
    CaseSensitive,
    CaseInsensitive
}

public interface ITextService
{
    ImmutableSortedDictionary<char, int> CountLetters(string text, Casing casing);
}

public class TextService : ITextService
{
    public ImmutableSortedDictionary<char, int> CountLetters(string text, Casing casing)
    {
        if (casing == Casing.CaseInsensitive)
            text = text.ToLower();
        var letters = text.GetLetters();
        return letters.CountUnique().ToImmutableSortedDictionary();
    }
}
