using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Text;

namespace BShop.Model
{
    //[UserDefinedTableType("CartItemTableType")]
    class CartItemTableType
    {
        public String BShopItemID { get; set; }
        public Int16 Amount { get; set; }
    }
}
