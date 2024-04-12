using MassTransit;
using MongoDB.Entities;
using Contracts;
using search_svc.Models;

namespace search_svc.Consumers
{
    public class ItemDeletedConsumer : IConsumer<ItemDeleted>
    {
        public async Task Consume(ConsumeContext<ItemDeleted> context)
        {
            var item = context.Message;
            await DB.DeleteAsync<CatalogItem>(item.Id);
        }
    }
}