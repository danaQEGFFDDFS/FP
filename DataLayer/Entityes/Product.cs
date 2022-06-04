using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entityes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string TypeProduct { get; set; }
        public int CountProduct { get; set; }
        public double SizeProduct{ get; set; }
        public double Price { get; set; }
       
        [ForeignKey("Id")]
        public virtual Brend Brend { get; set; }

        public static object ToClassEdit()
        {
            throw new NotImplementedException();
        }
    }
}
