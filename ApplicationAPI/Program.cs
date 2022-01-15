using Domain;
using Infrastructure.Facade;
using Infrastructure.Repository.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IVeiculoRepository, InMemoryRepository>(); 
builder.Services.AddTransient<IVeiculoRepository, FrotaRepository>();
builder.Services.AddTransient<IVeiculoDetranFacade, VeiculoDetranFacade>();

builder.Services.AddDbContext<FrotaContext>(opt =>
                                                opt.UseInMemoryDatabase("Frota"));


IConfiguration configuration = builder.Configuration;

builder.Services.Configure<DetranOptions>(configuration.GetSection("DetranOptions"));


builder.Services.AddHttpClient();


//builder.Services.AddTransient<IVeiculoRepository, FrotaRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.     
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","APILocaliza.Frotas");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
