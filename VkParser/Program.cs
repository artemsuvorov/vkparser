using Microsoft.EntityFrameworkCore;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;
using VkParser.Data;
using VkParser.Services;

var builder = WebApplication.CreateBuilder(args);

var logFilepath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "Log.txt");
builder.Logging.ClearProviders();
builder.Logging.AddFile(logFilepath);

// Add services to the container.
builder.Services.AddSingleton<IVkApi>(sp =>
{
    var api = new VkApi();
    var accessToken = builder.Configuration["Config:AccessToken"];
    var parameters = new ApiAuthParams { AccessToken = accessToken };
    api.Authorize(parameters);
    return api;
});

builder.Services.AddSingleton<IVkService, VkService>();
builder.Services.AddSingleton<ITextService, TextService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
