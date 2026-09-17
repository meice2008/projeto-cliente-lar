using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using projeto_cliente_lar.Data;
using projeto_cliente_lar.Interfaces;
using projeto_cliente_lar.Repositories;
using projeto_cliente_lar.Services;

var builder = WebApplication.CreateBuilder(args);

// Serilog configuration (console + file) - format and minimum levels
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] ({MachineName}/{EnvironmentName}) {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day, outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] ({MachineName}/{EnvironmentName}) {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Entity Framework Core - ApplicationDbContext (PostgreSQL)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Repositórios (EF Core)
builder.Services.AddScoped<IPessoaRepositorio, PessoaRepositorioEf>();
builder.Services.AddScoped<ITelefoneRepositorio, TelefoneRepositorioEf>();
// Services
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<ITelefoneService, TelefoneService>();
// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
// Habilita Swagger UI em /swagger em todos os ambientes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "projeto-cliente-lar v1");
    c.RoutePrefix = "swagger"; // serve UI em /swagger
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
