using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using VkParser.Data;
using VkParser.Services;

namespace VkParser.Controllers;

[ApiController]
[Route("[controller]")]
public class VkController : ControllerBase
{
    private const ulong MaxPostCount = 5;

    private readonly IVkService vkService;
    private readonly ITextService textService;
    private readonly ILogger<VkController> logger;

    private readonly AppDbContext context;

    public VkController(IVkService vkService, ITextService textService, 
        ILogger<VkController> logger, AppDbContext context)
    {
        this.vkService = vkService;
        this.textService = textService;
        this.logger = logger;
        this.context = context;
    }

    [HttpGet("{domain}")]
    public async Task<ActionResult<ImmutableSortedDictionary<char, int>>> Get(string domain)
    {
        try
        {
            var fullname = vkService.GetUserFullname(domain);
            logger.LogInformation("Post parsing started for user: {fullname}", fullname);

            var posts = vkService.GetWallPosts(domain, MaxPostCount).ToArray();
            var text = string.Join("\r\n", posts);
            var counters = textService.CountLetters(text, Casing.CaseInsensitive);
            logger.LogInformation("Post parsing stopped: processed {count} posts", posts.Length);

            var postInfo = new Models.PostInfo 
            {
                VkDomain = domain,
                VkUsername = fullname,
                Letters = counters.Keys.ToArray(),
                Counters = counters.Values.ToArray()
            };
            context.Add(postInfo);
            await context.SaveChangesAsync();

            return counters;
        } 
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}