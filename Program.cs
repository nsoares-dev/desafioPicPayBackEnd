using Desafio_PicPay.DB;
using Desafio_PicPay.Repositorio.Carteiras;
using Desafio_PicPay.Repositorio.Transferencias;
using Microsoft.EntityFrameworkCore;
using Desafio_PicPay.Models;
using Desafio_PicPay.Services.Carteiras;
using Desafio_PicPay.Services.Autorizador;
using Desafio_PicPay.Services.Notificacao;
using Desafio_PicPay.Services.Transferencias;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Banco de Dados

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

builder.Services.AddScoped<ICarteiraRepository, CarteiraRepository>();
builder.Services.AddScoped<ITransferenciaRepository, TransferenciaRepository>();
builder.Services.AddScoped<ICarteiraService, CarteiraService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
builder.Services.AddScoped<ITransferenciaService, TransferenciaService>();

builder.Services.AddHttpClient<IAutorizadorService, AutorizadorService>();


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
