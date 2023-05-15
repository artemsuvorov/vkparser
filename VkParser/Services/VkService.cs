using VkNet.Abstractions;
using VkNet.Model.RequestParams;

namespace VkParser.Services;

public interface IVkService
{
    string GetUserFullname(string userDomain);
    IEnumerable<string> GetWallPosts(string userDomain, ulong postCount);
}

public class VkService : IVkService
{
    private readonly IVkApi api;

    public VkService(IVkApi api)
    {
        this.api = api;
    }

    public string GetUserFullname(string userDomain)
    {
        var domains = new string[] { userDomain };
        var user = api.Users.Get(domains).FirstOrDefault();
        if (user is null)
            throw new ArgumentException($"User with id={userDomain} was not found");
        return $"{user.FirstName} {user.LastName}";
    }

    public IEnumerable<string> GetWallPosts(string userDomain, ulong postCount)
    {
        var parameters = new WallGetParams
        {
            OwnerId = 0,
            Domain = userDomain,
            Count = postCount
        };
        var wall = api.Wall.Get(parameters);
        if (wall is null)
            throw new ArgumentException($"User with id={userDomain} was not found.");
        return wall.WallPosts.Select(p => p.Text);
    }
}