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
        public int TransID { get; set; }

        public int Fee { get; set; }
        public String CreditNum { get; set; }

        public String BuyerID { get; set; }
        [ForeignKey("BuyerID")]
        public virtual ApplicationUser Buyer { get; set; }

        public int? CartID { get; set; }
        [ForeignKey("CartID")]
        public virtual ShoppingCart ShoppingCart { get; set; }

        public DateTime TransactionTime { get; set; }
    }
}
