using BShop.Service.TransactionRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BShop.Controllers
{
    [Route("api/Purchase")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionController(ITransactionRepository transRepository)
        {
            transactionRepository = transRepository;
        }

        //api for purchasing items
        [HttpPut("/{id}")]
        public async Task<IActionResult> Purchase()//input is json array object
        {
            var x = transactionRepository.MakeTransaction(null, null);
            await transactionRepository.SaveChangesAsync();
            return Ok(x);
        }
    }
}
