using BShop.Model;
using BShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BShop.Service.TransactionRepository
{
    public interface ITransactionRepository
    {
        Task<PurchaseResult> MakeTransactionAsync(TransactionViewModel Trans, string UserId);
        Task<bool> SaveChangesAsync();
    }
}
