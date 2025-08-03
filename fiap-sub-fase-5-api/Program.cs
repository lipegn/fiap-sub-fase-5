using fiap_sub_fase_5_api;

var builder = WebApplication.CreateBuilder(args);

// (opcional) sempre gerar endpoints do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilite Swagger também em produção (ou condicione por variável de ambiente)
app.UseSwagger();
app.UseSwaggerUI();

// Redireciona a raiz para o Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

// Endpoint padrão do template continua:
app.MapGet("/weatherforecast", () =>
{
    var summaries = new[] { "Freezing","Bracing","Chilly","Cool","Mild",
                            "Warm","Balmy","Hot","Sweltering","Scorching" };
    return Enumerable.Range(1, 5).Select(index =>
        new PrevisaoTempo
        {
            Cidade = "Cidade",
            Data = DateTime.Now,
            TemperaturaC = 10,
            Resumo = "ObterResumo(temperaturaC)"
        }
        ).ToArray();
});

app.Run();