using BShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BShop.Infrastructure;
using BShop.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BShop.Service.ItemRepository
{
    public class ItemRepository : IitemRepository
    {
        private readonly AppDbContext ctx;

        public ItemRepository(AppDbContext _ctx)
        {
            ctx = _ctx;
        }

        public List<ItemViewModel> GetAllItems()
        {
            List<ItemViewModel> Livm = new List<ItemViewModel>();
            var items = ctx.BShopItems.Include(item => item.Owner).ToList();
            foreach(BShopItem Item in items)
            {
                Livm.Add(
                new ItemViewModel
                {
                    Id = Item.Id,
                    Name = Item.Name,
                    Price = Item.Price,
                    Description = Item.Description,
                    Type = Item.Type,
                    Amount = Item.Amount,
                    OwnerName = Item.Owner?.UserName
                }) ;
            }
            return Livm;
        }

        public ItemViewModel GetItem(string id)
        {
            BShopItem ShopItem = ctx.BShopItems.Where(item => item.Id==id).Include(item => item.Owner
            ).FirstOrDefault(item=> item.Id == id);//.sin;
            if (ShopItem == null) return null;

            return new ItemViewModel
            {
                Id = ShopItem.Id,
                Name = ShopItem.Name,
                Price = ShopItem.Price,
                Description = ShopItem.Description,
                Type = ShopItem.Type,
                Amount = ShopItem.Amount,
                OwnerName = ShopItem.Owner.UserName
            };
        }

        public void CreateItem(ItemViewModel Item,String UserId)
        {
            ctx.BShopItems.Add(new BShopItem
            {
                Name = Item.Name,
                Price = Item.Price,
                Type = Item.Type,
                Description = Item.Description,
                OwnerID = UserId
            });
        }

        public ItemViewModel UpdateItem(ItemViewModel Item)
        {
            BShopItem Shopitem = ctx.BShopItems.Find(Item.Id);
            if (Shopitem == null)
                return null;
            Shopitem.Name = Item.Name;
            Shopitem.Price = Item.Price;
            Shopitem.Type = Item.Type;
            Shopitem.Description = Item.Description;
            Shopitem.Amount = Item.Amount;
            return Item;
        }

        public void DeleteItem(string id)
        {
            ctx.BShopItems.Remove(ctx.BShopItems.Find(id));
        }

        public string GetOwnerId(string itemID)
        {
            return ctx.BShopItems.Find(itemID)?.OwnerID;
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
