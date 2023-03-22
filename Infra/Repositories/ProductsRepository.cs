using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    /*class responsible for accessing and manipulating the data of the Products entity in the database, through the use of the Entity Framework Core.*/
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        private readonly ShopBridgeContext _context;
        public ProductsRepository(ShopBridgeContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Products>> SearchByName(string name)
        {
            var allProducts = await _context.Products
               .Where
               (
                   x => x.Name.ToLower().Contains(name.ToLower())
               )
               .AsNoTracking()
               .ToListAsync();

            return allProducts;
        }

        public async Task<List<Products>> SearchByCategory(string category)
        {
            var allProducts = await _context.Products
               .Where
               (
                   x => x.Category.ToLower().Contains(category.ToLower())
               )
               .AsNoTracking()
               .ToListAsync();

            return allProducts;
        }
    }
}
