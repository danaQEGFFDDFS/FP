using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class ClassEdit
    {


        public int Id { get; set; }
        public string TypeProduct { get; set; }
        public int CountProduct { get; set; }
        public double SizeProduct { get; set; }
        public double Price { get; set; }
        [ForeignKey("Id")]
        public virtual Brend Brend { get; set; }
        

    }
}
