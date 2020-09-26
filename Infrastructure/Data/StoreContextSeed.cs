using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entites;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync (StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<IReadOnlyList<Product>>(productData);

                    foreach (var product in products)
                    {
                        await context.Products.AddAsync(product);
                    }
                }

                if (!context.ProductBrands.Any())
                {
                    var brandstData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brands = JsonSerializer.Deserialize<IReadOnlyList<ProductBrand>>(brandstData);

                    foreach (var brand in brands)
                    {
                        await context.ProductBrands.AddAsync(brand);
                    }
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var types = JsonSerializer.Deserialize<IReadOnlyList<ProductType>>(typesData);

                    foreach (var type in types)
                    {
                        await context.ProductTypes.AddAsync(type);
                    }
                }
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
           
        }
        
    }
}