using MassTransit;
using catalog_svc.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMassTransit(x=>{
    x.UsingRabbitMq((content, cfg)=> {
        cfg.ConfigureEndpoints(content);
    });
});

builder.Services.AddDbContext<CatalogDbContext>(options =>
{
    options.UseNpgsql("Server=localhost:5432;User Id=postgres;Password=postgrespwd;Database=catalogDb;");
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
