using System;
using System.Collections.Generic;
using System.Text;

namespace BShop.ViewModel
{
    public class ItemViewModel
    {
        public String Id { get; set; } = "";
        public String Name { get; set; }
        public String Price { get; set; }
        public String Type { get; set; } //a filter of some sort
        public String Description { get; set; }
        public short Amount { get; set; }
        public String OwnerName { get; set; }
    }
}
