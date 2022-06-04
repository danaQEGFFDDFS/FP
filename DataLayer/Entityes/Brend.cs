using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entityes
{
    public class Brend
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
