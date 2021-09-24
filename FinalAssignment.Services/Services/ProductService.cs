using FinalAssignment.DAL.Data.Model;
using FinalAssignment.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment.Services.Services
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProducts();
        public Task<Product> GetProductById(int? id);
        public Task<bool> CreateProduct(Product product);

        public Task UpdateProduct(Product product);
        public Task DeleteProduct(int id);
        public bool ProductExist(int id);


    }
    public  class ProductService : IProductService
    {
        public async Task<bool> CreateProduct(Product product)
        {
            using(var _context=new AssetDbContext())
            {
                try
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            using (var _context=new AssetDbContext())
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            using(var _context=new AssetDbContext())
            {
                return await _context.Products.ToListAsync();
            }
        }

        public async Task<Product> GetProductById(int? id)
        {
           using(var _context=new AssetDbContext())
            {
                return await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            }
        }

        public bool ProductExist(int id)
        {
            using(var _context=new AssetDbContext())
            {
                return _context.Products.Any(m => m.Id == id);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            using(var _context=new AssetDbContext())
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
