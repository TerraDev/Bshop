using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpyWire.Model
{
    public class SpyWareItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String Id { get; set; }

        public String Name { get; set; }
        public String Price { get; set; }
        public String Type { get; set; } //a filter of some sort

        public String Description { get; set; }

        //public String OwnerID { get; set; }
        //[ForeignKey("OwnerID")]
        //public virtual User Owner { get; set; }

        public String TransID { get; set; }
        [ForeignKey("TransID")]
        public virtual Transaction Trans { get; set; }
    }
}
