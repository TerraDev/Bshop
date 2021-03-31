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
        public int? CartID { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public int TransID { get; set; }
        public virtual Transaction Transaction { get; set; }

        [Required]
        public float TotalCost {get; set;}
    }
}
