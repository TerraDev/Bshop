using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BShop.Model
{
    public class CartItem
    {
        [Key]
        public int? ShoppingCartID;

        [ForeignKey("ShoppingCartID")]
        public virtual ShoppingCart ShoppingCart { get; set; }

        [Key]
        public String BShopItemID;
        [ForeignKey("BShopItemID")]
        public virtual BShopItem ShopItem { get; set; }

        [Required]
        public short Amount { get; set; }
    }
}
