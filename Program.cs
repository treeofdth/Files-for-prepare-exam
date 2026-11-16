using BeautyApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BeautySalonDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/notes/{id:int}", async (int id, BeautySalonDbContext db) =>
{
    try
    {
        if (id <= 0) return Results.BadRequest("Id must be more than zero!");

        var notes = await db.Notes.Include(x => x.IdUserNavigation).Where(x => id == null || x.IdUser == id).ToListAsync();

        return Results.Ok(notes.Select(x => new
        {
            id = x.Id,
            title_user = $"{x.Title} - {x.IdUserNavigation?.Login}",
            content = x.Content,
            formatted_date = x.CreatedAt?.ToString("dd.MM.yyyy")
        }));
    }

    catch
    {
        return Results.InternalServerError("Error connecting to database!");
    }
});

app.Run();
