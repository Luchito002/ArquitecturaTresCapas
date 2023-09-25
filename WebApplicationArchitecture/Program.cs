using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Mvc.Controllers;
using static LN.PersonaLN;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la sesión
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Configura el tiempo de espera de la sesión si es necesario.
});

// Configurar el almacenamiento en memoria
builder.Services.AddDistributedMemoryCache();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Configurar el middleware de sesión
app.UseSession();

app.MapControllers();

app.Run();

