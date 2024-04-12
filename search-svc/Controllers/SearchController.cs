using Microsoft.AspNetCore.Mvc;
using MongoDB.Entities;
using search_svc.Models;


namespace search_svc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> SearchItems(string searchTerm)
        {
            var query = DB.Find<CatalogItem>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query.Match(Search.Full, searchTerm);
            }

            var result = await query.ExecuteAsync();

            return Ok(result);
        }
    }
}