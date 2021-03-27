using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BShop.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String TransID { get; set; }
        public String Fee { get; set; }
        public String CreditNum { get; set; }

        public String BuyerID { get; set; }
        [ForeignKey("BuyerID")]
        public virtual ApplicationUser Buyer { get; set; }

        //public String SellerID { get; set; }
        //[ForeignKey("SellerID")]
        //[InverseProperty("Sold")]
        //public virtual ApplicationUser Seller { get; set; }

        public String CartID { get; set; }
        [ForeignKey("CartID")]
        public virtual ShoppingCart ShoppingCart { get; set; }

        public DateTime TransactionTime { get; set; }
    }
}
