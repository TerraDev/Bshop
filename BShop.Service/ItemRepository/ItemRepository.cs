﻿using BShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BShop.Infrastructure;
using BShop.Model;

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
            foreach(BShopItem SWI in ctx.SpyWareItems)
            {
                Livm.Add(
                    new ItemViewModel
                    {
                        Id = SWI.Id,
                        Name = SWI.Name,
                        Price = SWI.Price,
                        Description = SWI.Description,
                        Type = SWI.Type,
                        //OwnerName = SWI.Owner?.Username
                    }) ;
            }
            return Livm;
        }

        public ItemViewModel GetItem(string id)
        {
            BShopItem SWI = ctx.SpyWareItems.Find(id);
            return new ItemViewModel
            {
                Id = SWI.Id,
                Name = SWI.Name,
                Price = SWI.Price,
                Description = SWI.Description,
                Type = SWI.Type,
                //OwnerName = SWI.Owner.Username
            };
        }

        public void CreateItem(ItemViewModel Item)
        {
            //get current user and other stuff...
            ctx.SpyWareItems.Add(new BShopItem
            {
                Name = Item.Name,
                Price = Item.Price,
                Type = Item.Type,
                Description = Item.Description,
                //Owner = CurrentUser
            });
        }

        public void UpdateItem(string id, ItemViewModel Item)
        {
            BShopItem SWI = ctx.SpyWareItems.Find(id);
            SWI.Name = Item.Name;
            SWI.Price = Item.Price;
            SWI.Type = Item.Type;
            SWI.Description = Item.Description;
        }

        public void DeleteItem(string id)
        {
            BShopItem itm = ctx.SpyWareItems.Find(id);
            //get id of current user
            //if currentUser.Id==Itm.Owner.Id
            //then ->
            ctx.SpyWareItems.Remove(itm);
            // else ACCESS DENIED
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