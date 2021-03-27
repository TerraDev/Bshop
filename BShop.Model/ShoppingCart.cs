using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BShop.Model
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String CartID { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public string TransID { get; set; }
        public virtual Transaction Transaction { get; set; }

        public float TotalCost {get; set;}
    }
}
