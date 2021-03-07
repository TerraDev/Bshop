using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpyWire.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String TransID { get; set; }
        public String Fee { get; set; }
        public String CreditNum { get; set; }

        //public String BuyerID { get; set; }
        //[ForeignKey("BuyerID")]
        //[InverseProperty("Bought")]
        //public virtual User Buyer { get; set; }

        //public String SellerID { get; set; }
        //[ForeignKey("SellerID")]
        //[InverseProperty("Sold")]
        //public virtual User Seller { get; set; }

        public ICollection<SpyWareItem> SoldItems { get; set; }

        public DateTime TransactionTime { get; set; }
    }
}
