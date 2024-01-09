using DigitalServerItems.Models;

namespace DigitalServerItems
{
    public static class SeedData
    {
        public static void Initialize(ApiContext context)
        {
            // If there are no products, add some initial data

            if (!context.Cities.Any())
            {
                context.Cities.AddRange(new[]
                {
                new City { Id = 1, Name="Tel Aviv" },
                new City { Id = 2, Name="Jerusalem" },
                new City { Id = 3, Name="Rishon Lezion" },
                new City { Id = 4, Name="Haifa" }
                });
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(new[]
                {
                new Product { Id = 1, ProductType = ProductType.INSTRUMENT, Name = "Laptop", Price = 999.99m, CreatedDate = new DateTime(2023, 12, 1), ManufacturerCityId = 1},
                new Product { Id = 2, ProductType = ProductType.INSTRUMENT, Name = "Smartphone", Price = 499.99m, CreatedDate = new DateTime(2023, 10, 1), ManufacturerCityId = 2},
                new Product { Id = 3, ProductType = ProductType.INSTRUMENT, Name = "Headphones", Price = 79.99m, CreatedDate = new DateTime(2024, 1, 1), ManufacturerCityId = 4},
                new Product { Id = 4, ProductType = ProductType.FOOD,Name = "Cheese", Price = 1.0m, CreatedDate = new DateTime(2024, 1, 1), ManufacturerCityId = 4},
                new Product { Id = 5, ProductType = ProductType.FOOD,Name = "Piza", Price = 10.0m, CreatedDate = new DateTime(2023, 12, 1), ManufacturerCityId = 1},
                new Product { Id = 6, ProductType = ProductType.FRUIT,Name = "Orange", Price = 5.0m, CreatedDate = new DateTime(2023, 12, 2), ManufacturerCityId = 3},
                new Product { Id = 7, ProductType = ProductType.FRUIT,Name = "Banana", Price = 3.0m, CreatedDate = new DateTime(2024, 1, 3), ManufacturerCityId = 2},
                new Product { Id = 8, ProductType = ProductType.FRUIT,Name = "Carot", Price = 4.0m, CreatedDate = new DateTime(2023, 12, 4), ManufacturerCityId = 4},
                new Product { Id = 9, ProductType = ProductType.FRUIT,Name = "Eggplang", Price = 6.0m, CreatedDate = new DateTime(2023, 12, 5), ManufacturerCityId = 4},
                new Product { Id = 10, ProductType = ProductType.FOOD,Name = "Salt", Price = 2.0m, CreatedDate = new DateTime(2023, 12, 6), ManufacturerCityId = 3},
                new Product { Id = 11, ProductType = ProductType.FOOD,Name = "Sugar", Price = 2.5m, CreatedDate = new DateTime(2023, 12, 7), ManufacturerCityId = 2},
                new Product { Id = 12, ProductType = ProductType.FRUIT,Name = "Cucumber", Price = 3.8m, CreatedDate = new DateTime(2023, 12, 8), ManufacturerCityId = 1},
                new Product { Id = 13, ProductType = ProductType.FRUIT,Name = "Lemon", Price = 11.0m, CreatedDate = new DateTime(2023, 12, 9), ManufacturerCityId = 1},
                new Product { Id = 14, ProductType = ProductType.FOOD,Name = "Egg", Price = 3.0m, CreatedDate = new DateTime(2023, 12, 10), ManufacturerCityId = 3},
                new Product { Id = 15, ProductType = ProductType.FOOD,Name = "Olive Oil", Price = 20.0m, CreatedDate = new DateTime(2023, 12, 11), ManufacturerCityId = 2},
                new Product { Id = 16, ProductType = ProductType.FOOD,Name = "Gum", Price = 1.0m, CreatedDate = new DateTime(2023, 12, 12), ManufacturerCityId = 4},
                new Product { Id = 17, ProductType = ProductType.INSTRUMENT,Name = "Computer", Price = 3503.0m, CreatedDate = new DateTime(2024, 1, 13), ManufacturerCityId = 4},
                new Product { Id = 18, ProductType = ProductType.INSTRUMENT,Name = "TV", Price = 2500.0m, CreatedDate = new DateTime(2021, 1, 4), ManufacturerCityId = 3},
                new Product { Id = 19, ProductType = ProductType.INSTRUMENT, Name = "Note", Price = 10.0m, CreatedDate = new DateTime(2021, 12, 2), ManufacturerCityId = 2},
                new Product { Id = 20, ProductType = ProductType.INSTRUMENT, Name = "Pencil", Price = 3.0m, CreatedDate = new DateTime(2021, 11, 1), ManufacturerCityId = 1}
            });
                context.SaveChanges();
            }
        }
    }
}
