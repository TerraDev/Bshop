using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BShop.Service.ItemRepository;
using BShop.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Http;

namespace BShop.Controllers
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
                return Ok(Livm);
        }

        [HttpPost("Create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PostItem(ItemViewModel IVM)
        {
            string UserId = this.User.Claims.First(i => i.Type == "UserId").Value;
            itemRepo.CreateItem(IVM,UserId);//success or not? return ok or unauthorized or bad request or what?
            await itemRepo.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateItem(ItemViewModel IVM)
        {
           string OwnerId = itemRepo.GetOwnerId(IVM.Id);

           if(OwnerId == null) 
                return NotFound("Item does not exist");
        
            if(this.User.Claims.First(i => i.Type == "UserId").Value == OwnerId)
            {
                itemRepo.UpdateItem(IVM);
                await itemRepo.SaveChangesAsync();
                return Ok();
            }
            else return Forbid();
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteItem(String id)
        {
            string OwnerId = itemRepo.GetOwnerId(id);

            if (OwnerId == null)
                return NotFound("Item does not exist");

            if (this.User.Claims.First(i => i.Type == "UserId").Value == OwnerId)
            {
                itemRepo.DeleteItem(id);
                await itemRepo.SaveChangesAsync();
                return Ok();
            }
            else return Forbid();
        }

        //public async Task SearchItem
    }
}