using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BShop.ViewModel
{
    public class ItemViewModel
    {
        public String Id { get; set; } = "";
        [Required]
        public String Name { get; set; }
        [Required]
        public int Price { get; set; }
        public String Type { get; set; } //a filter of some sort
        public String Description { get; set; }
        [Required]
        public short Amount { get; set; }
        public String OwnerName { get; set; }
    }
}
