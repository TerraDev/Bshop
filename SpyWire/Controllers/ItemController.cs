using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpyWire.Service.ItemRepository;
using SpyWire.ViewModel;

namespace SpyWire.Controllers
{
    [ApiController]
    [Route("Item")]
    public class ItemController : ControllerBase
    {
        private readonly IitemRepository itemRepo;

        public ItemController(IitemRepository _itemRepo)
        {
            itemRepo = _itemRepo;
        }

        [HttpGet("Get/{id}")]
        public ActionResult<ItemViewModel> GetItem(String id)
        {
            ItemViewModel IVM = itemRepo.GetItem(id);
            if (IVM != null)
                return Ok(IVM);
            else
                return NotFound();
        }

        [HttpGet("All")]
        public ActionResult<List<ItemViewModel>> GetAll()
        {
            List<ItemViewModel> Livm = itemRepo.GetAllItems();

            //if (Livm != null)
                return Ok(Livm);
            //else
            //    return NotFound();
        }

        [HttpPost("Create")]
        public async Task PostItem(ItemViewModel IVM)
        {
            itemRepo.CreateItem(IVM);
            await itemRepo.SaveChangesAsync();
        }

        [HttpPut("Update/{id}")]
        public async Task UpdateItem(String id, ItemViewModel IVM)
        {
            itemRepo.UpdateItem(id, IVM);
            await itemRepo.SaveChangesAsync();
        }

        [HttpDelete("Delete/{id}")]
        public async Task DeleteItem(String id)
        {
            itemRepo.DeleteItem(id);
            await itemRepo.SaveChangesAsync();
        }
    }
}