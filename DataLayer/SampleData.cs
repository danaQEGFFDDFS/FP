using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public  class SampleData
    {
        public static void InitData(ShopContext context) //заполнение базы данных данными
        {
            if (!context.Brends.Any())
            {

                context.Brends.Add(new Entityes. Brend() { Name = "Gussi"});
                context.Brends.Add(new Entityes.Brend() { Name = "Prada" });
                context.SaveChanges();
                
                context.Customers.Add(new Entityes.Customers() { FullName = "Нургазиева Дана Руслановна", Phone = 89273456748, Address = "гор. Москва, ул.Вавилова, 34" });
                context.Customers.Add(new Entityes.Customers() { FullName = "Антонов Иван Сергеевич", Phone = 89067845623, Address = "гор. Москва, ул.Пушкина, 12" });
                context.SaveChanges();
                
                context.Products.Add(new Entityes.Product() { TypeProduct = "Обувь",CountProduct = 23,SizeProduct = 36,Price = 20000, Brend = context.Brends.First()});
                context.Products.Add(new Entityes.Product() { TypeProduct = "Акссесуары", CountProduct = 50, SizeProduct = 0, Price = 100000, Brend = context.Brends.Last() });
                context.SaveChanges();
                
                context.orderShops.Add(new Entityes.OrderShop() { CurrentData = DateTime.Today, Product = context.Products.First(), Customers = context.Customers.First()});
                context.orderShops.Add(new Entityes.OrderShop() { CurrentData = DateTime.Today, Product = context.Products.Last(), Customers = context.Customers.Last() });
                context.SaveChanges();

            }
        }
    }
}
