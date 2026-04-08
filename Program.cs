using CardapioAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.
UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//GET por all
var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/bebidas" , async (AppDbContext db) =>
{
    return await db.Bebidas.ToListAsync(); 
});

//GET com id
app.MapGet("/bebidas/{id}" , async (AppDbContext db,int id) => 
{
    var bebidas = await db.Bebidas.FindAsync(id);
    return bebidas;
});

//POST
app.MapPost("/bebidas", async (AppDbContext db,Bebida novaBebida) =>
{
    db.Bebidas.Add(novaBebida);
    await db.SaveChangesAsync();
    return Results.Created($"/A bebida {novaBebida} foi adcionada com sucesso!",novaBebida);
});

//PUT
app.MapPut("/bebidas/{id}", async (int id,AppDbContext db,Bebida novaBebida) =>
{
    var bebidas = await db.Bebidas.FindAsync(id);
    if (bebidas is null) return Results.NotFound();

    bebidas.Nome = novaBebida.Nome;
    bebidas.Tipo = novaBebida.Tipo;
    bebidas.Preço = novaBebida.Preço;

    await db.SaveChangesAsync();
    return Results.Ok(bebidas);

});

//DELETE
app.MapDelete("/bebidas/{id}", async (int id,AppDbContext db ) =>
{
    var bebida = await db.Bebidas.FindAsync(id);
    if (bebida is null) return Results.NotFound("Bebida não existente!");

    db.Bebidas.Remove(bebida);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
