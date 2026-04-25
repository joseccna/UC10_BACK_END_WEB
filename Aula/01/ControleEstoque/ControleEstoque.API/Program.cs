using ControleEstoque.API.Data;
using ControleEstoque.API.Models;
using ControleEstoque.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));



builder.Services.AddScoped<IPedidoService, PedidoService>();

//Registrar o serviço de fornecedor para injeção de dependência, permitindo que os controladores e outros serviços possam utilizar a interface IFornecedorService para acessar as funcionalidades relacionadas aos fornecedores, promovendo uma arquitetura mais modular e facilitando a manutenção do código
builder.Services.AddScoped<IFornecedorService, FornecedorService>();

builder.Services.AddScoped<IContaReceber, ContaReceberService>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();




// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>

{

    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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


