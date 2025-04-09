using LINQ_LABB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_LABB
{
    public static class MethodSyntax
    {
        public static void Electronics()
        {
            using (var context = new E_HandelContext())
            {
                var Electronics = context.Categories
                    .Where(c => c.Name == "Electronics")
                    .SelectMany(c => c.Products)
                    .OrderByDescending(c => c.Price)                    
                    .ToList();
                                     

                foreach (var item in Electronics)
                {
                    Console.WriteLine($"{item.Name} {item.Price}");
                }

            }
        }

        public static void Suppliers()
        {
            using (var context = new E_HandelContext())
            {
                var suppliers = context.Suppliers
                .Select(s => new
                {
                    s.Name,
                    ProductCount = s.Products.Count()
                })
                .Where(s => s.ProductCount < 10)
                .ToList();

                foreach (var item in suppliers)
                {
                    Console.WriteLine($"{item.Name} {item.ProductCount}");
                }

            }
        }

        public static void TotalOrderValue()
        {
            DateTime sdate = new DateTime(2025,3,1);
            DateTime eDate = new DateTime(2025,3,31);
            using (var context = new E_HandelContext())
            {
                var totalOrderValue = context.Orders
                    .Where(d => d.OrderDate >= sdate && d.OrderDate <= eDate)                 
                    .Select(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice))
                    .Sum();

                    Console.WriteLine($"Totala ordervärdet denna månaden: {totalOrderValue} kr");
            }
        }

        public static void MostSoldProducts()
        {
            using (var context = new E_HandelContext())
            {
                var mostSoldProducts = context.OrderDetails
                    .GroupBy(od => od.Product.Name)
                    .Select(g => new
                    {
                        ProductName = g.Key,
                        MostSold = g.Sum(od => od.Quantity)
                    })
                    .OrderByDescending(g => g.MostSold) 
                    .Take(3);
                  
                    
                   
                foreach(var item in mostSoldProducts)
                {
                    Console.WriteLine($"{item.ProductName} {item.MostSold}"); 
                }
            }
        }


        public static void ListAllCategories()
        {
            using (var context = new E_HandelContext())
            {
                var categories = context.Categories
                    .Select(c => new
                    {
                        c.Name,
                        ProductCount = c.Products.Count()
                    });
                    
                    
                foreach (var item in categories)
                {
                    Console.WriteLine($"{item.Name} {item.ProductCount}");
                }
            }
        }

        public static void GetAllOrders()
        {
            using (var context = new E_HandelContext())
            {
                var orders = context.Orders
                    .Where(p => p.TotalAmount > 1000)
                    .Select(d => new
                    {
                        d.Id,
                        d.Customer.Name,
                        d.Customer.Address,
                        d.OrderDate,
                        TotalAmount = d.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                       
                    });
                foreach (var item in orders)
                {
                    Console.WriteLine($"{item.Id} {item.Name} {item.Address} {item.OrderDate} {item.TotalAmount}");
                }
            }
        }

    }
}
