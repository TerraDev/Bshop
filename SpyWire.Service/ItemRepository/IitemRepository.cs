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
        void CreateItem(ItemViewModel Item);
        void UpdateItem(String id, ItemViewModel Item);
        void DeleteItem(String id);
        Task<bool> SaveChangesAsync();
    }
}
