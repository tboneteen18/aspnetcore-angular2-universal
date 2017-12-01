using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspCoreServer.Models;
using AspCoreServer;

namespace AspCoreServer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SpaDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return;   // DB has been seeded
            }
            var users = new User[]
            {
               new User(){Name = "Mark Pieszak"},
               new User(){Name = "Abrar Jahin"},
               new User(){Name = "hakonamatata"},
               new User(){Name = "LiverpoolOwen"},
               new User(){Name = "Ketrex"},
               new User(){Name = "markwhitfeld"},
               new User(){Name = "daveo1001"},
               new User(){Name = "paonath"},
               new User(){Name = "nalex095"},
               new User(){Name = "ORuban"},
               new User(){Name = "Gaulomatic"}
            };

            foreach (User s in users)
            {
                context.User.Add(s);
            }

            //if (context.Product.Any())
            //{
            //    return;   // DB has been seeded
            //}
            //var products = new Product[]
            //{
            //    new Product()
            //    {
            //        //ProductId = 1,
            //        Name = "Shampoo",
            //        Description = "Shampoo Description",
            //        DateCreated = DateTime.Now,
            //        PurchaseCost = 0,
            //        SalePrice = 0,

            //    }
            //};

            //foreach (Product s in products)
            //{
            //    context.Product.Add(s);
            //}

            if (context.Service.Any())
            {
                return;   // DB has been seeded
            }
            var services = new Service[]
            {
                new Service()
                {
                    //ServiceId = 1,
                    Name = "Eye Lash Extentions",
                    Description = "Eye Lash Extentions Description",
                    DateCreated = DateTime.Now.ToString(),
                    IsActive = true.ToString(),
                    Price = 0,

                }
            };

            foreach (Service s in services)
            {
                context.Service.Add(s);
            }

            context.SaveChanges();
        }
    }
}
