using ControlEscolar.Data;
using NominaXpert.Controller;
using NominaXpert.Data;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión para PostgreSQLDataAccess
PostgresSQLDataAccess.ConnectionString = builder.Configuration.GetConnectionString("ConexionBD");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Agregamos el controller de Estudiantes
builder.Services.AddScoped<NominasController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
