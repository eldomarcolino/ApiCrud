using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaDeRecarga.Business;
using SistemaDeRecarga.Context;
using SistemaDeRecarga.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Configura��o do JWT
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
    )
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

//String de conex�o
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
