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
    public class Custom
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
       
    }
}
