using Microsoft.EntityFrameworkCore;
using NasaApolo.Data;
using NasaApolo.Scheduler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Iniciar el timer
builder.Services.AddHostedService<Scheduler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion para la conexion a la base de datos
builder.Services.AddDbContext<NasaTestContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"))
);

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
