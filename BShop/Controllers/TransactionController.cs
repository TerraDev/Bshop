using BShop.Service.TransactionRepository;
using BShop.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BShop.Controllers
{
    [Route("Purchase")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionController(ITransactionRepository transRepository)
        {
            transactionRepository = transRepository;
        }

        //api for purchasing items
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PurchaseResult>> Purchase([FromBody] TransactionViewModel TransVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string UserId = this.User.Claims.First(i => i.Type == "UserId").Value;
            var x = await transactionRepository.MakeTransactionAsync(TransVM, UserId);
            await transactionRepository.SaveChangesAsync();
            if (x.purchaseSuccessful)
                return Ok(x);
            else
                return BadRequest(x);
        }
    }
}
