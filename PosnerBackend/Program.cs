using Microsoft.EntityFrameworkCore;
using PosnerBackend;
using PosnerBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql("Server=postgres;Port=5432;Database=posner;Username=postgres;Password=postgres"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<GameResultRepository>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
);
app.MapControllers();

while (true)
{
    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        db.Database.Migrate();
        break;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

app.Run();