using MassTransit;
using MongoDB.Driver;
using MongoDB.Entities;
using search_svc.Consumers;
using search_svc.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMassTransit(x=>{
    x.AddConsumersFromNamespaceContaining<ItemCreatedConsumer>();
    x.UsingRabbitMq((content, cfg)=> {
        cfg.ConfigureEndpoints(content);
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

await DB.InitAsync("searchDb", MongoClientSettings.FromConnectionString("mongodb://root:mongopw@localhost"));

await DB.Index<CatalogItem>()
    .Key(c => c.Name, KeyType.Text)
    .CreateAsync();


// await DB.SaveAsync(new CatalogItem{
//     Name = "Test Item",
//     Description = "This is a test item.",
//     Price = 100
// });

app.Run();
