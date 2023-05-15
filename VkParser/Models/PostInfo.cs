namespace VkParser.Models;

public class PostInfo
{
    public int Id { get; set; }
    public string? VkDomain { get; set; }
    public string? VkUsername { get; set; }
    public char[]? Letters { get; set; }
    public int[]? Counters { get; set; }
}
