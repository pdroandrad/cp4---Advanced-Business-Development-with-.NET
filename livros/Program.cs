using livros.Models;
using livros.Services;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ConfiguracaoMongoDB>(
    builder.Configuration.GetSection("ConfiguracaoMongoDb"));

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var config = sp.GetRequiredService<IOptions<ConfiguracaoMongoDB>>().Value;
    return new MongoClient(config.StringConexao);
});

builder.Services.AddSingleton(sp =>
{
    var config = sp.GetRequiredService<IOptions<ConfiguracaoMongoDB>>().Value;
    var cliente = sp.GetRequiredService<IMongoClient>();
    var banco = cliente.GetDatabase(config.NomeBanco);
    return banco.GetCollection<Livro>(config.NomeColecaoLivros);
});

builder.Services.AddSingleton<ServicoLivros>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();