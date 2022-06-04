using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Helpers;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext _context; //Добавляем поле, которое будет отражать зависимости.


        public HomeController(ShopContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;

        }
        private readonly ILogger<HomeController> _logger;



        public IActionResult Index()
        {
            _context.Database.EnsureCreated();
            List<OrderShop> _dirs = _context.orderShops.Include(x => x.Customers).Include(x => x.Product).ToList();// выведем через linq, обращаемся к колекциям даннх и выводим их
            return View();
        }

        [HttpGet]
        public IActionResult ListCustomers()
        {
            return View(_context.Customers);
        }


        public IActionResult CreateCustom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustom(Custom model)
        {
            _context.Database.EnsureCreated();
            if (!ModelState.IsValid)
                return View();
            if (await AddCustom(model.FullName, model.Address, model.Phone))
                return Redirect("/Home/Index");
            else
            {
                ModelState.AddModelError("Username", "Name of product in use");
                return View();
            }

        }

        private async Task<bool> AddCustom(string name, string addre, long phone)
        {
            if (_context.Customers.Any(p => p.FullName == name))
                return false;
            Customers cust = new Customers()
            {
                FullName = name,
                Address = addre,
                Phone = phone,

            };
            await _context.Customers.AddAsync(cust);
            await _context.SaveChangesAsync();
            return true;
        }

        public IActionResult EditCustom(int id)
        {
            Customers c = _context.Customers.Find(id);
            return View(c.ToCustom());
        }
        [HttpPost]
        public async Task<IActionResult> EditCustom(Custom model)
        {
            if (!ModelState.IsValid)
                return View();
            Customers cust = _context.Customers.Find(model.Id);
            if (cust != null)
            {
                bool taken = cust.FullName != model.FullName && _context.Customers.Any(p => p.FullName == model.FullName);
                if (taken)
                {
                    ModelState.AddModelError("Custom", "Custom in use");
                    return View();
                }
                cust.FullName = model.FullName;
                await _context.SaveChangesAsync();
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Invalid ID");
                return View();
            }
        }
       
        public async Task<IActionResult> DeletecustAsync(Custom model)
        {


            if (!ModelState.IsValid)
                return View();
            if (await DelCust(model.FullName, model.Address, model.Phone))
                return Redirect("/Home/Index");
            else
            {
                ModelState.AddModelError("Username", "Name of product in use");
                return View();
            }
        }

        public async  Task<bool> DelCust(string name, string addre, long phone)
        {
            /* Customers cust = _context.Customers.Find(id);
             if (cust != null)
             {
                 _context.Customers.Remove(cust);
                 await _context.SaveChangesAsync();
             }
             return Redirect("/Home/ListCustomers");*/


            if (_context.Customers.Any(p => p.FullName == name))
                return false;
            Customers cust = new Customers()
            {
                FullName = name,
                Address = addre,
                Phone = phone,

            };
            _context.Customers.Remove(cust);
            await _context.SaveChangesAsync();
            return true;




        }


        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ClassEdit model)
        {
            _context.Database.EnsureCreated();
            if (!ModelState.IsValid)
                return View();
            if (await AddProduct(model.TypeProduct, model.CountProduct, model.SizeProduct, model.Price))
                return Redirect("/Home/Index");
            else
            {
                ModelState.AddModelError("Username", "Name of product in use");
                return View();
            }

        }
        private async Task<bool> AddProduct(string name, int countProduct, double sizeP, double price)
        {
            if (_context.Products.Any(p => p.TypeProduct == name))
                return false;
            Product pro = new Product()
            {
                TypeProduct = name, 
                CountProduct = countProduct, SizeProduct = sizeP, Price = price
               
            };
            await _context.Products.AddAsync(pro);
            await _context.SaveChangesAsync();
            return true;
        }


        public IActionResult EditProduct(int id)
        {
           Product pro = _context.Products.Find(id);
            return View(Product.ToClassEdit());
        }
        public async Task<IActionResult> EditProduct(ClassEdit model)
        {
            if (!ModelState.IsValid)
                return View();
            Product pro = _context.Products.Find(model.Id);
            if (pro != null)
            {
                bool taken = pro.TypeProduct != model.TypeProduct && _context.Products.Any(p => p.TypeProduct == model.TypeProduct);
                if (taken)
                {
                    ModelState.AddModelError("Product", "Product in use");
                    return new JsonResult(new { ResultFinal = model });
                }
                pro.TypeProduct = model.TypeProduct;
                await _context.SaveChangesAsync();
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Invalid ID");
                return View();
            }
        }

        
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product prod = _context.Products.Find(id);
            if (prod != null)
            {
                _context.Products.Remove(prod);
                await _context.SaveChangesAsync();
            }
            return Redirect("/Home/ListProduct");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
