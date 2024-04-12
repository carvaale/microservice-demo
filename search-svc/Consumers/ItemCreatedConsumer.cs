using MassTransit;
using search_svc.Models;
using Contracts;
using MongoDB.Entities;

namespace search_svc.Consumers
{
    public class ItemCreatedConsumer : IConsumer<ItemCreated>
    {
        public async Task Consume(ConsumeContext<ItemCreated> context)
        {
            var item = context.Message;
            await DB.SaveAsync(new CatalogItem
            {
                OriginalId = item.Id.ToString(),
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                PictureFileName = item.PictureFileName,
                PictureUri = item.PictureUri,
                CatalogBrand = item.CatalogBrand,
                AvailableStock = item.AvailableStock,
                RestockThreshold = item.RestockThreshold,
                MaxStockThreshold = item.MaxStockThreshold,
                OnReorder = item.OnReorder
            });
        }
    }
}