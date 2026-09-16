using projeto_cliente_lar.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Repositórios em memória
builder.Services.AddSingleton<IPessoaRepositorio, projeto_cliente_lar.Repositories.PessoaRepositorio>();
builder.Services.AddSingleton<ITelefoneRepositorio, projeto_cliente_lar.Repositories.TelefoneRepositorio>();
// Services
builder.Services.AddScoped<IPessoaService, projeto_cliente_lar.Services.PessoaService>();
builder.Services.AddScoped<ITelefoneService, projeto_cliente_lar.Services.TelefoneService>();
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
