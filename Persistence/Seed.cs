using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Addresses.Any())
            {
                var products = new List<Address>
                {
                    new Address
                    {
                        Country = "Polska",
                        Street = "Testowa",
                        HouseNumber = "22",
                        ApartmentNumber = "11",
                        ZIPCode = "00-222"
                    },
                    new Address
                    {
                        Country = "Polska",
                        Street = "Testowa dwa",
                        HouseNumber = "22",
                        ApartmentNumber = "11",
                        ZIPCode = "00-222"
                    },
                    new Address
                    {
                        Country = "Niemcy",
                        Street = "Testowa dwa 2",
                        HouseNumber = "22",
                        ApartmentNumber = "11",
                        ZIPCode = "00-222"
                    },
                    new Address
                    {
                        Country = "Niemcy",
                        Street = "Testowa dwa 3",
                        HouseNumber = "22",
                        ApartmentNumber = "11",
                        ZIPCode = "00-222"
                    }
                };

                await context.Addresses.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
