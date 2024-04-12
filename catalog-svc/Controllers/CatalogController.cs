using Contracts;
using catalog_svc.Data;
using catalog_svc.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace catalog_svc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private CatalogDbContext _context;
        private IPublishEndpoint _publisher;

        public CatalogController(CatalogDbContext context, IPublishEndpoint publisher)
        {
            _context = context;
            _publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(CatalogItem item)
        {
            _context.CatalogItems.Add(item);
            await _context.SaveChangesAsync();

            await _publisher.Publish(new ItemCreated
            {
                Id = item.Id,
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

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _context.CatalogItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.CatalogItems.Remove(item);
            await _context.SaveChangesAsync();

            await _publisher.Publish(new ItemDeleted
            {
                Id = item.Id.ToString()
            });

            return Ok();
        }
        
    }
}