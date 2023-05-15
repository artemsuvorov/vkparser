namespace VkParser.Utils;

internal static class EnumerableExtensions
{
    public static IReadOnlyDictionary<T, int> CountUnique<T>(this IEnumerable<T> source)
        where T : struct
    {
        return source
            .GroupBy(item => item, (unique, duplicates) => new 
            { 
                Item = unique, 
                Count = duplicates.Count() 
            })
            .ToDictionary(x => x.Item, x => x.Count);
    }
}
