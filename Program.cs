using SistemaDeRecarga.Business;
using SistemaDeRecarga.Context;
using SistemaDeRecarga.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connetionMysql = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connetionMysql,
        new MySqlServerVersion(new Version(8, 1, 0)) //Vers�o do MySQL
        )
    );
// Add services to the container.

//Registrar reposit�rio
builder.Services.AddScoped<IEstudantesRepository, EstudantesRepository>();
builder.Services.AddScoped<IEstudantesBusiness, EstudantesBusiness>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICursoBusiness, CursoBusiness>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
