using BShop.Infrastructure;
using BShop.Model;
using BShop.ViewModel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<PurchaseResult> MakeTransactionAsync(TransactionViewModel Trans, string UserId)
        {
            //bool PurchaseSuccessful = false;
            //string ErrMessage = "";

            DataTable CartTable = new DataTable();
            CartTable.Columns.Add("itemID");
            CartTable.Columns.Add("amount");
            foreach (var cart in Trans.ShoppingCarts)
            {
                CartTable.Rows.Add(cart.CartItem, cart.amount);
            }

            SqlParameter sqlparameterTable = new SqlParameter("@cartItems",CartTable);
            sqlparameterTable.TypeName = "dbo.UserDefCartItems";

            SqlParameter sqlparameterErrMessage = new SqlParameter
            {
                ParameterName = "@errMessage",
                SqlDbType = SqlDbType.NVarChar,
                Value = "",
                Size= 400,
                Direction = ParameterDirection.Output
            };

            SqlParameter IsSuccessful = new SqlParameter
            {
                ParameterName = "@result",
                SqlDbType = SqlDbType.Bit,
                Value = false,
                Direction = ParameterDirection.Output
            };

            try
            {
                /*var x = */
                await ctx.Database.ExecuteSqlInterpolatedAsync($@"exec purchase {sqlparameterTable}, {Trans.CreditNum},
                {UserId},{sqlparameterErrMessage} output, {IsSuccessful} output");
            }
            catch { }

            return new PurchaseResult 
            { 
                ErrorMessage = sqlparameterErrMessage?.Value?.ToString(),
                purchaseSuccessful = (bool)IsSuccessful.Value
            };
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
