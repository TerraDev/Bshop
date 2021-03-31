using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BShop.ViewModel
{
    public class ShoppingCartViewModel
    {
        [Required]
        public string CartItem { get; set; }
        [Required]
        public int amount { get; set; }
    }
}
