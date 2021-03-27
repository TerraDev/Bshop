using BShop.Infrastructure;
using BShop.Model;
using BShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BShop.Service.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext ctx;

        public TransactionRepository(AppDbContext _ctx)
        {
            ctx = _ctx;
        }

        public bool MakeTransaction(ShoppingCartViewModel Cart, TransactionViewModel Trans)
        {
            //
            return false;
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await ctx.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }
    }
}
