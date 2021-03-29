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

        public bool MakeTransaction(ShoppingCartViewModel Cart, TransactionViewModel Trans)
        {
            string creditnum = "5555555555555555";
            string BuyerID = "97682373-10b6-4dd3-8dd9-40804e686e33";
            Boolean PurchaseSuccessful = false;
            string ErrMessage = "";
            IEnumerable<ShoppingCartViewModel> Carttest = new List<ShoppingCartViewModel>() {
                new ShoppingCartViewModel{CartItem="3", amount=1},
                new ShoppingCartViewModel{CartItem="2", amount=2},
                new ShoppingCartViewModel{CartItem="1", amount=1}
            };

            DataTable CartTable = new DataTable();
            CartTable.Columns.Add("itemID");
            CartTable.Columns.Add("amount");
            foreach (var cart in Carttest)
            {
                CartTable.Rows.Add(cart.CartItem, cart.amount);
            }

            SqlParameter sqlparameter = new SqlParameter("@cartItems",CartTable);
            sqlparameter.TypeName = "dbo.UserDefCartItems";
            var x = ctx.Database.ExecuteSqlInterpolated($@"exec purchase {sqlparameter}, {creditnum},
                 {BuyerID},{ErrMessage} output, {PurchaseSuccessful} output");

            return PurchaseSuccessful;
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
