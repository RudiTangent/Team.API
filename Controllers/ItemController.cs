using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Teams.API.Data;
using Teams.API.Model;

namespace Teams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemRepository _itemRepo;

        private IConfiguration _configuration;

        public ItemController(IItemRepository itemRepository, IConfiguration configuration)
        {
            _itemRepo = itemRepository;
            _configuration = configuration;
        }

        [HttpGet("Items")]
        public async Task<IActionResult> GetAllItems()
        {
            var itemsList = _itemRepo.GetAllItems();

            return Ok(itemsList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var Item = _itemRepo.GetItemById(id);

            return Ok(Item);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(Items item)
        {
            var result = await _itemRepo.UpdateItem(item);
            return Ok(result);
        }

        [HttpPost("addItem")]
        public async Task<IActionResult> AddItem(Items item)
        {
            var result = await _itemRepo.AddItems(item);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (!await _itemRepo.DeleteItem(id))
                return StatusCode(404);

            return Ok();
        }
    }
}