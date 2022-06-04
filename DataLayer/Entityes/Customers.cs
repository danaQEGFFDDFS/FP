using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }

       


       
    
    }
}
