using BShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BShop.Service.ItemRepository
{
    public interface IitemRepository
    {
        List<ItemViewModel> GetAllItems();
        ItemViewModel GetItem(String id);
        String GetOwnerId(string itemID);
        void CreateItem(ItemViewModel Item, string UserId);
        ItemViewModel UpdateItem(ItemViewModel Item, string id);
        void DeleteItem(String id);
        Task<bool> SaveChangesAsync();
    }
}
