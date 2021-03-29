using BShop.Service.TransactionRepository;
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
        [HttpPut]
        public async Task<IActionResult> Purchase()//input is json array object
        {
            var x = transactionRepository.MakeTransaction(null, null);
            await transactionRepository.SaveChangesAsync();
            return Ok(x);
        }
    }
}
