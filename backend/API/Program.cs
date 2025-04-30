using backend.Application.Command;
using backend.Domain.Interface;
using backend.Infrastructure.Data;
using backend.Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static backend.Application.Command.ExameCommand;

var builder = WebApplication.CreateBuilder(args);

// Lê a configuração do Kestrel diretamente do appsettings.json
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    // Kestrel usa a porta 5001 para o backend (API)
    serverOptions.ListenAnyIP(5001);  // Backend na porta 5001
});

// Configuração de serviços
builder.Services.AddScoped<IExameRepository, ExameRepository>();

// Registra o DbContext com uma string de conexão válida
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

// Configuração de API e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ExameCommandHandler>());

var app = builder.Build();

// Aplica migrations pendentes automaticamente
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        Console.WriteLine("Database migrations applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
    }
}

// Configuração do Swagger para ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger";
    });
}

app.UseStaticFiles();
app.UseCors("AllowFrontend");
app.MapFallbackToFile("index.html"); // <- Este é o ponto mais importante   
app.MapControllers();

app.Run();