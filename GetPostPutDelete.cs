/* var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//CRUD
//CREAT-POST
//READ-GET
//UPDATE-PUT
//PATCH-MUDAR SO UMA COISA
//DELETE-DELETE

// GET - Visualizando
app.MapGet("/alimentos", () =>
{
   List<string> massas = new List<string>
   {
    "Pizza",
    "Pastelão",
    "Coxinha"
    };

    return massas;
});

//POST -Criando
app.MapPost("/alimentos" , (string massa) =>
{
    return Results.Ok($"O alimento {massa} adicionado com sucesso!");
});

//PUT - Atualizando
app.MapPut("/alimentos/{id}" , (int id, string novaMassa) =>
{
    return Results.Ok($"Massa {id} sendo atualizada para {novaMassa}");
});

//PATCH - Atualizar pacialmente
app.MapPatch("/alimentos/{id}" ,(int id,string campo, string valor) =>
{
    return Results.Ok($"A massa {id} teve o {campo} atualizando pra {valor}");
});

//DELET-Remover
app.MapDelete("/alimentos/{id}" , (int id) =>
{
    return Results.Ok($"Massa {id} removida com sucesso!");
});

app.Run();
*/