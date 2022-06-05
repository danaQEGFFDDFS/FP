using DataLayer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApplication.Helpers
{
    public static class ConvertHelper
    {
        public static Custom ToCustom(this Customers custom)
        {
            return new Custom()
            {
               FullName = custom.FullName,
               Address = custom.Address,
               Phone = custom.Phone
            };


        }

    }
}
