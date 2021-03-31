using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BShop.Model
{
    public class BShopItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public int Price { get; set; }

        public String Type { get; set; } //a filter of some sort
        [Required]
        public short Amount { get; set; }
        public String Description { get; set; }

        public String OwnerID { get; set; }
        [ForeignKey("OwnerID")]
        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
