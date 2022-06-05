using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entityes
{
     public class OrderShop
    {
        [Key]
        public int Id{ get; set; }
        public DateTime CurrentData { get; set; }

        [ForeignKey("Id")]
        public virtual Product Product { get; set; }

        [ForeignKey("Id")]
        public virtual Customers Customers { get; set; }
    }
}
