using CardapioAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=cardapio_digital;Username=cardapio_app;Password=cardapio1234")
           .UseSnakeCaseNamingConvention());

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
app.MapPost("/bebidas", async (AppDbContext db,BebidaDto dto) =>
{
    var novaBebida = new Bebida
    {
        Nome = dto.Nome,
        Tipo = dto.Tipo,
        Preco = dto.Preco
    };
    db.Bebidas.Add(novaBebida);
    await db.SaveChangesAsync();
    return Results.Created($"/A bebida {novaBebida} foi adcionada com sucesso!",novaBebida);
});

//PUT
app.MapPut("/bebidas/{id}", async (int id,AppDbContext db,BebidaDto dto) =>
{
    var bebidas = await db.Bebidas.FindAsync(id);
    if (bebidas is null) return Results.NotFound();

    bebidas.Nome = dto.Nome;
    bebidas.Tipo = dto.Tipo;
    bebidas.Preco = dto.Preco;

    await db.SaveChangesAsync();
    return Results.Ok(bebidas);

});

app.MapPatch("/bebidas/{id}", async (int id, AppDbContext db, BebidaDto dto) =>
{
    var bebida = await db.Bebidas.FindAsync(id);
    if (bebida is null)
        return Results.NotFound();

    if (dto.Nome is not null)
        bebida.Nome = dto.Nome;

    if (dto.Tipo is not null)
        bebida.Tipo = dto.Tipo;

    if (dto.Preco is not null)
        bebida.Preco = dto.Preco.Value;

    await db.SaveChangesAsync();

    return Results.Ok(bebida);
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
