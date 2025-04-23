using LINQ_LABB.Modules;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_LABB
{
    public static class MethodSyntax
    {
        
        public static void Electronics()
        {
            Console.Clear();
            Console.WriteLine("[Electronics]\n");
            Console.WriteLine("{0,-20} {1,-20}", "Product", "Price");
            using (var context = new E_HandelContext())
            {
                var Electronics = context.Categories
                    .Where(c => c.Name == "Electronics")
                    .SelectMany(c => c.Products)
                    .OrderByDescending(c => c.Price)                    
                    .ToList();
                                     

                foreach (var item in Electronics)
                {
                    Console.WriteLine($"{item.Name.PadRight(20)} {item.Price}");
                }

            }
        }

        public static void Suppliers()
        {
            Console.Clear();
            Console.WriteLine("[Suppliers]\n");
            Console.WriteLine("{0,-20} {1,-20}", "Supplier", "Product Count");
            using (var context = new E_HandelContext())
            {
                var suppliers = context.Products              
                .Select(s => new
                {
                    s.Supplier.Name,
                    InStock = s.StockQuantity,
                    
                })
                .Where(s => s.InStock < 10)
                .ToList();

                foreach (var item in suppliers)
                {
                    Console.WriteLine($"{item.Name.PadRight(20)} {item.InStock}");
                }

            }
        }

        public static void TotalOrderValue()
        {
            Console.Clear();
            DateTime current = DateTime.Today;
            DateTime from = current.AddDays(-29); 


            using (var context = new E_HandelContext())
            {
                var totalOrderValue = context.OrderDetails
                    .Where(d => d.Order.OrderDate >= from && d.Order.OrderDate <= current)                  
                    .Sum(od => od.Quantity * od.UnitPrice);
                                  
               Console.WriteLine($"Total order value this month: {totalOrderValue} kr");
            }
        }

        public static void MostSoldProducts()
        {
            Console.Clear();
            Console.WriteLine("[Most Sold Products]\n");
            Console.WriteLine("{0,-20} {1,-20}", "Product", "SoldCount");
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
                    Console.WriteLine($"{item.ProductName.PadRight(20)} {item.MostSold}"); 
                }
            }
        }


        public static void ListAllCategories()
        {
            Console.Clear();
            Console.WriteLine("[Categories]\n");
            Console.WriteLine("{0,-20} {1,-20}", "Category", "Product Count");
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
                    Console.WriteLine($"{item.Name.PadRight(20)} {item.ProductCount}");
                }
            }
        }

        public static void GetAllOrders()
        {
            Console.Clear();
            Console.WriteLine("[Orders]\n");
            Console.WriteLine("{0,-10} {1,-18} {2,-30} {3,-23} {4,-15} {5,-20} {6,-15}", "OrderID", "Customer Name", "Address", "Email", "Phone", "Total Amount", "Status");
            using (var context = new E_HandelContext())
            {
                var orders = context.Orders
                    .Where(p => p.TotalAmount > 1000)
                    .Select(d => new
                    {
                        d.Id,
                        d.Customer.Name,
                        d.Customer.Address,
                        d.Status,
                        d.Customer.Email,
                        d.Customer.Phone,
                        d.OrderDate,
                        TotalAmount = d.OrderDetails.Sum(od => od.Quantity * od.UnitPrice),
                       
                    });
                foreach (var item in orders)
                {
                    var round = Math.Round(item.TotalAmount, 2);
                    Console.WriteLine($"{item.Id.ToString().PadRight(10)} {item.Name.PadRight(18)} {item.Address.PadRight(30)} {item.Email?.PadRight(23)} {item.Phone?.PadRight(15)} {round.ToString().PadRight(20)} {item.Status.PadRight(15)}");
                }
            }
        }

    }
}
