using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BShop.ViewModel
{
    public class TransactionViewModel
    {
        //[Key]
        //public string TransactionViewModelId;

        //public String Fee { get; set; }
        [Required]
        public String CreditNum { get; set; }

        public List<ShoppingCartViewModel> ShoppingCarts { get; set; }
    }
}
