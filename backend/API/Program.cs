using backend.Application.Command;
using backend.Domain.Interface;
using backend.Infrastructure.Data;
using backend.Infrastructure.Repository;
using MediatR;
using static backend.Application.Command.ExameCommand;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddMediatR(typeof(ExameCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(CreateExameCommand).Assembly);
builder.Services.AddScoped<IExameRepository, ExameRepository>();

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Para acessar o Swagger na raiz (http://localhost:<port>/)
    });
}

app.UseHttpsRedirection();

app.Run();
}
